import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { CreateEventComponent } from './create-event/create-event.component';
import { JoinEventComponent } from './join-event/join-event.component';
import { AddAdditionalInfoComponent } from './create-event/add-additional-info/add-additional-info.component';
import { UserEventsComponent } from './user-events/user-events.component';

import { LoginService } from './Services/login-service';
import { GlobalAppService } from './Services/global-app-service'
import { EventService } from './Services/event-service'

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { GridModule } from '@progress/kendo-angular-grid';
import { DialogsModule } from '@progress/kendo-angular-dialog';
import { UploadsModule } from '@progress/kendo-angular-upload';

import { UserRegistrationFormModel, UserLoginFormModel, EventFormModel } from './Models/form.models';
import { NavigateGuard } from "./Guards/navigate-guard";
import { RequestInterceptor } from "./Interceptors/requestInterceptor";


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    LoginComponent,
    RegistrationComponent,
    CreateEventComponent,
    JoinEventComponent,
    AddAdditionalInfoComponent,
    UserEventsComponent

  ],
  imports: [
      BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
      HttpClientModule, FormsModule, ReactiveFormsModule,
      RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'login', component: LoginComponent },
      { path: 'registration', component: RegistrationComponent },
      { path: 'join-event', component: JoinEventComponent, canActivate: [NavigateGuard] },
      { path: 'create-event', component: CreateEventComponent, canActivate: [NavigateGuard] },
      { path: 'user-events', component: UserEventsComponent, canActivate: [NavigateGuard] }
    ]),
      BrowserAnimationsModule, GridModule, DialogsModule, UploadsModule
    ],
    providers: [LoginService, GlobalAppService, EventService, UserRegistrationFormModel, UserLoginFormModel,
        EventFormModel, NavigateGuard, {
        provide: HTTP_INTERCEPTORS,
        useClass: RequestInterceptor,
        multi: true,
    }],
  bootstrap: [AppComponent]
})
export class AppModule { }
