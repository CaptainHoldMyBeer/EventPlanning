import { Injectable } from '@angular/core';
import {User} from '../Interfaces/user.interface'

@Injectable()
export class GlobalAppService {
    public isUserAuthenticated: boolean = false;
    public userId: number = 0;
    public templatePath: string = "../assets/template.xlsx";
    public api: string = "http://localhost:4201/api/";
}