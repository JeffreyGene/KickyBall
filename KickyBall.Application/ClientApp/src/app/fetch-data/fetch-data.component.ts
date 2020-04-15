import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[];
  public fileToUpload: any;
  public url: any;
  public files: any = [];
  public http: HttpClient;
  baseUrl: string;


  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    http.get<WeatherForecast[]>(baseUrl + 'weatherforecast').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }

  onSelectFile(files) {
    console.log(files);

    if (files.length === 0)
      return;
  
    this.fileToUpload = files.item(0);
  
  
    const fileReader: FileReader = new FileReader();
    fileReader.readAsDataURL(this.fileToUpload);
  
    fileReader.onload = (event: any) => {
      this.url = event.target.result;
    };
  
    this.files.push({ data: this.fileToUpload, fileName: this.fileToUpload.name });
    
    this.http.post('api/Property/UploadPropertyPicture', this.files[0]).subscribe(result => {
      console.log(result);
    });
    // this._userService.uploadProfilePicture(this.files[0])
    //   .subscribe((result: string) => {
    //     this.userDetails.profileImageUrl = result;
    // });
  }
  
  delete() {
    this.url = null;
  }
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
