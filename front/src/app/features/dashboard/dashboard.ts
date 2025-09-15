import { Component, DestroyRef, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Sidebar } from '../../shared/components/sidebar/sidebar';
import { Header } from '../../shared/components/header/header';
import { AuthService } from '../../core/services/auth.service';
import { AsyncPipe } from '@angular/common';
import { SessionService } from '../../core/services/session.service';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';

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
export class Dashboard implements OnInit {
  private destroyRef = inject(DestroyRef);
  private auth = inject(AuthService);
  private session = inject(SessionService);
  user$ = this.auth.user$;

  ngOnInit(): void {
    this.user$.pipe(takeUntilDestroyed(this.destroyRef)).subscribe({
      next: (user) => {
        if (!user) return

        const value = {
          "email": user.email || "",
          "uid": user.uid,
          "name": user.displayName,
          "photoUrl": user.photoURL
        }

        this.session.login(value).pipe(takeUntilDestroyed(this.destroyRef)).subscribe()
      }
    })
  }

}
