import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { FieldPositionModel } from "src/models/field-position.model";

export class FieldPositionController {
    private http: HttpClient;
    private baseUrl: string;

    constructor(http: HttpClient){
        this.http = http;
        this.baseUrl = 'api/FieldPosition/';
    }

    GetFieldPositions(): Observable<FieldPositionModel[]>{
        return this.http.get<FieldPositionModel[]>(this.baseUrl + 'GetFieldPositions');
    }
}