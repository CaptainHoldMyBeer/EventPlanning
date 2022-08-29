import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { throwError } from "rxjs/internal/observable/throwError";
import { catchError } from "rxjs/operators";

@Injectable()
export class RequestInterceptor implements HttpInterceptor {

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(
            catchError((error: HttpErrorResponse) => {
                if (error && error.status === 401) {
                    let tmp = 2;
                } else {
                    return throwError(error);
                }
            })
        ) as Observable<HttpEvent<any>>;
    }
}