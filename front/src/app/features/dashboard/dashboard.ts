import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Sidebar } from '../../shared/components/sidebar/sidebar';
import { Header } from '../../shared/components/header/header';
import { AuthService } from '../auth/services/auth.service';
import { AsyncPipe } from '@angular/common';

@Component({
  selector: 'app-dashboard',
  imports: [
    AsyncPipe,
    RouterOutlet,
    Sidebar,
    Header,
  ],
  templateUrl: './dashboard.html',
})
export class Dashboard {
  private auth = inject(AuthService);
  user$ = this.auth.user$;
}
