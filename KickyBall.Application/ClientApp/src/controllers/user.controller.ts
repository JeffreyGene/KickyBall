import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { FieldPositionModel } from "src/models/field-position.model";
import { GameModel } from "src/models/game.model";
import { RoundModel } from "src/models/round.model";
import { GoalAttemptModel } from "src/models/goal-attempt.model";
import { PersonModel } from "src/models/person.model";

export class UserController {
    private http: HttpClient;
    private baseUrl: string;

    constructor(http: HttpClient){
        this.http = http;
        this.baseUrl = 'api/User/';
    }

    GetPersons(): Observable<PersonModel[]>{
        return this.http.get<PersonModel[]>(this.baseUrl + 'GetPersons');
    }

    Register(username, password, registrationCode) {
        return this.http.post<any>(`api/User/Register`, { username, password, registrationCode });
    }
}