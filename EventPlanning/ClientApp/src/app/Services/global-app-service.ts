import { Injectable } from '@angular/core';
import {User} from '../Interfaces/user.interface'

@Injectable()
export class GlobalAppService {
    public currentUser: User = null;
    public templatePath: string = "../assets/template.xlsx";
    public api: string = "http://localhost:4201/api/";
}