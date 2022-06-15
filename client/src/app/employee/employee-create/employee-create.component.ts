import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { contactPersonRelationshipEnum } from 'src/app/shared/enums/contactPersonRelationshipEnum';
import { LookupService } from 'src/app/shared/lookup.service';
import { IEmployeeForm } from 'src/app/shared/models/employee-form';
import { IPosition } from 'src/app/shared/models/position';
import { EmployeeService } from '../employee.service';

@Component({
  selector: 'app-employee-create',
  templateUrl: './employee-create.component.html',
  styleUrls: ['./employee-create.component.css']
})
export class EmployeeCreateComponent implements OnInit {
  employeeForm = new FormGroup({
    'employeeNumber': new FormControl('0011', Validators.required),
    'lastName': new FormControl('', Validators.required),
    'firstName': new FormControl('', Validators.required),
    'middleName': new FormControl(null),
    'suffixName': new FormControl(null),
    'birthDate': new FormControl(null, Validators.required),
    'philhealthNo': new FormControl(null),
    'tin': new FormControl(null),
    'sss': new FormControl(null),
    'gsis': new FormControl(null),
    'pagibig': new FormControl(null),
    'dateHired': new FormControl(null, Validators.required),
    'positionId': new FormControl(null, Validators.required),
    'email': new FormControl(null, Validators.email),
    'contactPerson': new FormControl(null),
    'contactPersonCellphoneNumber': new FormControl(null),
    'contactPersonRelationship': new FormControl(0),
    'cellphoneNumber': new FormControl(null),
    'telephoneNumber': new FormControl(null),
    'companyEmail': new FormControl(null, Validators.email),
    'employeeAddress': new FormGroup({
      'address1': new FormControl(null, Validators.required),
      'barangay': new FormControl(null, Validators.required),
      'municipality': new FormControl(null, Validators.required),
      'province': new FormControl(null, Validators.required)
    })
  });

  relationships: any;
  positions: IPosition[] = [];

  constructor(private employeeService: EmployeeService, private router: Router, private lookupService: LookupService) { }

  ngOnInit(): void {
    let relationships = Object.entries(contactPersonRelationshipEnum).map(([key, value]) => ({ key, value }));
    this.relationships = [{ key: '', value: ''}, ...relationships];
    
    this.setLookUps();
  }

  onSubmit() {
    if(this.employeeForm.valid) {
      const employee = this.employeeForm.value as IEmployeeForm;
      
      const y = 0;
  
      this.employeeService.create(employee).subscribe(
        response => {
          confirm(employee.lastName + ' ' + employee.firstName + ' ' + employee.middleName + ' successfully created');
          this.router.navigate(['/employee-list']);
          console.log(response);
        }, error => {
          console.log(error);
        }
      )
    }
  }

  onChangeRelationship(value: any) {
    this.employeeForm.get('contactPersonRelationship')?.setValue(+(value.value));
  }

  setLookUps() {
    this.lookupService.getPositions().subscribe(response => {
        this.positions = response;
    })
  }

  onCancel() {
    this.router.navigate(['/employee-list']);
  }
}