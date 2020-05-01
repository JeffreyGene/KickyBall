import { Component } from '@angular/core';
import { Controllers } from 'src/controllers/controllers';
import { User } from 'src/models/user.model';
import { ApplicationSetting } from 'src/models/application-setting.model';

@Component({
  selector: 'admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent {
  controllers: Controllers;
  users: User[] = [];
  settings: ApplicationSetting[] = [];

  constructor(controllers: Controllers) {
    this.controllers = controllers;

    this.controllers.userController.GetUsers().subscribe(u => {
      this.users = u;
    });
    this.controllers.applicationSettingController.GetApplicationSettings().subscribe(s => {
      this.settings = s;
    });
  }

  updateSetting(setting: ApplicationSetting){
    this.controllers.applicationSettingController.UpdateSetting(setting).subscribe(s => {
      setting = s;
    });
  }
}
