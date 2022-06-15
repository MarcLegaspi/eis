import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { EmployeeCreateComponent } from "./employee-create/employee-create.component";
import { EmployeeListComponent } from "./employee-list/employee-list.component";
import { EmployeeUpdateComponent } from "./employee-update/employee-update.component";

const employeeRoutes: Routes = [
    // {
    //     path: '', 
    //     component: EmployeeListComponent,
    //     children: [
    //         { path: 'create', component:EmployeeCreateComponent }
    //     ]
    // }
    { path: '', component: EmployeeListComponent },
    { path: 'create', component: EmployeeCreateComponent },
    { path: ':id/update', component: EmployeeUpdateComponent }
]

@NgModule({
    imports: [RouterModule.forChild(employeeRoutes)],
    exports: [RouterModule]
})
export class EmployeeRoutingModule {

}