import { Routes } from '@angular/router';
import { authGuard } from './core/guards/auth.guard';

export const routes: Routes = [
  {
    path: 'dashboard',
    loadComponent: () => import('./features/dashboard/dashboard').then(m => m.Dashboard),
    children: [
      {
        path: '',
        loadComponent: () => import('./features/home/home').then(m => m.Home),
      },
      {
        path: 'students',
        loadComponent: () => import('./features/students/students').then(m => m.Students),
        canActivate: [authGuard],
      },
      {
        path: 'professors',
        loadComponent: () => import('./features/professors/professors').then(m => m.Professors),
        canActivate: [authGuard],
      },
    ],
    canActivate: [authGuard],
  },
  {
    path: 'auth',
    loadComponent: () => import('./features/auth/auth').then(m => m.Auth),
  },
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'dashboard',
  },
];
