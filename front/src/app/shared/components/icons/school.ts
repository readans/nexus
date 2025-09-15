import { Component, Input } from '@angular/core';

@Component({
  selector: 'school-icon',
  standalone: true,
  template: `
<svg  xmlns="http://www.w3.org/2000/svg"  width="24"  height="24"  viewBox="0 0 24 24"  fill="none"  stroke="currentColor"  stroke-width="2"  stroke-linecap="round"  stroke-linejoin="round"  class="icon icon-tabler icons-tabler-outline icon-tabler-school" [attr.width]="size.width" [attr.height]="size.height"><path stroke="none" d="M0 0h24v24H0z" fill="none"/><path d="M22 9l-10 -4l-10 4l10 4l10 -4v6" /><path d="M6 10.6v5.4a6 3 0 0 0 12 0v-5.4" /></svg>
    `,
})
export class SchoolIcon {
  @Input({ required: true }) size!: { width: number; height: number };
}
