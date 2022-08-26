import { Component } from '@angular/core'
import { User } from '../Interfaces/user.interface'
import { GlobalAppService } from '../Services/global-app-service'
import { UserLoginFormModel } from '../Models/form.models';
import { FormControl } from '@angular/forms';
import { LoginService } from "../Services/login-service";

@Component({
    selector: 'login.component',
    templateUrl: './login.component.html'
})
export class LoginComponent {

    constructor(public globalService: GlobalAppService, public formModel: UserLoginFormModel, public loginService: LoginService ) { }

    public singIn() {
        var newUser: User = {
            Login: this.formModel.model.value.Login,
            Password: this.formModel.model.value.Password
        };


        this.loginService.loginUser(newUser).subscribe((response) => {
            if (response) {

            }
        });
    }
}