import { NgModule } from "@angular/core";
import { ClassroomIcon } from "./classroom";
import { SchoolIcon } from "./school";
import { PencilIcon } from "./pencil";
import { UserIcon } from "./user";
import { LogoutIcon } from "./logout";
import { RulerIcon } from "./ruler";
import { GithubIcon } from "./github";
import { DashedCheckIcon } from "./dashed-check";

@NgModule({
  declarations: [],
  imports: [
    ClassroomIcon,
    SchoolIcon,
    PencilIcon,
    UserIcon,
    RulerIcon,
    GithubIcon,
    LogoutIcon,
    DashedCheckIcon,
  ],
  exports: [
    ClassroomIcon,
    SchoolIcon,
    PencilIcon,
    UserIcon,
    RulerIcon,
    GithubIcon,
    LogoutIcon,
    DashedCheckIcon,
  ],
})
export class IconsModule { }
