import { Injectable } from '@angular/core';
import {User} from '../Interfaces/user.interface'

@Injectable()
export class GlobalAppService {
    public currentUser: User = null;
}