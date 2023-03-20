import { Component, Input } from '@angular/core';
import { PlannedCourse } from '../planned-course';

@Component({
  selector: 'app-courses-list',
  templateUrl: './courses-list.component.html',
  styleUrls: ['./courses-list.component.scss']
})
export class CoursesListComponent {
  @Input()
  public courses?: PlannedCourse[];
}
