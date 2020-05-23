import { Component } from '@angular/core';
import { Controllers } from 'src/controllers/controllers';
import { User } from 'src/models/user.model';
import { ApplicationSetting } from 'src/models/application-setting.model';
import { AdminPageUser } from 'src/models/admin-page-user.model';
import { MatDialog } from '@angular/material/dialog';
import { UserGameStatsModal } from './userGameStatsModal/user-game-stats.modal';

@Component({
  selector: 'admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent {
  controllers: Controllers;
  users: AdminPageUser[] = [];
  settings: ApplicationSetting[] = [];

  constructor(controllers: Controllers, public dialog: MatDialog) {
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

  openUserModal(userId: number){
    const dialogRef = this.dialog.open(UserGameStatsModal, {
      width: '50%',
      data: {userId: userId }
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      console.log(result);
    });
  }
}
