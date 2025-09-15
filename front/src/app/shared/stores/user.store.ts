import { Injectable, signal } from "@angular/core";
import { Student } from "../models/student";

@Injectable({
  providedIn: 'root'
})
export class UserStore {

  private readonly _user = signal<Student | null>(null);
  readonly user = this._user.asReadonly();

  setUser(value: Student) {
    this._user.set(value);
    localStorage.setItem('user', JSON.stringify(value));
  }

  clearUser() {
    this._user.set(null);
    localStorage.removeItem('user');
  }

}
