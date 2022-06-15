import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Observable } from "rxjs";


export class Interceptor implements HttpInterceptor {
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const token = 'eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Im1hcmNlcmlja3NvbmxlZ2FzcGlAZ21haWwuY29tIiwicm9sZSI6IkVtcGxveWVlIiwibmJmIjoxNjU1MjcwMzM3LCJleHAiOjE2NTUzMDYzMzcsImlhdCI6MTY1NTI3MDMzNywiaXNzIjoidGVzdCBpc3N1ZXIifQ.po5e71LqC1hIm7QcxW9REByDYNu_LmtAiggRpXx8bMGSIzRjUFwvPu5zDQ53_USNWLDpNGLUdS85xHWzVtmacw';

        req = req.clone({
            setHeaders: {
                'authorization': 'bearer ' + token 
            }
        });

        return next.handle(req);
    }
}