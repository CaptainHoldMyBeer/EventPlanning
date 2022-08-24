import { Component } from '@angular/core'
import { User } from '../Interfaces/user.interface'
import { GlobalAppService } from '../Services/global-app-service'

@Component({
    selector: 'login.component',
    templateUrl: './login.component.html'
})
export class LoginComponent {

    constructor(public globalService: GlobalAppService) { }

    public singIn() {
    }
}