import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from '../../environments/environment';
import { IEmployee } from "../shared/models/employee";
import { IEmployeeForm } from "../shared/models/employee-form";
import { IPaginationData } from "../shared/models/pagination-data";

@Injectable({
    providedIn: 'root'
})
export class EmployeeService {
    constructor(private http: HttpClient) { }

    getEmployees(pageIndex: number, pageSize: number, search: string, departmentId: number) {
        let params = new HttpParams();

        params = params.append('pageSize', pageSize.toString());
        params = params.append('pageIndex', pageIndex.toString());

        if (search) {
            params = params.append("search", search);
        }

        if (departmentId && departmentId > 0) {
            params = params.append("departmentId", departmentId);
        }

        return this.http.get<IPaginationData<IEmployee>>(environment.baseApiUrl + 'employees', { 'params': params });
    }

    getEmployee(id: number) {
        return this.http.get<IEmployeeForm>(environment.baseApiUrl + 'employees/' + id);
    }

    create(employee: IEmployeeForm) {
        let headers = new HttpHeaders();
        headers = headers.append('content-type', 'application/json');

        return this.http.post<IEmployee>(environment.baseApiUrl + 'employees', employee,
            {
                headers: headers
            });
    }

    update(employee: IEmployeeForm) {
        let headers = new HttpHeaders();
        headers = headers.append('content-type', 'application/json');

        return this.http.put<IEmployee>(environment.baseApiUrl + 'employees/' + employee.id, employee,
            {
                headers: headers
            });
    }
}