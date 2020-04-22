import { Component } from '@angular/core';
import { Controllers } from 'src/controllers/controllers';
import { PersonModel } from 'src/models/person.model';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  controllers: Controllers;
  currentUser: PersonModel;

  constructor(controllers: Controllers){
    this.controllers = controllers;

    this.controllers.authenticationController.currentUser.subscribe(p => {
      this.currentUser = p;
    })
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
