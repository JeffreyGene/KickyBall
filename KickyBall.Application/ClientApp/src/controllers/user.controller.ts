import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { FieldPosition } from "src/models/field-position.model";
import { Game } from "src/models/game.model";
import { Round } from "src/models/round.model";
import { GoalAttempt } from "src/models/goal-attempt.model";
import { User } from "src/models/user.model";
import { AdminPageUser } from "src/models/admin-page-user.model";

export class UserController {
    private http: HttpClient;
    private baseUrl: string;

    constructor(http: HttpClient){
        this.http = http;
        this.baseUrl = 'api/User/';
    }

    GetUsers(): Observable<AdminPageUser[]>{
        return this.http.get<AdminPageUser[]>(this.baseUrl + 'GetUsers');
    }

    Register(username, password, firstName, lastName, registrationCode) {
        return this.http.post<any>(`api/User/Register`, { username, password, registrationCode, firstName, lastName });
    }

    GetUserGameStats(userId: number): Observable<any>{
        return this.http.get<any>(`${this.baseUrl}GetUserGameStats?userId=${userId}`);
    }
}