import { Component, computed, inject, input, OnInit, signal } from '@angular/core';
import { Classmate } from '../../../shared/models/classmate';
import { DataTable } from "../../../shared/components/data-table/data-table";
import { UserStore } from '../../../shared/stores/user.store';
import { ApiService } from '../../../core/services/api.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-enrollment',
  imports: [DataTable],
  templateUrl: './enrollment.html',
})
export class Enrollment implements OnInit {
  private api = inject(ApiService);
  private user = inject(UserStore);
  classmates = signal<Classmate[]>([]);
  private route = inject(ActivatedRoute);
  id = this.route.snapshot.paramMap.get('id');

  ngOnInit(): void {
    this.loadClassmates()
  }

  loadClassmates() {
    if (!this.user.user()) return

    this.api.get<Classmate[]>(`student/${this.user.user()?.id}/classmates/${this.id}`).subscribe({
      next: (value) => this.classmates.set(value)
    })
  }

}
