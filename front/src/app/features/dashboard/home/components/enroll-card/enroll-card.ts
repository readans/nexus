import { Component, input } from '@angular/core';
import { Enrollment } from '../../../../../shared/models/enrollment';
import { DatePipe } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-enroll-card',
  imports: [
    DatePipe,
    RouterModule
  ],
  templateUrl: './enroll-card.html',
})
export class EnrollCard {
  enrollment = input<Enrollment>();
}
