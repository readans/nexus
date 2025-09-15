import { Component, DestroyRef, inject, signal } from '@angular/core';
import { ApiService } from '../../../core/services/api.service';
import { UserStore } from '../../../shared/stores/user.store';
import { DataTable } from '../../../shared/components/data-table/data-table';
import { ActivatedRoute } from '@angular/router';
import { Professor } from '../../../shared/models/professor';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';

@Component({
  selector: 'app-professors',
  imports: [
    DataTable
  ],
  templateUrl: './professors.html',
})
export class Professors {

  private destroyRef = inject(DestroyRef);
  private api = inject(ApiService);
  private user = inject(UserStore);
  professors = signal<Professor[]>([]);

  ngOnInit(): void {
    this.loadClassmates()
  }

  loadClassmates() {
    if (!this.user.user()) return

    this.api.get<Professor[]>('professor').pipe(takeUntilDestroyed(this.destroyRef)).subscribe({
      next: (value) => this.professors.set(value)
    })
  }
}
