import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
//import { EmployeeModule } from './employee/employee.module';
import { HeaderComponent } from './header/header.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { Interceptor } from './core/interceptor';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent
  ],
  imports: [
    BrowserModule,
    RouterModule,
    AppRoutingModule,
    NgbModule,
    HttpClientModule
  ],
  providers: [ 
    { provide: HTTP_INTERCEPTORS, useClass: Interceptor, multi:true }],
  bootstrap: [AppComponent]
})
export class AppModule { }
