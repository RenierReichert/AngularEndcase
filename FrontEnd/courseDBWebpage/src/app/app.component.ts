import { Component, OnInit } from '@angular/core';
import { PlannedCourse } from './DTOs/CourseObjs';
import { createPlannedCourse } from './courses/planned-course';
import { InterceptorService } from './services/interceptor.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title = 'courseDBWebpage';
  errorMessage?: string;
  private sub?: Subscription;
 
  constructor(private intService: InterceptorService){

  }

  ngOnInit() {
    this.sub = this.intService.getErrorMessageSubject().subscribe(
      (errmsg) => (this.errorMessage = errmsg)
    );    
  }

  ngOnDestroy() {
    this.sub!.unsubscribe();
  }
}
