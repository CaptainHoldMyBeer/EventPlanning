import { Component } from '@angular/core';
import { GlobalAppService } from "../Services/global-app-service";


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

    public isUserAuthenticated: boolean = this.globalApp.isUserAuthenticated;

    constructor(public globalApp: GlobalAppService){}
}
