import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { EmployeeRoutingModule } from './employee-routing.module';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';
import { LookupService } from '../shared/lookup.service';
import { EmployeeCreateComponent } from './employee-create/employee-create.component';
import { EmployeeUpdateComponent } from './employee-update/employee-update.component';
import { NgbDatepicker, NgbModule } from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  declarations: [
    EmployeeCreateComponent,
    EmployeeListComponent,
    EmployeeUpdateComponent
  ],
  imports: [
    ReactiveFormsModule,
    EmployeeRoutingModule,
    FormsModule,
    CommonModule,
    SharedModule
  ],
  providers: [
    LookupService
  ]
})
export class EmployeeModule { }
