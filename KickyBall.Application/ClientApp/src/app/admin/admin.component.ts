import { Component } from '@angular/core';
import { Controllers } from 'src/controllers/controllers';
import { User } from 'src/models/user.model';

@Component({
  selector: 'admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent {
  controllers: Controllers;
  users: User[] = [];
  constructor(controllers: Controllers) {
    this.controllers = controllers;

    this.controllers.userController.GetUsers().subscribe(u => {
      this.users = u;
    });
  }
}
