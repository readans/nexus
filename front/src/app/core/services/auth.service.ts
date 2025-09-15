import {
  inject,
  Injectable
} from '@angular/core';
import {
  Auth,
  GoogleAuthProvider,
  idToken,
  signInWithEmailAndPassword,
  signInWithPopup,
  signOut,
  user
} from '@angular/fire/auth';
import {
  browserSessionPersistence,
  setPersistence
} from 'firebase/auth';
import {
  from,
  Observable
} from 'rxjs';

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

  signIn(email: string, password: string) {
    const promise = signInWithEmailAndPassword(
      this.auth,
      email,
      password
    );

    return from(promise);
  }

  signInGoogle() {
    const provider = new GoogleAuthProvider();

    return from(signInWithPopup(this.auth, provider));
  }

  signOut(): Observable<void> {
    const promise = signOut(this.auth);

    return from(promise);
  }

}
