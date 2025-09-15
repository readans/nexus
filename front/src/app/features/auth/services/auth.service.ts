import { inject, Injectable } from '@angular/core';
import { Auth, GoogleAuthProvider, idToken, signInWithEmailAndPassword, signInWithPopup, signOut, user } from '@angular/fire/auth';
import { browserSessionPersistence, setPersistence } from 'firebase/auth';
import { from, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private auth: Auth = inject(Auth);
  user$ = user(this.auth);
  idToken$ = idToken(this.auth);

  constructor() {
    this.setSessionStoragePersistence();
  }

  private setSessionStoragePersistence(): void {
    setPersistence(this.auth, browserSessionPersistence);
  }

  login(email: string, password: string): Observable<void> {
    const promise = signInWithEmailAndPassword(
      this.auth,
      email,
      password
    ).then(() => {
      //
    });
    return from(promise);
  }

  googleLogin() {
    const provider = new GoogleAuthProvider();

    return from(signInWithPopup(this.auth, provider));
  }

  logout(): Observable<void> {
    const promise = signOut(this.auth).then(() => {
      sessionStorage.clear();
    });
    return from(promise);
  }

}
