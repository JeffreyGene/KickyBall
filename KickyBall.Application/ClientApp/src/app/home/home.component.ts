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

  constructor(controllers: Controllers) {
    this.controllers = controllers;

    this.controllers.fieldPositionController.GetFieldPositions().subscribe(positions => {
      this.positions = positions;
    });
  }

  getWidth(fieldPositionId: number){
    console.log(fieldPositionId / Math.log(2));
    return 100 / Math.floor(fieldPositionId / Math.log(2));
  }
}
