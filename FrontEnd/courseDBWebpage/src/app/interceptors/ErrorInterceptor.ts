import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpErrorResponse, HttpResponse,HttpHandler,HttpRequest } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AppModule } from '../app.module';
import { InterceptorService } from '../services/interceptor.service';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {


  constructor(private intService: InterceptorService)
  {

  }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<any> {
    return next.handle(req).pipe(      
      catchError((error: any) => {
        if( !(error instanceof HttpErrorResponse))
        {
          return next.handle(req);
        }
        else
        {
        if (error.status < 500) {
          console.error('Interceptor zegt: Client error occurred:', error.error);
        } else if (error.status >= 500) {
          console.error('Interceptor zegt: Server error occurred:', error.error); 
        }
        let errorMessage: string = error.statusText;
        this.intService.setErrorMessage(errorMessage);
        return throwError(() => error);
      }
      })
    );
  }
}