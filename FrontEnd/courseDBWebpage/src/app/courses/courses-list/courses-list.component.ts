import { Component, Input, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { PlannedCourse } from 'src/app/DTOs/CourseObjs';
import { createPlannedCourse } from '../planned-course';
import { CourseInstance } from '../course-instance';
import { DatePipe } from '@angular/common';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'courses-list-viewer',
  templateUrl: './courses-list.component.html',
  styleUrls: ['./courses-list.component.scss']
})
export class CoursesListComponent implements OnInit {
  @Input()
  public courses?: PlannedCourse[];

  constructor(private http: HttpClient)
  {

  }

  ngOnInit(): void {
    this.http.get<PlannedCourse[]>('https://localhost:7177/api/courses')
      .subscribe((response: PlannedCourse[]) => {
        this.courses = response;
      });
  }
  

}
