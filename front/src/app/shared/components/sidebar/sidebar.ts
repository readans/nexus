import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { IconsModule } from '../icons/icons.module';

export interface NavLink {
  name: string;
  href: string;
  icon: string;
}

@Component({
  selector: 'app-sidebar',
  imports: [
    RouterModule,
    IconsModule,
  ],
  templateUrl: './sidebar.html',
})
export class Sidebar {
  links: NavLink[] = [
    { name: 'Estudiantes', href: 'students', icon: 'student' },
    { name: 'Profesores', href: 'professors', icon: 'professor' },
  ];
}
