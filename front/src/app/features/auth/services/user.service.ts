import { inject, Injectable } from "@angular/core";
import { Student } from "../../home/models/student";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private _user: Student | null = null;

  constructor() {
    const strUser = localStorage.getItem('user');
    if (strUser) {
      this._user = JSON.parse(strUser) as Student;
    }
  }

  get user(): Student | null {
    return this._user;
  }

  set user(value: Student | null) {
    this._user = value;
    if (value) {
      localStorage.setItem('user', JSON.stringify(value));
    } else {
      localStorage.removeItem('user');
    }
  }

  clear() {
    this.user = null;
  }
}
