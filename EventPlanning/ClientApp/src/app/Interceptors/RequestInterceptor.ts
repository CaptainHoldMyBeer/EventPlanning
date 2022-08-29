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
                if (error) {
                    if (error.status === 400) {
                        alert(error.error);
                    }
                    if (error.status === 500) {
                        alert("an unhandled error occurred");
                    }
                } else {
                    return throwError(error);
                }
            })
        ) as Observable<HttpEvent<any>>;
    }
}