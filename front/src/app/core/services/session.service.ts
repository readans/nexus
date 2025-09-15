// core/services/session.service.ts
import { Injectable, inject } from '@angular/core';
import { AuthService } from './auth.service';
import { tap, switchMap, forkJoin, Observable } from 'rxjs';
import { UserStore } from '../../shared/stores/user.store';
import { SubjectsStore } from '../../shared/stores/subjects.store';
import { Login } from '../../features/auth/models/login.model';
import { Student } from '../../shared/models/student';
import { ApiService } from './api.service';
import { Subject } from '../../shared/models/subject';

@Injectable({ providedIn: 'root' })
export class SessionService {
  private api = inject(ApiService);
  private userStore = inject(UserStore);
  private subjectsStore = inject(SubjectsStore);

  login(value: Login) {
    return this.api.post<Student>('auth', value).pipe(
      tap(user => this.userStore.setUser(user)),
      switchMap(() =>
        this.api.get<Subject[]>('subject')
      ),
      tap(subjects => this.subjectsStore.setSubjects(subjects))
    )
  }

  logout() {
    this.userStore.clearUser()
    this.subjectsStore.clearSubjects()

    sessionStorage.clear();
  }
}
