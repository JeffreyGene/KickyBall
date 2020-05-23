import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { FieldPosition } from "src/models/field-position.model";
import { Game } from "src/models/game.model";
import { Round } from "src/models/round.model";
import { GoalAttempt } from "src/models/goal-attempt.model";
import { User } from "src/models/user.model";
import { AdminPageUser } from "src/models/admin-page-user.model";
import { UserGameStats } from "src/models/user-stats.model";

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

    ResetPassword(userId, newPassword) {
        return this.http.post<any>(`api/User/ResetPassword`, { userId, newPassword });
    }

    GetUserGameStats(userId: number): Observable<UserGameStats>{
        return this.http.get<UserGameStats>(`${this.baseUrl}GetUserGameStats?userId=${userId}`);
    }
}