import { Component, Input, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { PlannedCourse } from '../planned-course';
import { createPlannedCourse } from '../planned-course';

@Component({
  selector: 'courses-list-viewer',
  templateUrl: './courses-list.component.html',
  styleUrls: ['./courses-list.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CoursesListComponent  {
  @Input()
  public courses?: PlannedCourse[];
  @Input()
  public filteredlist: any;
  

}
