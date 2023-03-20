import { Component, Input, OnInit } from '@angular/core';
import { PlannedCourse } from '../planned-course';
import { createPlannedCourse } from '../planned-course';

@Component({
  selector: 'courses-list-viewer',
  templateUrl: './courses-list.component.html',
  styleUrls: ['./courses-list.component.scss']
})
export class CoursesListComponent implements OnInit {
  @Input()
  public courses?: PlannedCourse[];

  ngOnInit() {
    //getall() goes here later TODO
   
  }
  
}
