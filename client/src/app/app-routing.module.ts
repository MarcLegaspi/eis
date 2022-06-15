import { NgModule } from "@angular/core";
import { PreloadAllModules, RouterModule, Routes } from "@angular/router";
import { EmployeeListComponent } from "./employee/employee-list/employee-list.component";

const routes: Routes = [
    { 
        path: '', 
        redirectTo: '/employee-list', 
        pathMatch: 'full' 
    },        
    {
        path: 'employee-list',
        loadChildren: () => import('./employee/employee.module').then(m => m.EmployeeModule)
    }
]

@NgModule({
    imports: [RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })],
    exports: [RouterModule]
})
export class AppRoutingModule {

}