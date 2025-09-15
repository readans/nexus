import { Component, input, Input, model, output, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IconsModule } from '../../../../../shared/components/icons/icons.module';
import { Subject } from '../../../../../shared/models/subject';

@Component({
  selector: 'app-subject-card',
  imports: [
    CommonModule,
    IconsModule,
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
