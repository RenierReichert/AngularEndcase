import { Component, Input, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { PlannedCourse } from 'src/app/DTOs/CourseObjs';
import { createPlannedCourse } from '../planned-course';
import { CourseInstance } from '../course-instance';
import { DatePipe } from '@angular/common';

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
  public filteredlist?: CourseInstance[] = [];

  get sortedlist(): CourseInstance[]{

    //If the list is empty, don't try to sort it
    if(!this.filteredlist)
    {
      return [];
    }

    let sortedlist: CourseInstance[];
    sortedlist = this.filteredlist!.sort(
      (a,b) => {
        return <any>new Date(a.instancestartdatum) - <any>new Date(b.instancestartdatum);
      }
    );

    return sortedlist;
  }
  

}
