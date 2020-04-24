import { Component } from '@angular/core';
import { Controllers } from 'src/controllers/controllers';
import { User } from 'src/models/user.model';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.scss']
})
export class NavMenuComponent {
  isExpanded = false;
  controllers: Controllers;
  currentUser: User;

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

  logout() {
    this.controllers.authenticationController.logout();
  }
}
