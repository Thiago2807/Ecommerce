import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from './auth/auth.service';

export const redirectGuardGuard: CanActivateFn = (route, state) => {
  const authServices = inject(AuthService)
  const routes = inject(Router);

  if (authServices.hasToken()) {
    routes.navigate(['/home/']);
  }
  else {
    routes.navigate(['/auth/login']);
  }

  return false;
};
