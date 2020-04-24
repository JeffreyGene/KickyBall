import { MoveModel } from "./move.model";
import { Round } from "./round.model";

export class Game {
    public gameId: number;
    public userId: number;
    public finished: boolean;
    public rounds: Round[];
}