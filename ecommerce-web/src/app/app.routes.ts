import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { redirectGuardGuard } from './redirect-guard.guard';
import { authGuard } from './auth.guard';
import { LoginComponent } from './auth/login/login.component';

export const routes: Routes = [
    {
        path: "",
        canActivate: [redirectGuardGuard],
        pathMatch: 'full',
        component: LoginComponent
    },
    {
        path: 'auth',
        loadChildren: () =>
            import('./auth/auth.module').then(m => m.AuthModule)
    },
    {
        path: 'home',
        loadChildren: () =>
            import('./home/home.module').then(m => m.HomeModule),
        canActivate: [authGuard]
    },
];

@NgModule({
    imports: [ RouterModule.forRoot(routes) ],
    exports: [ RouterModule ]
  })
  export class AppRoutingModule { }