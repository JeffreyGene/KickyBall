import { Move } from "./move.model";

export class GoalAttempt {
    public goalAttemptId: number;
    public roundId: number;
    public ordinal: number;
    public scoredGoal: boolean;
    public moves: Move[]; 
    public routeId: number;
}