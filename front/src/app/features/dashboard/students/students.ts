import { Component, DestroyRef, inject, signal } from '@angular/core';
import { DataTable } from '../../../shared/components/data-table/data-table';
import { ApiService } from '../../../core/services/api.service';
import { UserStore } from '../../../shared/stores/user.store';
import { Student } from '../../../shared/models/student';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';

@Component({
  selector: 'app-students',
  imports: [
    DataTable
  ],
  templateUrl: './students.html',
})
export class Students {

  private destroyRef = inject(DestroyRef);
  private api = inject(ApiService);
  private user = inject(UserStore);
  students = signal<Student[]>([]);

  ngOnInit(): void {
    this.loadClassmates()
  }

  loadClassmates() {
    if (!this.user.user()) return

    this.api.get<Student[]>('student').pipe(takeUntilDestroyed(this.destroyRef)).subscribe({
      next: (value) => this.students.set(value)
    })
  }
}
