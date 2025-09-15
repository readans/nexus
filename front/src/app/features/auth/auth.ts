import { Component, DestroyRef, inject } from '@angular/core';
import { IconsModule } from '../../shared/components/icons/icons.module';
import { } from 'firebase/auth'
import { AuthService } from '../../core/services/auth.service';
import { Router } from '@angular/router';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { SessionService } from '../../core/services/session.service';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';

@Component({
  selector: 'app-auth',
  imports: [
    ReactiveFormsModule,
    IconsModule,
  ],
  templateUrl: './auth.html',
})
export class Auth {

  private destroyRef = inject(DestroyRef);

  loginForm = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', Validators.required)
  })

  constructor(
    private auth: AuthService,
    private session: SessionService,
    private router: Router
  ) { }

  onSignIn() {
    const { email, password } = this.loginForm.value
    this.auth.signIn(email || "", password || "")
      .pipe(takeUntilDestroyed(this.destroyRef))
      .subscribe({
        next: (result) => {
          const value = {
            "email": result.user.email || "",
            "uid": result.user.uid,
            "name": result.user.displayName,
            "photoUrl": result.user.photoURL
          }

          this.session.login(value)
            .pipe(takeUntilDestroyed(this.destroyRef))
            .subscribe({
              next: () => this.router.navigateByUrl('/dashboard')
            })
        }
      })
  }

  onGoogleSignIn() {
    this.auth.signInGoogle()
      .pipe(takeUntilDestroyed(this.destroyRef))
      .subscribe({
        next: (result) => {
          const value = {
            "email": result.user.email || "",
            "uid": result.user.uid,
            "name": result.user.displayName,
            "photoUrl": result.user.photoURL
          }

          this.session.login(value)
            .pipe(takeUntilDestroyed(this.destroyRef))
            .subscribe({
              next: () => this.router.navigateByUrl('/dashboard')
            })
        },
        error: (error) => {
          console.error('Google Sign-In error:', error);
        }
      })
  }

}
