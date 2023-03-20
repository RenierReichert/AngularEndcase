import { Component, OnInit } from '@angular/core';
import { PlannedCourse } from './courses/planned-course';
import { createPlannedCourse } from './courses/planned-course';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title = 'courseDBWebpage';
 
  ngOnInit() {
  }

}
