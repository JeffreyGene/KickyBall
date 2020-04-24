import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { FieldPositionModel } from "src/models/field-position.model";
import { Game } from "src/models/game.model";
import { Round } from "src/models/round.model";
import { GoalAttempt } from "src/models/goal-attempt.model";
import { RecordGoalAttemptRequest } from "src/requests/recordGoalAttemptRequest";
import { userInfo } from "os";

export class GameController {
    private http: HttpClient;
    private baseUrl: string;

    constructor(http: HttpClient){
        this.http = http;
        this.baseUrl = 'api/Game/';
    }

    GetCurrentGame(userId: number): Observable<Game>{
        return this.http.get<Game>(this.baseUrl + 'GetCurrentGame?userId=' + userId);
    }

    GetGameGoals(gameId: number): Observable<number>{
        return this.http.get<number>(this.baseUrl + 'GetGameGoals?gameId=' + gameId);
    }

    GetRoundGoals(roundId: number): Observable<number>{
        return this.http.get<number>(this.baseUrl + 'GetRoundGoals?roundId=' + roundId);
    }

    CreateGame(game: Game): Observable<Game>{
        return this.http.post<Game>(this.baseUrl + 'CreateGame', game);
    }

    FinishGame(gameId: number): Observable<boolean>{
        return this.http.post<boolean>(this.baseUrl + 'FinishGame', gameId);
    }

    CreateRound(round: Round): Observable<Round>{
        return this.http.post<Round>(this.baseUrl + 'CreateRound', round);
    }

    FinishRound(roundId: number): Observable<boolean>{
        return this.http.post<boolean>(this.baseUrl + 'FinishRound', roundId);
    }

    RecordGoalAttempt(request: RecordGoalAttemptRequest): Observable<GoalAttempt>{
        return this.http.post<GoalAttempt>(this.baseUrl + 'RecordGoalAttempt', request);
    }
}