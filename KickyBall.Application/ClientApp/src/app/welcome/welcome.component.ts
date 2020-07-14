import { Component, OnInit } from '@angular/core';
import { Controllers } from 'src/controllers/controllers';

@Component({
  selector: 'welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.scss']
})
export class WelcomeComponent implements OnInit {
  // public instructions: any;
  constructor(private controllers: Controllers){
    
  }

  ngOnInit() {
    // console.log(window.navigator.userAgent);
    // this.controllers.applicationSettingController.GetWelcomeSetting().subscribe(g => {
    //   this.instructions = g;
    // });
  }
}
