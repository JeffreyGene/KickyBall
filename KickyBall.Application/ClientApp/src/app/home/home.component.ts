import { Component } from '@angular/core';
import { Controllers } from 'src/controllers/controllers';
import { FieldPositionModel } from 'src/models/field-position.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  controllers: Controllers;
  positions: FieldPositionModel[];
  currentPosition: number = 1;
  activePositions: number[] = [2, 3];
  showRestartButton: boolean = false;


  constructor(controllers: Controllers) {
    this.controllers = controllers;

    this.controllers.fieldPositionController.GetFieldPositions().subscribe(positions => {
      this.positions = positions;
    });
  }

  getWidth(fieldPositionId: number){
    let result = 100 / Math.pow(2, Math.floor(Math.log(fieldPositionId)/Math.log(2)));
    console.log(result);
    return result;
  }

  isPositionDisabled(fieldPositionId){
    return !this.activePositions.some(p => p == fieldPositionId);
  }

  moveToPosition(position: FieldPositionModel){
    this.currentPosition = position.fieldPositionId;
    this.activePositions = [position.leftFieldPositionId, position.rightFieldPositionId];
    if(this.currentPosition > 31){
      //Save last position and restart
      this.showRestartButton = true;
    }
  }

  resetFieldPosition(){
    this.currentPosition = 1;
    this.activePositions = [2, 3];
    this.showRestartButton = false;
  }
}
