import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { FieldPosition } from "src/models/field-position.model";
import { Game } from "src/models/game.model";
import { Round } from "src/models/round.model";
import { GoalAttempt } from "src/models/goal-attempt.model";
import { User } from "src/models/user.model";
import { ApplicationSetting } from "src/models/application-setting.model";

export class ApplicationSettingController {
    private http: HttpClient;
    private baseUrl: string;

    constructor(http: HttpClient){
        this.http = http;
        this.baseUrl = 'api/ApplicationSetting/';
    }

    GetApplicationSettings(): Observable<ApplicationSetting[]>{
        return this.http.get<ApplicationSetting[]>(this.baseUrl + 'GetApplicationSettings');
    }

    GetGameSettings(): Observable<ApplicationSetting[]>{
        return this.http.get<ApplicationSetting[]>(this.baseUrl + 'GetGameSettings');
    }

    UpdateSetting(setting: ApplicationSetting): Observable<ApplicationSetting>{
        return this.http.post<ApplicationSetting>(this.baseUrl + 'UpdateSetting', setting);
    }
}