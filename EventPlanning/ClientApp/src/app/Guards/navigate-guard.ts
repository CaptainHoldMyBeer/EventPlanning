import { Injectable } from "@angular/core";
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { GlobalAppService } from '../Services/global-app-service';

@Injectable()
export class NavigateGuard implements CanActivate {
    constructor(public globalAppService: GlobalAppService) {}

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | boolean {
        if (!this.globalAppService.isUserAuthenticated) {
            alert("Need to login first!");
            return false;
        }
        return true;

    }
}