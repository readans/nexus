import { HttpHandlerFn, HttpInterceptorFn, HttpRequest } from "@angular/common/http";
import { inject } from "@angular/core";
import { AuthService } from "../../features/auth/services/auth.service";
import { switchMap } from "rxjs";

export const TokenInterceptor: HttpInterceptorFn = (req: HttpRequest<unknown>, next: HttpHandlerFn) => {
  const authService = inject(AuthService);

  return authService.idToken$.pipe(
    switchMap(token => {
      if (token) {
        const newReq = req.clone({
          setHeaders: {
            Authorization: `Bearer ${token}`
          }
        });
        return next(newReq);
      }
      return next(req);
    })
  );
};
