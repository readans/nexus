import { Component, Input } from '@angular/core';
import { IconsModule } from '../icons/icons.module';
import { AsyncPipe } from '@angular/common';

@Component({
  selector: 'app-header',
  imports: [
    IconsModule
  ],
  templateUrl: './header.html',
})
export class Header {
  @Input() userName!: string;
  @Input() userAvatar!: string;
}
