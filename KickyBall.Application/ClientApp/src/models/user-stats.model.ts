import { RoundStats } from "./round-stats.model";

export class UserGameStats {
    public userId: number;
    public username: string;
    public firstName: string;
    public lastName: string;
    public gameFinished: boolean;
    public goals: number;
    public practiceGoals: number;
    public roundStats: RoundStats[];
}