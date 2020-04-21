import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { FieldPositionModel } from "src/models/field-position.model";
import { GameModel } from "src/models/game.model";
import { RoundModel } from "src/models/round.model";
import { GoalAttemptModel } from "src/models/goal-attempt.model";

export class GameController {
    private http: HttpClient;
    private baseUrl: string;

    constructor(http: HttpClient){
        this.http = http;
        this.baseUrl = 'api/Game/';
    }

    CreateGame(game: GameModel): Observable<GameModel>{
        return this.http.post<GameModel>(this.baseUrl + 'CreateGame', game);
    }

    CreateRound(round: RoundModel): Observable<RoundModel>{
        return this.http.post<RoundModel>(this.baseUrl + 'CreateRound', round);
    }

    CreateGoalAttempt(goalAttempt: GoalAttemptModel): Observable<GoalAttemptModel>{
        return this.http.post<GoalAttemptModel>(this.baseUrl + 'CreateGoalAttempt', goalAttempt);
    }
}