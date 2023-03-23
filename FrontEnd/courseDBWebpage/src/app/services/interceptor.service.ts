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

  setErrorMessage(message: any) {
    if(typeof message === "string")
    {    
    this.errorMessage.next(message);
    }
    else
    {
      this.errorMessage.next("Server appears to be offline.");      
    }
    console.log(message);
    
  //  console.log("ERRORRMESSAGE SET");
  }

  getErrorMessageSubject() {
   // console.log("ERRORMESSAGE GET");
    return this.errorMessage.asObservable();
  }



}
