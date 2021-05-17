import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { MessageService } from 'primeng/api';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private messageService: MessageService) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {

    return next.handle(request).pipe(catchError(err => {

      switch (err.status) {

        case 400:
        case 404:
        case 500:         
          this.messageService.add({ severity: 'error', summary: 'error', detail: 'An error occurred while processing your request. Please See the console for more details.' });
          break;
      }

      return throwError(err);
    }));

  }
}
