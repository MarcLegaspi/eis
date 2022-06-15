import { Component, OnInit } from '@angular/core';
import { LookupService } from 'src/app/shared/lookup.service';
import { IDepartment } from 'src/app/shared/models/department';
import { IEmployee } from 'src/app/shared/models/employee';
import { environment } from 'src/environments/environment';
import { EmployeeService } from '../employee.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {
  pageIndex = 1;
  pageSize = environment.pageSize;
  search = '';
  departmentId = 0;
  listCount = 5;
  
  employees: IEmployee[] = [];
  departments: IDepartment[] = [];

  constructor(private employeeService: EmployeeService, private lookupService: LookupService) { }

  ngOnInit(): void {
    this.getEmployees();
    this.setLookUps();
  }

  getEmployees() {
    this.employeeService.getEmployees(this.pageIndex, this.pageSize, this.search,this.departmentId).subscribe(response => {
      this.employees = response.data;
      this.listCount = response.count;
    })
  }

  setLookUps() {
    this.lookupService.getDepartments().subscribe(response => {
        this.departments = [{ id:0, name:"All Departments", code:"All" },...response];
    })
  }

  onSearch() {
    this.pageIndex = 1;
    this.getEmployees();
  }

  onReset() {
    this.pageIndex = 1;
    this.pageSize = environment.pageSize;
    this.search = '';
    this.departmentId = 0;
    this.getEmployees();
  }

  onPageChanged(page: number) {
    this.pageIndex = page;
    this.getEmployees();
  }

  onFilterDepartment() {
    this.pageIndex = 1;
    this.getEmployees();
  }
}
