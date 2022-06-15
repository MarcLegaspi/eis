import { NgModule } from "@angular/core";
import { NgbPaginationModule } from "@ng-bootstrap/ng-bootstrap";
import { LookupService } from "./lookup.service";
import { PaginationComponent } from "./pagination/pagination.component";

@NgModule({
    declarations: [
        PaginationComponent
    ],
    imports: [
        NgbPaginationModule
    ],
    exports: [
        PaginationComponent,
        NgbPaginationModule
    ]
})
export class SharedModule {

}