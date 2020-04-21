import { MoveModel } from "./move.model";
import { RoundModel } from "./round.model";

export class GameModel {
    public gameId: number;
    public personId: number;
    public rounds: RoundModel[];
}