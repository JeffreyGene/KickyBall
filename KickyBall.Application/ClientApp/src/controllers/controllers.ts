import { FieldPositionController } from "./field-position.controller";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Injectable()
export class Controllers {
    public fieldPositionController: FieldPositionController;

    constructor(http: HttpClient){
        this.fieldPositionController = new FieldPositionController(http);
    }
}