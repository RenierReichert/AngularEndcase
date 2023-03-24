import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpErrorResponse, HttpResponse, HttpHandler, HttpRequest } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { AppModule } from '../app.module';
import { InterceptorService } from '../services/interceptor.service';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {


  constructor(private intService: InterceptorService) {

  }

  // Version 1
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<any> {
    return next.handle(req).pipe(      
      catchError((error: any) => {
        if( !(error instanceof HttpErrorResponse))
        {
          console.log("CORRECT REPLY");
          return next.handle(req);
        }
        else
        {
        if (error.status < 500) {
          console.error('Interceptor zegt: Client error occurred:', error.error);
        } else if (error.status >= 500) {
          console.error('Interceptor zegt: Server error occurred:', error.error); 
        }
        let errorMessage: string = error.error;
        this.intService.setErrorMessage(errorMessage);
        return throwError(() => error);
      }
      })
    );
  }
  

  /*Version 2
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<any> {
    return next.handle(req).pipe(
      tap(event => {
        if (event instanceof HttpResponse) {
          this.intService.setErrorMessage("OK!")
          return next.handle(req);
        }
        else if (event instanceof HttpErrorResponse) {
          

          if (event.status < 500) {
              console.error('Interceptor zegt: Client error occurred:', error.error);
          } else if (event.status >= 500) {
              console.error('Interceptor zegt: Server error occurred:', error.error); 
          }
         

          let errorMessage: string = event.error.error;
          this.intService.setErrorMessage(errorMessage);
          return throwError(() => event);
        }
        else {
          console.log(event.type.toString())
          this.intService.setErrorMessage("Unknown error occured.")
          return throwError(() => event)
        }
      })
    );
  }
*/

}