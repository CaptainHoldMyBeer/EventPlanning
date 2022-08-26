import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { GlobalAppService } from '../Services/global-app-service';
import { User } from '../Interfaces/user.interface';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';


@Injectable()
export class LoginService {

    private controllerPrefix: string = "auth/"

    constructor(private client: HttpClient, private appService: GlobalAppService) { }

    public createNewUser(newUser: User): Observable<User> {
        const headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
        const options = { headers: headers };
        //return this.client
        //    .post<User>(this.appService.api + this.controllerPrefix, newUser, options).pipe(catchError(alert("Ошибка")));

        return this.client.post<User>(this.appService.api + this.controllerPrefix + "register", newUser, options);
    }
}