import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpXsrfTokenExtractor
} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class TokenInterceptorInterceptor implements HttpInterceptor {

  constructor(private httpXsrfTokenExtractor: HttpXsrfTokenExtractor) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const cookieheaderToken = 'X-XSRF-TOKEN';
    let csrfToken = this.httpXsrfTokenExtractor.getToken();
    if (csrfToken !== null && !req.headers.has(cookieheaderToken)) {
        req = req.clone({
          withCredentials: true, 
          headers: req.headers.set(cookieheaderToken, csrfToken) 
        });
    }
    return next.handle(req);
  }
}
