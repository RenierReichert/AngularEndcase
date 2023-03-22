import { Injectable } from '@angular/core';
import { CourseInstance } from '../courses/course-instance';
import { PlannedCourse } from '../DTOs/CourseObjs';
import { CourseDBChanges } from '../DTOs/CourseDbChanges';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InterceptorService {
  public errorMessage = new Subject<string>();
  public changeList? : CourseDBChanges; 

  constructor() { }

  setErrorMessage(message: string) {
    this.errorMessage.next(message);
    console.log("ERroRRMESSAGE SET");
  }

  getErrorMessageSubject() {
    console.log("ERroRMESSAGE GET");
    return this.errorMessage.asObservable();
  }



}
