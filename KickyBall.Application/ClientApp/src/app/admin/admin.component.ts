import { Component } from '@angular/core';
import { Controllers } from 'src/controllers/controllers';
import { PersonModel } from 'src/models/person.model';

@Component({
  selector: 'admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent {
  controllers: Controllers;
  persons: PersonModel[] = [];
  constructor(controllers: Controllers) {
    this.controllers = controllers;

    this.controllers.userController.GetPersons().subscribe(p => {
      this.persons = p;
    });
  }
}
