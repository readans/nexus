import { Component, DestroyRef, inject } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { IconsModule } from '../icons/icons.module';
import { AuthService } from '../../../core/services/auth.service';
import { SessionService } from '../../../core/services/session.service';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';

export interface NavLink {
  name: string;
  href: string;
  icon: string;
}

@Component({
  selector: 'app-sidebar',
  imports: [
    RouterModule,
    IconsModule,
  ],
  templateUrl: './sidebar.html',
})
export class Sidebar {

  private destroyRef = inject(DestroyRef);

  constructor(
    private auth: AuthService,
    private session: SessionService,
    private router: Router
  ) { }

  links: NavLink[] = [
    { name: 'Estudiantes', href: 'students', icon: 'student' },
    { name: 'Profesores', href: 'professors', icon: 'professor' },
  ];

  onSignOut() {
    this.auth.signOut()
      .pipe(takeUntilDestroyed(this.destroyRef))
      .subscribe({
        next: () => {
          this.router.navigateByUrl('/auth')
          this.session.logout()
        }
      })
  }

}
