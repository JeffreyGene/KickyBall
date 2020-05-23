import { Controllers } from 'src/controllers/controllers';
import { ApplicationSetting } from 'src/models/application-setting.model';
import { AdminPageUser } from 'src/models/admin-page-user.model';
import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { UserGameStats } from 'src/models/user-stats.model';

@Component({
  selector: 'user-game-stats-modal',
  templateUrl: './user-game-stats.modal.html',
  styleUrls: ['./user-game-stats.modal.scss']
})
export class UserGameStatsModal implements OnInit {
    stats: UserGameStats;

    constructor(public controllers: Controllers, public dialogRef: MatDialogRef<UserGameStatsModal>,
        @Inject(MAT_DIALOG_DATA) public data: any) {
    }

    ngOnInit() {
        this.controllers.userController.GetUserGameStats(this.data.userId).subscribe(s => {
            this.stats = s;
        });
    }

    close() {
        this.dialogRef.close("done");
    }
}