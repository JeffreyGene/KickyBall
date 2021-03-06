import { Component, HostListener, OnInit, OnDestroy } from '@angular/core';
import { Controllers } from 'src/controllers/controllers';
import { FieldPosition } from 'src/models/field-position.model';
import { timer, Observable, Subscription } from 'rxjs';
import { Key } from 'protractor';
import { Game } from 'src/models/game.model';
import { Round } from 'src/models/round.model';
import { GoalAttempt } from 'src/models/goal-attempt.model';
import { MODULE_MAP } from '@nguniversal/module-map-ngfactory-loader';
import { Move } from 'src/models/move.model';
import { RecordGoalAttemptRequest } from 'src/requests/recordGoalAttemptRequest';

@Component({
  selector: 'app-play',
  templateUrl: './play.component.html',
  styleUrls: ['./play.component.scss']
})
export class PlayComponent implements OnInit, OnDestroy {
  PRACTICE_ROUND_TIME: number;
  ROUND_TIME: number;
  NUMBER_OF_PRACTICE_ROUNDS: number;
  NUMBER_OF_ROUNDS: number;
  TOTAL_NUMBER_OF_ROUNDS: number;
  UNIQUE_ROUTES_TO_SCORE: number = 8;
  controllers: Controllers;
  positions: FieldPosition[];
  currentFieldPositionId: number = 1;
  activePositions: number[] = [2, 3];
  showResetButton: boolean = false;
  gameStarted: boolean = false;
  roundStarted: boolean = false;
  roundNumber: number = 0;
  timerSubscription: Subscription;
  timeLeftForRound: number;
  goalsThisRound: number = 0;
  routeIdsThisGame: number[] = [];
  scoreText: string = null;
  totalGoals: number = 0;
  practiceGoals: number = 0;
  currentGame: Game;
  currentRound: Round;
  currentGoalAttempt: GoalAttempt;
  moveNumber: number;
  goalAttemptNumber: number;
  private userId: number;
  gameOver: boolean = false;
  paused: boolean = false;
  loadingCount: number = 0;
  timeSinceLastAction: number = 0;
  choices: number[] = [];
  showNeedMoreDataMessage: boolean = false;
  showEndOfRound: boolean = false;
  shootGoal: boolean = false;
  missGoal: boolean = false;
  settingScore: boolean = false;

  constructor(controllers: Controllers) {
    this.controllers = controllers;
  }

  updateLoadingCount(){
    this.loadingCount--;
  }

  initPreviousGame(game){
    this.loadingCount += 5;
    this.paused = true;
    this.currentGame = game;
    this.currentRound = this.currentGame.rounds[game.rounds.length - 1];
    this.timeLeftForRound = this.currentRound.secondsRemaining;
    this.roundNumber = this.currentGame.rounds.length;
    this.gameStarted = true;
    this.roundStarted = true;
    this.controllers.gameController.GetGameGoals(this.currentGame.gameId).subscribe(g => {
      this.totalGoals = g;
      this.updateLoadingCount();
    });
    this.controllers.gameController.GetRoundGoals(this.currentRound.roundId).subscribe(g => {
      this.goalsThisRound = g;
      this.updateLoadingCount();
    });
    this.controllers.gameController.GetPracticeGoals(this.currentRound.gameId).subscribe(g => {
      this.practiceGoals = g;
      this.updateLoadingCount();
    });
    this.controllers.gameController.GetRouteIdsForGame(this.currentGame.gameId, this.UNIQUE_ROUTES_TO_SCORE).subscribe(p => {
      this.routeIdsThisGame = p; 
      this.updateLoadingCount();
    });
    this.controllers.gameController.GetGoalAttemptNumberForRound(this.currentRound.roundId, this.UNIQUE_ROUTES_TO_SCORE).subscribe(a => {
      this.goalAttemptNumber = a; 
      this.resetFieldPosition();
      this.updateLoadingCount();
    });
  }
  
  ngOnInit() {
    function onlyUnique(value, index, self) { 
      return self.indexOf(value) === index;
    }
    this.loadingCount += 2;
    this.controllers.fieldPositionController.GetFieldPositions().subscribe(positions => {
      this.positions = positions;
      this.choices = positions.map(p => p.choiceNumber).filter(onlyUnique).sort((c1, c2) => (c1 > c2 ? -1 : 1));
      this.updateLoadingCount();
    });
    this.controllers.applicationSettingController.GetGameSettings().subscribe(s => {
      this.PRACTICE_ROUND_TIME = +s.find(s => s.applicationSettingCode === 'PRT').value;
      this.ROUND_TIME = +s.find(s => s.applicationSettingCode === 'RT').value;
      this.NUMBER_OF_PRACTICE_ROUNDS = +s.find(s => s.applicationSettingCode === 'NOPR').value;
      this.NUMBER_OF_ROUNDS = +s.find(s => s.applicationSettingCode === 'NOR').value;
      this.TOTAL_NUMBER_OF_ROUNDS = this.NUMBER_OF_PRACTICE_ROUNDS + this.NUMBER_OF_ROUNDS;
      this.updateLoadingCount();
    });

    this.userId = this.controllers.authenticationController.currentUserValue.userId;
    //See if a current unfinished game exists
    this.loadingCount++;
    this.controllers.gameController.GetCurrentGame(this.userId).subscribe(game => {
      this.updateLoadingCount();
      if(game == null){
        return;
      }
      else if (game.finished == true){
        this.gameOver = true;
      }
      else {
        this.initPreviousGame(game);
      }
    });
  }

  ngOnDestroy() {
    if(!!this.timerSubscription){
      this.timerSubscription.unsubscribe();
    }
  }

  moveLeft() {
    this.moveToPosition(this.positions.find(p => p.fieldPositionId == this.activePositions[0]));
  }

  moveRight() {
    this.moveToPosition(this.positions.find(p => p.fieldPositionId == this.activePositions[1]));
  }

  unPause() {
    this.paused = false;
    this.showNeedMoreDataMessage = false;
    if(this.timeLeftForRound > 0){
      if(!this.timerSubscription){
        this.timerSubscription = this.initTimerSubscription();
      }
    }
    else {
      this.startRound();
    }
  }

  startGame(){
    if(this.userId != null){
      let newGame = new Game();
      newGame.userId = this.userId;
      newGame.rounds = [];
      this.controllers.gameController.CreateGame(newGame).subscribe(g => {
        this.currentGame = g;
        this.gameStarted = true;
        this.totalGoals = 0;
        this.roundNumber = 0;
        this.startRound();
      });
    }
  }

  needMorePracticeData(){
    return this.currentRound.practice && this.currentRound.goalAttempts.length < 25;
  }

  needMoreNormalData(){
    return !this.currentRound.practice && this.currentRound.goalAttempts.length < 25;
  }

  checkDataPoints(){
    if(this.timeLeftForRound == 0 && (this.needMorePracticeData() || this.needMoreNormalData())){
      this.timeLeftForRound += 60;
      this.showNeedMoreDataMessage = true;
      this.paused = true;
    }
  }

  initTimerSubscription() {
    return timer(0, 1000).subscribe(seconds =>  {
      if(!this.paused){
        this.timeLeftForRound--;
        this.timeSinceLastAction++;
        if(this.timeSinceLastAction == 30){
          this.paused = true;
          this.timeSinceLastAction = 0;
        }
        this.checkDataPoints();
        if(this.timeLeftForRound == 0 && this.roundNumber == this.TOTAL_NUMBER_OF_ROUNDS || this.roundNumber > this.TOTAL_NUMBER_OF_ROUNDS){
          this.endGame();
        }
        else if(this.timeLeftForRound == 0){
          this.endRound();
        }
      }
    });
  }

  initRoundSettings(){
    this.currentRound.practice = this.roundNumber <= this.NUMBER_OF_PRACTICE_ROUNDS;
    this.timeLeftForRound = this.currentRound.practice ? this.PRACTICE_ROUND_TIME : this.ROUND_TIME;
    this.currentRound.secondsRemaining = this.timeLeftForRound;
    this.timeSinceLastAction = 0;
  }

  startRound(){
    this.showEndOfRound = false;
    this.goalAttemptNumber = 1;
    this.roundNumber++;
    this.currentRound = new Round();
    this.currentRound.goalAttempts = [];
    this.initRoundSettings();
    this.goalsThisRound = 0;
    this.roundStarted = true;
    this.currentRound.gameId = this.currentGame.gameId;
    this.currentRound.ordinal = this.roundNumber;
    this.controllers.gameController.CreateRound(this.currentRound).subscribe(r => {
      this.currentRound = r;
      this.resetFieldPosition();
      this.currentGame.rounds.push(r);
      this.timerSubscription = this.initTimerSubscription();
    });
  }

  endRound(){
    this.showNeedMoreDataMessage = false;
    this.showEndOfRound = true;
    this.showResetButton = false;
    this.timerSubscription.unsubscribe();
    this.controllers.gameController.FinishRound(this.currentRound.roundId).subscribe(r => {
      //Round Fininshed
      this.roundStarted = false;
    });
  }

  endGame(){
    this.controllers.gameController.FinishGame(this.currentGame.gameId).subscribe(r => {
      //Game Fininshed
      this.gameOver = true;
    });
    this.endRound();
    this.gameStarted = false;
  }

  padTimer(seconds){
    return ('00' + seconds).slice(-2);
  }

  getTimeRemaining(){
    return Math.floor(this.timeLeftForRound / 60).toString() + ':' + this.padTimer(this.timeLeftForRound % 60);
  }

  getPositionsForChoice(choice: number){
    return this.positions.filter(p => p.choiceNumber === choice);
  }

  isPositionDisabled(fieldPositionId){
    return !this.activePositions.some(p => p == fieldPositionId);
  }

  updateRouteIdsThisGame(){
    this.routeIdsThisGame.push(this.currentGoalAttempt.routeId);
    if(this.routeIdsThisGame.length > this.UNIQUE_ROUTES_TO_SCORE){
      this.routeIdsThisGame.splice(0, this.routeIdsThisGame.length - this.UNIQUE_ROUTES_TO_SCORE);
    }
  }
  
  //Score as long as you don't choose the same path you have done previously this round
  //test this
  updateScore(scoredGoal){
    if(scoredGoal){
      this.scoreText = 'GOAL!';
      setTimeout(() => {
        this.shootGoal = true;
      }, 100);
      this.goalsThisRound++;
      if(this.currentRound.practice){
        this.practiceGoals++;
      }
      this.totalGoals++;
      this.currentGoalAttempt.scoredGoal = true;
    }
    else {
      this.scoreText = 'No goal.';
      setTimeout(() => {
        this.missGoal = true;
      }, 100);
    }
  }

  getRouteId(){
    let routeId = 0;
    let power = this.currentGoalAttempt.moves.length - 1;
    this.currentGoalAttempt.moves.forEach(m => {
      if(m.directionId == 1){
        routeId += Math.pow(2, power);
      }
      power--;
    });
    return routeId + 1;
  }

  setScore(){
    this.settingScore = true;
    this.currentGoalAttempt.scoredGoal = false;
    this.currentGoalAttempt.routeId = this.getRouteId();
    let request = new RecordGoalAttemptRequest();
    request.goalAttempt = this.currentGoalAttempt;
    request.secondsRemaining = this.timeLeftForRound;
    this.controllers.gameController.RecordGoalAttempt(request).subscribe(a => {
      //Goal Recorded
      this.updateScore(a.scoredGoal);
      this.currentRound.goalAttempts.push(this.currentGoalAttempt);
      this.settingScore = false;
    });
  }

  getDirection(fieldPositionId){
    let position = this.positions.find(p => p.fieldPositionId == this.currentFieldPositionId);
    if(fieldPositionId == position.leftFieldPositionId){
      return 1;
    }
    else if(fieldPositionId == position.rightFieldPositionId){
      return 2;
    }
    return null;
  }

  moveToPosition(position: FieldPosition){
    if(!this.roundStarted || position == null){
      return;
    }
    this.timeSinceLastAction = 0;
    let move = new Move();
    move.ordinal = this.moveNumber;
    move.directionId = this.getDirection(position.fieldPositionId);
    move.fieldPositionid = position.fieldPositionId;
    this.currentGoalAttempt.moves.push(move);
    this.moveNumber++;
    this.currentFieldPositionId = position.fieldPositionId;
    this.activePositions = [position.leftFieldPositionId, position.rightFieldPositionId];
    if(position.leftFieldPositionId == null && position.rightFieldPositionId == null){
      //Save last position and restart
      this.showResetButton = true;
      this.setScore();
    }
  }

  resetFieldPosition(){
    this.shootGoal = false;
    this.missGoal = false;
    this.currentFieldPositionId = 1;
    this.activePositions = [2, 3];
    this.showResetButton = false;
    this.scoreText = null;
    this.currentGoalAttempt = new GoalAttempt();
    this.currentGoalAttempt.moves = [];
    this.currentGoalAttempt.roundId = this.currentRound.roundId;
    this.currentGoalAttempt.ordinal = this.goalAttemptNumber;
    this.moveNumber = 1;
    this.goalAttemptNumber++;
  }
}
