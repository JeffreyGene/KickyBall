import { Component, HostListener } from '@angular/core';
import { Controllers } from 'src/controllers/controllers';
import { FieldPositionModel } from 'src/models/field-position.model';
import { timer, Observable, Subscription } from 'rxjs';
import { Key } from 'protractor';
import { GameModel } from 'src/models/game.model';
import { RoundModel } from 'src/models/round.model';
import { GoalAttemptModel } from 'src/models/goal-attempt.model';
import { MODULE_MAP } from '@nguniversal/module-map-ngfactory-loader';
import { MoveModel } from 'src/models/move.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  ROUND_TIME: number = 15;
  NUMBER_OF_ROUNDS: number = 6;
  controllers: Controllers;
  positions: FieldPositionModel[];
  currentPosition: number = 1;
  activePositions: number[] = [2, 3];
  showResetButton: boolean = false;
  gameStarted: boolean = false;
  roundStarted: boolean = false;
  roundNumber: number = 0;
  timerSubscription: Subscription;
  timeLeftForRound: number = this.ROUND_TIME;
  goalsThisRound: number = 0;
  endPositionsThisRound: number[] = [];
  scoreText: string = null;
  totalGoals: number = 0;
  currentGame: GameModel;
  currentRound: RoundModel;
  currentGoalAttempt: GoalAttemptModel;
  moveNumber: number;
  goalAttemptNumber: number;

  constructor(controllers: Controllers) {
    this.controllers = controllers;

    this.controllers.fieldPositionController.GetFieldPositions().subscribe(positions => {
      this.positions = positions;
    });
  }

  @HostListener('window:keyup', ['$event'])
  handleKeyboardEvent(event: KeyboardEvent) { 
    if(event.key == 'ArrowLeft'){
      //Move Left
      this.moveToPosition(this.positions.find(p => p.fieldPositionId == this.activePositions[0]));
    }
    else if(event.key == 'ArrowRight'){
      //Move Right
      this.moveToPosition(this.positions.find(p => p.fieldPositionId == this.activePositions[1]));
    }
  }

  startGame(){
    let newGame = new GameModel();
    newGame.personId = 1;
    newGame.rounds = [];
    this.controllers.gameController.CreateGame(newGame).subscribe(g => {
      this.currentGame = g;
      this.gameStarted = true;
      this.totalGoals = 0;
      this.roundNumber = 0;
      this.startRound();
    });
  }

  startRound(){
    this.goalAttemptNumber = 1;
    this.roundNumber++;
    this.timeLeftForRound = this.ROUND_TIME;
    this.goalsThisRound = 0;
    this.endPositionsThisRound = [];
    this.roundStarted = true;
    this.currentRound = new RoundModel();
    this.currentRound.gameId = this.currentGame.gameId;
    this.currentRound.ordinal = this.roundNumber;
    this.controllers.gameController.CreateRound(this.currentRound).subscribe(r => {
      this.currentRound = r;
      this.resetFieldPosition();
      this.currentGame.rounds.push(r);
      this.timerSubscription = timer(0, 1000).subscribe(seconds =>  {
        this.timeLeftForRound--;
        if(this.timeLeftForRound == 0 && this.roundNumber == this.NUMBER_OF_ROUNDS){
          this.endGame();
        }
        else if(this.timeLeftForRound == 0){
          this.endRound();
        }
      });
    });
  }

  endRound(){
    this.timerSubscription.unsubscribe();
    this.roundStarted = false;
    this.showResetButton = false;
  }

  endGame(){
    this.endRound();
    this.gameStarted = false;
  }

  padTimer(seconds){
    return ('00' + seconds).slice(-2);
  }

  getTimeRemaining(){
    return Math.floor(this.timeLeftForRound / 60).toString() + ':' + this.padTimer(this.timeLeftForRound % 60);
  }

  getWidth(fieldPositionId: number){
    return 100 / Math.pow(2, Math.floor(Math.log(fieldPositionId)/Math.log(2)));
  }

  isPositionDisabled(fieldPositionId){
    return !this.activePositions.some(p => p == fieldPositionId);
  }

  setScore(fieldPositionId){
    this.scoreText = 'No goal.';
    this.currentGoalAttempt.scoredGoal = false;
    if(!this.endPositionsThisRound.some(p => p == fieldPositionId)){
      this.scoreText = 'GOAL!';
      this.goalsThisRound++;
      this.totalGoals++;
      this.currentGoalAttempt.scoredGoal = true;
    }
    this.controllers.gameController.CreateGoalAttempt(this.currentGoalAttempt).subscribe(a => {
      console.log(a);
    });
    this.endPositionsThisRound.push(fieldPositionId);
  }

  getDirection(fieldPositionId){
    let position = this.positions.find(p => p.fieldPositionId == this.currentPosition);
    if(fieldPositionId == position.leftFieldPositionId){
      return 1;
    }
    else if(fieldPositionId == position.rightFieldPositionId){
      return 2;
    }
    return null;
  }

  moveToPosition(position: FieldPositionModel){
    if(!this.roundStarted || position == null){
      return;
    }
    let move = new MoveModel();
    move.ordinal = this.moveNumber;
    move.directionId = this.getDirection(position.fieldPositionId);
    this.currentGoalAttempt.moves.push(move);
    this.moveNumber++;
    this.currentPosition = position.fieldPositionId;
    this.activePositions = [position.leftFieldPositionId, position.rightFieldPositionId];
    if(this.currentPosition > 31){
      //Save last position and restart
      this.showResetButton = true;
      this.setScore(this.currentPosition)
    }
  }

  resetFieldPosition(){
    this.currentPosition = 1;
    this.activePositions = [2, 3];
    this.showResetButton = false;
    this.scoreText = null;
    this.currentGoalAttempt = new GoalAttemptModel();
    this.currentGoalAttempt.moves = [];
    this.currentGoalAttempt.roundId = this.currentRound.roundId;
    this.currentGoalAttempt.ordinal = this.goalAttemptNumber;
    this.moveNumber = 1;
    this.goalAttemptNumber++;
  }
}
