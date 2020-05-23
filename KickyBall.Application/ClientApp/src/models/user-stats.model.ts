import { RoundStats } from "./round-stats.model";

export class UserGameStats {
    public userId: number;
    public username: string;
    public firstName: string;
    public lastName: string;
    public isAdmin: boolean;
    public roundStats: RoundStats[];
}