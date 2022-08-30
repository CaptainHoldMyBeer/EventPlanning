import { Component, OnInit } from '@angular/core';
import { GlobalAppService } from '../Services/global-app-service';
import { LoginService } from '../Services/login-service';
import { User } from '../Interfaces/user.interface';
import { UserRegistrationFormModel } from '../Models/form.models';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';


@Component({
    selector: 'registration.component',
    templateUrl: './registration.component.html'
})
export class RegistrationComponent implements OnInit {

    constructor(public globalService: GlobalAppService, public formModel: UserRegistrationFormModel, public loginService: LoginService, private router: Router) { }

    ngOnInit(): void {
    }

    get registerFormControl() {
        return this.formModel.model.controls;
    }

    public onRegister() {
        if (!this.credentialsValid)
            return;

        var newUser: User = {
            Email: this.formModel.model.value.Email,
            Login: this.formModel.model.value.Login,
            Password: this.formModel.model.value.Password,
            Age: this.formModel.model.value.Age,
            Location: this.formModel.model.value.Location,
            Name: this.formModel.model.value.Name,
            Surname: this.formModel.model.value.Surname
        };

        this.loginService.createNewUser(newUser).subscribe((addedId) => {
            if (addedId) {
                this.globalService.isUserAuthenticated = true;
                this.globalService.userId = addedId;
                alert("Welcome");
                this.router.navigate(['/']);
            }
        });
    }
  

    private credentialsValid(): boolean {
        if (this.formModel.model.value.Password !== this.formModel.model.value.ConfirmedPassword) {
            alert("Passwords must match");
            return false;
        }

        return true;
    }
}