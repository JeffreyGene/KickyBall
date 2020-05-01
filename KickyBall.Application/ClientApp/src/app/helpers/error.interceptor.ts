import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { Controllers } from 'src/controllers/controllers';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    constructor(private controllers: Controllers) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(catchError(err => {
            if (err.status === 401 || err.status == 403) {
                this.controllers.authenticationController.logout();
                location.reload(true);
            }

            const error = err.error ? err.error.message || err.statusText : err.statusText;
            return throwError(error);
        }))
    }
}