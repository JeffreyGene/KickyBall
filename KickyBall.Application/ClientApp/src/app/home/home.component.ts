import { Component, HostListener } from '@angular/core';
import { Controllers } from 'src/controllers/controllers';
import { FieldPositionModel } from 'src/models/field-position.model';
import { timer, Observable, Subscription } from 'rxjs';
import { Key } from 'protractor';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  ROUND_TIME: number = 300
  controllers: Controllers;
  positions: FieldPositionModel[];
  currentPosition: number = 1;
  activePositions: number[] = [2, 3];
  showRestartButton: boolean = false;
  gameStarted: boolean = false;
  roundStarted: boolean = false;
  timerSubscription: Subscription;
  timeLeftForRound: number = this.ROUND_TIME;
  goalsThisRound: number = 0;
  endPositionsThisRound: number[] = [];
  scoreText: string = null;

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

  moveWithKeys(direction){
    console.log(direction);
  }

  startGame(){
    this.gameStarted = true;
    this.startRound();
  }

  startRound(){
    this.resetFieldPosition();
    this.timeLeftForRound = this.ROUND_TIME;
    this.goalsThisRound = 0;
    this.endPositionsThisRound = [];
    this.roundStarted = true;
    this.timerSubscription = timer(0, 1000).subscribe(seconds =>  {
      this.timeLeftForRound--;
      if(this.timeLeftForRound == 0){
        this.endRound();
      }
    });
  }

  endRound(){
    this.timerSubscription.unsubscribe();
    this.roundStarted = false;
    this.showRestartButton = false;
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
    this.scoreText = 'No goal.'
    if(!this.endPositionsThisRound.some(p => p == fieldPositionId)){
      this.scoreText = 'GOAL!';
      this.goalsThisRound++;
    }
    this.endPositionsThisRound.push(fieldPositionId);
  }

  moveToPosition(position: FieldPositionModel){
    if(!this.roundStarted){
      return;
    }
    this.currentPosition = position.fieldPositionId;
    this.activePositions = [position.leftFieldPositionId, position.rightFieldPositionId];
    if(this.currentPosition > 31){
      //Save last position and restart
      this.showRestartButton = true;
      this.setScore(this.currentPosition)
    }
  }

  resetFieldPosition(){
    this.currentPosition = 1;
    this.activePositions = [2, 3];
    this.showRestartButton = false;
    this.scoreText = null;
  }
}
