import { Route } from "@angular/router";
import { CoursesPageComponent } from "./courses/courses-page/courses-page.component";
import { UploadPageComponent } from "./upload-page/upload-page.component";

export const routes: Route[] = [
    {path: 'courses', component: CoursesPageComponent},
    {path: 'upload', component: UploadPageComponent}

];