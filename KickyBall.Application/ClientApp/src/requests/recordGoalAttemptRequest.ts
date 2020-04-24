import { GoalAttempt } from "src/models/goal-attempt.model";

export class RecordGoalAttemptRequest {
    public secondsRemaining: number;
    public goalAttempt: GoalAttempt;
}