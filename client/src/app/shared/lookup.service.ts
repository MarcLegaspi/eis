import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { IDepartment } from "./models/department";
import { IPosition } from "./models/position";

@Injectable()
export class LookupService {
    constructor(private http: HttpClient) {
    }

    getDepartments() {
        return this.http.get<IDepartment[]>(environment.baseApiUrl + 'departments');
    }   

    getPositions() {
        return this.http.get<IPosition[]>(environment.baseApiUrl + 'positions');        
    }
}