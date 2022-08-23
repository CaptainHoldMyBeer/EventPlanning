import { Component } from '@angular/core'
import { User } from '../Interfaces/user.interface'

@Component({
    selector: 'login.component',
    templateUrl: './login.component.html'
})
export class LoginComponent {
    public user: User;
}