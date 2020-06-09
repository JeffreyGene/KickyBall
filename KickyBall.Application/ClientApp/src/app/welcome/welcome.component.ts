import { Component, OnInit } from '@angular/core';
import { Controllers } from 'src/controllers/controllers';

@Component({
  selector: 'welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.scss']
})
export class WelcomeComponent implements OnInit {
  instructions: string;
  constructor(private controllers: Controllers){
    
  }

  ngOnInit() {
    this.controllers.applicationSettingController.GetWelcomeSetting().subscribe(instructions => {
      this.instructions = instructions;
    });
  }
}
