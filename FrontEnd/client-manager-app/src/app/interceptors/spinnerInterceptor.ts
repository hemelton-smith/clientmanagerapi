import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { finalize } from 'rxjs/operators';
import { SpinnerService } from '../services/spinner.service';

@Injectable()
export class SpinnerInterceptor implements HttpInterceptor {
  constructor(private readonly spinnerService: SpinnerService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const spinnerSubscription: Subscription = !req.headers.has('x-ingnore-spinner') ? this.spinnerService.spinner$.subscribe() : null;
    return next.handle(req).pipe(finalize(() => {
      if (spinnerSubscription) {
        spinnerSubscription.unsubscribe();
      }
    }));
  }
}
