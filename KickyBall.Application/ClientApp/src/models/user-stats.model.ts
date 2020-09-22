import { RoundStats } from "./round-stats.model";

export class UserGameStats {
    public userId: number;
    public username: string;
    public firstName: string;
    public lastName: string;
    public gameFinished: boolean;
    public normalGoals: number;
    public normalAttempts: number;
    public practiceAttempts: number;
    public roundStats: RoundStats[];
}