import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { FieldPositionModel } from "src/models/field-position.model";
import { Game } from "src/models/game.model";
import { Round } from "src/models/round.model";
import { GoalAttempt } from "src/models/goal-attempt.model";
import { User } from "src/models/user.model";

export class UserController {
    private http: HttpClient;
    private baseUrl: string;

    constructor(http: HttpClient){
        this.http = http;
        this.baseUrl = 'api/User/';
    }

    GetUsers(): Observable<User[]>{
        return this.http.get<User[]>(this.baseUrl + 'GetUsers');
    }

    Register(username, password, firstName, lastName, registrationCode) {
        return this.http.post<any>(`api/User/Register`, { username, password, registrationCode, firstName, lastName });
    }
}