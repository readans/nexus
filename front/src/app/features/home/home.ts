import { Component, computed, inject, OnInit, signal } from '@angular/core';
import { ApiService } from '../../core/services/api.service';
import { SubjectCard } from './components/subject-card.component/subject-card';
import { Subject } from './models/subject';
import { AsyncPipe } from '@angular/common';
import { AuthService } from '../auth/services/auth.service';
import { UserService } from '../auth/services/user.service';
import { Enrollment } from './models/enrollment';

@Component({
  selector: 'app-home',
  imports: [
    AsyncPipe,
    SubjectCard
  ],
  templateUrl: './home.html',
})
export class Home implements OnInit {

  private api = inject(ApiService);
  private auth = inject(AuthService);
  private user = inject(UserService);
  subjects$ = this.api.get<Subject[]>('subject');
  enrollments: Enrollment[] = [];
  credits = this.user.user?.totalCredits || 10;
  selectedSubjects = signal<Subject[]>([]);
  balance = computed(() => {
    console.log(this.selectedSubjects())

    return this.credits - this.selectedSubjects().reduce((p, c) => p + c.credits, 0)
  });

  constructor() { }

  ngOnInit(): void {
    this.api.get<Enrollment[]>(`student/${this.user.user?.id}/enrollments`).subscribe({
      next: (e) => this.enrollments = e
    })
  }

  isSelected = (subject: Subject) => this.selectedSubjects().find(s => s.id == subject.id) !== undefined;

  isDisabled = (subject: Subject) => (this.selectedSubjects().find(s => s.professorName == subject.professorName) !== undefined || this.balance() <= 0) && !this.isSelected(subject)

  addSubject(subject: Subject) {
    this.selectedSubjects.update(list =>
      this.isSelected(subject)
        ? list.filter(s => s.id != subject.id)
        : [...list, subject]
    );
  }

  subscribeSubjects() {
    const enrollments = this.selectedSubjects().map(s => ({
      studentId: this.user.user?.id,
      subjectId: s.id
    }))
    this.api.post('enrollment/enrollmentAll', enrollments)
      .subscribe({
        next: () => {
          this.api.get<Enrollment[]>(`student/${this.user.user?.id}/enrollments`).subscribe({
            next: (e) => this.enrollments = e
          });
        }
      })
  }

}
