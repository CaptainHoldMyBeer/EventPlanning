import { Component, OnInit } from '@angular/core'
import { User } from '../Interfaces/user.interface'
import { GlobalAppService } from '../Services/global-app-service'
import { UserLoginFormModel } from '../Models/form.models';
import { FormControl } from '@angular/forms';
import { LoginService } from "../Services/login-service";
import { Router } from '@angular/router';

@Component({
    selector: 'login.component',
    templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {


    constructor(public globalService: GlobalAppService, public formModel: UserLoginFormModel, public loginService: LoginService, private router: Router ) { }

    ngOnInit(): void {

    }

    get loginFormControl() {
        return this.formModel.model.controls;
    }

    public singIn() {
        var newUser: User = {
            Login: this.formModel.model.value.Login,
            Password: this.formModel.model.value.Password
        };

        this.loginService.loginUser(newUser).subscribe((response) => {
            if (response !== 0) {
                this.globalService.isUserAuthenticated = true;
                this.globalService.userId = response;
                alert("Welcome");
                this.router.navigate(['/user-events']);
            } else {
                alert("Error. Try one more time");
            }
        });
    }
}