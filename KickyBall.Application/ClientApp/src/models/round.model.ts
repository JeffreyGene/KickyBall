import { Move } from "./move.model";
import { GoalAttempt } from "./goal-attempt.model";

export class Round {
    public roundId: number;
    public gameId: number;
    public ordinal: number;
    public secondsRemaining: number;
    public finished: boolean = false;
    public practice: boolean;
    public goalAttempts: GoalAttempt[];
}