import { Routes } from '@angular/router';
import { authGuard } from './core/guards/auth.guard';
import { notAuthGuard } from './core/guards/not-auth-guard';

export const routes: Routes = [
  {
    path: 'dashboard',
    loadComponent: () => import('./features/dashboard/dashboard').then(m => m.Dashboard),
    children: [
      {
        path: '',
        loadComponent: () => import('./features/dashboard/home/home').then(m => m.Home),
      },
      {
        path: 'students',
        loadComponent: () => import('./features/dashboard/students/students').then(m => m.Students),
        canActivate: [authGuard],
      },
      {
        path: 'professors',
        loadComponent: () => import('./features/dashboard/professors/professors').then(m => m.Professors),
        canActivate: [authGuard],
      },
      {
        path: 'enrollment/:id',
        loadComponent: () =>
          import('./features/dashboard/enrollment/enrollment').then(m => m.Enrollment),
        canActivate: [authGuard],
      }

    ],
    canActivate: [authGuard],
  },
  {
    path: 'auth',
    loadComponent: () => import('./features/auth/auth').then(m => m.Auth),
    canActivate: [notAuthGuard]
  },
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'dashboard',
  },
];
