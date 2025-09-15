import { Component, computed, DestroyRef, inject, OnInit, signal } from '@angular/core';
import { SubjectCard } from './components/subject-card/subject-card';
import { ApiService } from '../../../core/services/api.service';
import { UserStore } from '../../../shared/stores/user.store';
import { Subject } from '../../../shared/models/subject';
import { Enrollment } from '../../../shared/models/enrollment';
import { SubjectsStore } from '../../../shared/stores/subjects.store';
import { switchMap } from 'rxjs';
import { IconsModule } from '../../../shared/components/icons/icons.module';
import { EnrollCard } from './components/enroll-card/enroll-card';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';

@Component({
  selector: 'app-home',
  imports: [
    SubjectCard,
    EnrollCard,
    IconsModule,
  ],
  templateUrl: './home.html',
})
export class Home {
  private destroyRef = inject(DestroyRef);
  private api = inject(ApiService);
  subjects = inject(SubjectsStore);
  user = inject(UserStore);

  selectedSubjects = signal<Subject[]>([]);
  isFetching = signal(false);

  balance = computed(() =>
    (this.user.user()?.totalCredits ?? 0) -
    this.selectedSubjects().reduce((p, c) => p + c.credits, 0)
  );

  enrollments = signal<Enrollment[]>([]);

  constructor() {
    this.loadEnrollments()
  }

  loadEnrollments() {
    const userId = this.user.user()?.id;
    if (!userId) return;

    this.api.get<Enrollment[]>(`student/${userId}/enrollments`).pipe(takeUntilDestroyed(this.destroyRef)).subscribe({
      next: data => this.enrollments.set(data),
    });
  }

  isSelected = (subject: Subject) =>
    this.selectedSubjects().some(s => s.id === subject.id);

  isDisabled = (subject: Subject) =>
    (this.selectedSubjects().some(s => s.professorName === subject.professorName) || this.balance() <= 0) &&
    !this.isSelected(subject);

  addSubject(subject: Subject) {
    this.selectedSubjects.update(list =>
      this.isSelected(subject)
        ? list.filter(s => s.id !== subject.id)
        : [...list, subject]
    );
  }

  subscribeSubjects() {
    const enrollments = this.selectedSubjects().map(s => ({
      studentId: this.user.user()?.id,
      subjectId: s.id,
    }));

    this.isFetching.set(true);

    this.api.post('enrollment/enrollmentAll', enrollments).pipe(
      switchMap(() =>
        this.api.get<Enrollment[]>(`student/${this.user.user()?.id}/enrollments`)
      )
    ).subscribe({
      next: (data) => {
        // 👇 ya no necesitas observable externo, refrescas signal directo
        this.enrollments.set(data);
        this.selectedSubjects.set([]);
      },
      complete: () => this.isFetching.set(false),
    });
  }
}
