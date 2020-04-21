import { MoveModel } from "./move.model";
import { GoalAttemptModel } from "./goal-attempt.model";

export class RoundModel {
    public roundId: number;
    public gameId: number;
    public ordinal: number;
    public goalAttempts: GoalAttemptModel[];
}