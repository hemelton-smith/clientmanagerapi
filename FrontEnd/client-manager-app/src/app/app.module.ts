import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ClientComponent } from './components/client/client.component';
import { ShowClientComponent } from './components/client/show-client/show-client.component';
import { AddEditClientComponent } from './components/client/Add-edit-client/add-edit-client.component';
import { ClientService } from './services/client.service';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import {MatInputModule} from '@angular/material/input';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { SpinnerComponent } from './spinner/spinner.component';
import { SpinnerInterceptor } from './interceptors/spinnerInterceptor';
import { OverlayModule } from '@angular/cdk/overlay';

@NgModule({
  declarations: [
    AppComponent,
    ClientComponent,
    ShowClientComponent,
    AddEditClientComponent,
    SpinnerComponent
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MatProgressSpinnerModule,
    BrowserAnimationsModule,
    OverlayModule,
    MatInputModule
  ],
  providers: [ClientService , 
    { provide: HTTP_INTERCEPTORS, useClass: SpinnerInterceptor, multi: true },],
  bootstrap: [AppComponent]
})
export class AppModule { }
