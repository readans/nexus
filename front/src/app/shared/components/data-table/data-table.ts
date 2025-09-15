import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';

export interface TableColumn<T> {
  key: keyof T;
  header: string;
}

@Component({
  selector: 'app-data-table',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './data-table.html'
})
export class DataTable<T extends object> {
  @Input() columns: TableColumn<T>[] = [];
  @Input() data: T[] = [];

  trackByIndex = (index: number) => index;
}
