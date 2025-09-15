import { Injectable, signal } from "@angular/core";
import { Subject } from "../models/subject";

@Injectable({
  providedIn: 'root'
})
export class SubjectsStore {
  private readonly _subjects = signal<Subject[]>([]);
  readonly subjects = this._subjects.asReadonly();

  setSubjects(value: Subject[]) {
    this._subjects.set(value);
    localStorage.setItem('subjects', JSON.stringify(value));
  }

  clearSubjects() {
    this._subjects.set([]);
    localStorage.removeItem('subjects');
  }

}
