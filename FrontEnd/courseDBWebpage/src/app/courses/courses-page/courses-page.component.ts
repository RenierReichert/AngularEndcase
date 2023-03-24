import { Component, Input, OnInit } from '@angular/core';
import { PlannedCourse } from 'src/app/DTOs/CourseObjs';
import { HttpClient } from '@angular/common/http';
import { CourseInstance } from '../course-instance';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';
import { InterceptorService } from 'src/app/services/interceptor.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'courses-page',
  templateUrl: './courses-page.component.html',
  styleUrls: ['./courses-page.component.scss'],
  providers: [DatePipe]
})
export class CoursesPageComponent implements OnInit{

  //Variables
  public courses?: PlannedCourse[];
  public filteredlist?: CourseInstance[];

  selectedYear: number = -1;
  selectedWeek: number = -1;
  weekForm = new FormGroup({
    year: new FormControl('', [
      Validators.required,
      Validators.min(2000),
      Validators.max(2030)
    ]),
    week: new FormControl('', [
      Validators.required,
      Validators.min(0),
      Validators.max(54)
    ])
  });

  
  constructor(private http: HttpClient, 
    private intService: InterceptorService, 
    private fb: FormBuilder, 
    private datePipe: DatePipe) {
  }

  //Lifecycle methods.
  ngOnInit(): void {

    this.weekForm.valueChanges.subscribe(values => {
      this.week = parseInt(values.week!);
    });
    const currentDate = new Date();
    const currentYear = this.datePipe.transform(currentDate, 'yyyy');
    const currentWeek = this.datePipe.transform(currentDate, 'ww');

    this.weekForm = this.fb.group({
      year: currentYear!,
      week: currentWeek!
    });   
  }

  //Getters and setters
  get sortedlist(): CourseInstance[] {

    //If the list is empty, don't try to sort it
    if (!this.filteredlist) {
      return [];
    }

    let sortedlist: CourseInstance[];
    sortedlist = this.filteredlist!.sort(
      (a, b) => {
        return <any>new Date(a.instancestartdatum) - <any>new Date(b.instancestartdatum);
      }
    );

    return sortedlist;
  }
  get year() { return parseInt(this.weekForm.get('year')!.value!); }
  get week() { return parseInt(this.weekForm.get('week')!.value!); }
  set week(value: number) {
    //This looks wacky because week in the .ts file is a number
    //But its a string in the .HTMl file. 
    //TODO: Refactor and give clearer names.
    this.weekForm.patchValue({ week: value.toString() });
  }



 

  //Functions

  incrementWeek() {
    if (this.week < 54) {
      this.week++;
      this.weekForm.patchValue({ week: this.week.toString() });
    }
  }

  decrementWeek() {
    if (this.week > 0) {
      this.week--;
      this.weekForm.patchValue({ week: this.week.toString() });
    }
  }

  onFilter(): void {

    if (!this.weekForm.valid) {
      this.intService.setErrorMessage("Date selection invalid.")
      return;
    }

    this.selectedYear = this.year;
    this.selectedWeek = this.week;

    this.http.get<any[]>('https://localhost:7177/api/courses/filtered/' + this.selectedYear + '/' + this.selectedWeek + '/')
      .subscribe((response: CourseInstance[]) => {
        this.filteredlist = response;
      });
  }


}


