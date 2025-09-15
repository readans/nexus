import { Component, input, Input, model, output, Output } from '@angular/core';
import { DashedCheckIcon } from "../../../../shared/components/icons/dashed-check";
import { Subject } from '../../models/subject';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-subject-card',
  imports: [
    CommonModule,
    DashedCheckIcon,
  ],
  templateUrl: './subject-card.html',
})
export class SubjectCard {
  subject = input<Subject>();
  select = output<Subject>()
  selected = input<boolean>(false);
  disabled = input<boolean>(false);

  onClick() {
    const subject = this.subject()
    if (subject && !this.disabled()) this.select.emit(subject)
  }

}
