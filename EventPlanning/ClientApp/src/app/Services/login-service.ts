import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { GlobalAppService } from '../Services/global-app-service';
import { User } from '../Interfaces/user.interface';
import { Observable} from 'rxjs';

@Injectable()
export class LoginService {

    private controllerPrefix: string = "auth/";

    constructor(private client: HttpClient, private appService: GlobalAppService) { }

    public createNewUser(newUser: User): Observable<number> {
        const headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
        const options = { headers: headers };

        return this.client.post<number>(this.appService.api + this.controllerPrefix + "register", newUser, options);
    }

    public loginUser(existedUser: User): Observable<number> {
        const headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
        const options = { headers: headers };

        return this.client.post<number>(this.appService.api + this.controllerPrefix + "login", existedUser, options);
    }
}