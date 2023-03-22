import { Component, OnInit } from '@angular/core';
import { PlannedCourse } from 'src/app/DTOs/CourseObjs';
import { HttpClient } from '@angular/common/http';
import { CourseInstance } from '../course-instance';

@Component({
  selector: 'courses-page',
  templateUrl: './courses-page.component.html',
  styleUrls: ['./courses-page.component.scss']
})
export class CoursesPageComponent implements OnInit {
  public courses?: PlannedCourse[];
  public filteredcourses?: CourseInstance[];

  constructor(private http: HttpClient) { }


  ngOnInit(): void {
    this.http.get<PlannedCourse[]>('https://localhost:7177/api/courses')
      .subscribe((response: PlannedCourse[]) => {
        this.courses = response;
      });
  }

  onFilter(): void {
    this.http.get<any[]>('https://localhost:7177/api/courses/filtered/2020/1')
      .subscribe((response: CourseInstance[]) => {
        this.filteredcourses = response;
      });
  }
  

}

