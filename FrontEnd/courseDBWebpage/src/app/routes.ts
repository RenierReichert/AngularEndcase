import { Route } from "@angular/router";
import { CoursesListComponent } from "./courses/courses-list/courses-list.component";
import { CoursesPageComponent } from "./courses/courses-page/courses-page.component";
import { UploadPageComponent } from "./upload-page/upload-page.component";

export const routes: Route[] = [
    {path: 'coursesbyweek', component: CoursesPageComponent},
    {path: 'upload', component: UploadPageComponent},
    {path: 'coursesoverview', component: CoursesListComponent},

];