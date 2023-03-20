import { Component } from '@angular/core';
import { PlannedCourse, createPlannedCourse } from '../planned-course';

@Component({
  selector: 'courses-page',
  templateUrl: './courses-page.component.html',
  styleUrls: ['./courses-page.component.scss']
})
export class CoursesPageComponent {
  courseListAll : PlannedCourse[];



  constructor() {
    this.courseListAll = [createPlannedCourse({ id: 100 }), createPlannedCourse({ id: 200 })]; 
  }
}
