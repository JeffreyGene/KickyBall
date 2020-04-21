import { FieldPositionController } from "./field-position.controller";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { GameController } from "./game.controller";

@Injectable()
export class Controllers {
    public fieldPositionController: FieldPositionController;
    public gameController: GameController;

    constructor(http: HttpClient){
        this.fieldPositionController = new FieldPositionController(http);
        this.gameController = new GameController(http);
    }
}