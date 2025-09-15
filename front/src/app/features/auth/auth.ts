import { Component } from '@angular/core';
import { IconsModule } from '../../shared/components/icons/icons.module';
import { } from 'firebase/auth'
import { AuthService } from './services/auth.service';
import { Router } from '@angular/router';
import { ApiService } from '../../core/services/api.service';
import { Student } from '../home/models/student';
import { UserService } from './services/user.service';

@Component({
  selector: 'app-auth',
  imports: [IconsModule],
  templateUrl: './auth.html',
})
export class Auth {

  constructor(
    private auth: AuthService,
    private user: UserService,
    private api: ApiService,
    private router: Router
  ) { }

  onGoogleSignIn() {
    this.auth.googleLogin().subscribe({
      next: (result) => {
        this.api.post<Student>('auth', {
          "email": result.user.email,
          "uid": result.user.uid,
          "name": result.user.displayName,
          "photoUrl": result.user.photoURL
        })
          .subscribe({
            next: (student: Student) => {
              this.user.user = student
              this.router.navigateByUrl('/');
            }
          })
      },
      error: (error) => {
        console.error('Google Sign-In error:', error);
      }
    })
  }


}
