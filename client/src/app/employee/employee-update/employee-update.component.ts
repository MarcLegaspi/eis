import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { contactPersonRelationshipEnum } from 'src/app/shared/enums/contactPersonRelationshipEnum';
import { LookupService } from 'src/app/shared/lookup.service';
import { IEmployeeForm } from 'src/app/shared/models/employee-form';
import { IPosition } from 'src/app/shared/models/position';
import { EmployeeService } from '../employee.service';

@Component({
  selector: 'app-employee-update',
  templateUrl: './employee-update.component.html',
  styleUrls: ['./employee-update.component.css']
})
export class EmployeeUpdateComponent implements OnInit {
  employeeForm = new FormGroup({
    'id': new FormControl(null, Validators.required),
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

  constructor(
    private employeeService: EmployeeService,
    private router: Router,
    private lookupService: LookupService,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    let relationships = Object.entries(contactPersonRelationshipEnum).map(([key, value]) => ({ key, value }));
    this.relationships = [{ key: '', value: '' }, ...relationships];

    this.setLookUps();

    const id = this.route.snapshot.params['id'];
    this.employeeService.getEmployee(id).subscribe(response => {
      this.employeeForm.get('id')?.patchValue(response.id);
      this.employeeForm.get('employeeNumber')?.patchValue(response.employeeNumber);
      this.employeeForm.get('positionId')?.patchValue(response.positionId);
      this.employeeForm.get('dateHired')?.patchValue(response.dateHired.toString().substring(0,10));
      this.employeeForm.get('lastName')?.patchValue(response.lastName);
      this.employeeForm.get('firstName')?.patchValue(response.firstName);
      this.employeeForm.get('middleName')?.patchValue(response.middleName);
      this.employeeForm.get('suffixName')?.patchValue(response.suffixName);
      this.employeeForm.get('birthDate')?.patchValue(response.birthDate.toString().substring(0,10));

      
      this.employeeForm.get('philhealthNo')?.patchValue(response.philhealthNo);
      this.employeeForm.get('tin')?.patchValue(response.tin);
      this.employeeForm.get('sss')?.patchValue(response.sss);
      this.employeeForm.get('pagibig')?.patchValue(response.pagibig);
      this.employeeForm.get('gsis')?.patchValue(response.gsis);
      
      this.employeeForm.get('telephoneNumber')?.patchValue(response.telephoneNumber);
      this.employeeForm.get('cellphoneNumber')?.patchValue(response.cellphoneNumber);
      this.employeeForm.get('email')?.patchValue(response.email);
      this.employeeForm.get('companyEmail')?.patchValue(response.companyEmail);
      this.employeeForm.get('contactPerson')?.patchValue(response.contactPerson);
      this.employeeForm.get('contactPersonCellphoneNumber')?.patchValue(response.contactPersonCellphoneNumber);
      this.employeeForm.get('contactPersonRelationship')?.patchValue(response.contactPersonRelationship);

      this.employeeForm.get('employeeAddress.address1')?.patchValue(response.employeeAddress?.address1);
      this.employeeForm.get('employeeAddress.barangay')?.patchValue(response.employeeAddress?.barangay);
      this.employeeForm.get('employeeAddress.municipality')?.patchValue(response.employeeAddress?.municipality);
      this.employeeForm.get('employeeAddress.province')?.patchValue(response.employeeAddress?.province);
    })
  }

  onSubmit() {
    if (this.employeeForm.valid) {
      const employee = this.employeeForm.value as IEmployeeForm;

      const y = 0;

      this.employeeService.update(employee).subscribe(
        response => {
          confirm(employee.lastName + ' ' + employee.firstName + ' ' + employee.middleName + ' successfully updated');
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
    this.router.navigate(['/employee-list'])
  }

  // onClick() {
  //   this.employeeForm.markAllAsTouched();
  //   this.employeeForm.markAsDirty();
  // }
}
