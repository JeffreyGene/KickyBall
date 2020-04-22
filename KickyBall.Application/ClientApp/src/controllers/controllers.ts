import { FieldPositionController } from "./field-position.controller";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { GameController } from "./game.controller";
import { UserController } from "./user.controller";
import { AuthenticationController } from "./authentication.controller";

@Injectable()
export class Controllers {
    public fieldPositionController: FieldPositionController;
    public gameController: GameController;
    public userController: UserController;
    public authenticationController: AuthenticationController;

    constructor(http: HttpClient){
        this.fieldPositionController = new FieldPositionController(http);
        this.gameController = new GameController(http);
        this.userController = new UserController(http);
        this.authenticationController = new AuthenticationController(http);
    }
}