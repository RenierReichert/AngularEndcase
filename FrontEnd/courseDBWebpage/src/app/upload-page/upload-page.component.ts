import { Component, ElementRef, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ChangeDetectionStrategy } from '@angular/core';
import { CourseInstance } from '../courses/course-instance';
import { sanatize } from '../shared/sanatizer';
import { PlannedCourse } from '../DTOs/CourseObjs';
import { CourseDBChanges } from '../DTOs/CourseDbChanges';
import { InterceptorService } from '../services/interceptor.service';

@Component({
  selector: 'file-upload',
  templateUrl: './upload-page.component.html',
  styleUrls: ['./upload-page.component.scss'],
})
export class UploadPageComponent {

  uploadStatus: string = "Kies een bestand.";

  ciHeader: string = "";
  cHeader: string = "";
  cichangelist?: CourseInstance[];
  cchangelist?: PlannedCourse[];

  @ViewChild('fileInput') fileInput?: ElementRef;
  fileToUpload?: File = undefined;



  constructor(private http: HttpClient, private intService: InterceptorService) { }

  onFileSelected() {

    this.cleanUp();
    this.fileToUpload = this.fileInput?.nativeElement.files[0];
    this.fileCheck();

    const formData = new FormData();
    formData.append('file', this.fileToUpload!);

    let filename = sanatize(this.fileToUpload!.name);
    this.uploadStatus = filename + " is geupload! Opslaan...";

    this.http.post<CourseDBChanges>('https://localhost:7177/api/upload', formData, { observe: "response" }).subscribe(
      (response) => {
        if (!response.body) {
          this.uploadStatus = "An error has occured. ";
        }
        else {     
          this.intService.setErrorMessage("OK");   
          this.uploadStatus = response.body.message;
          this.cHeader = "Uploaded courses: "
          this.cchangelist = response.body.pcchangeList;
          this.ciHeader = "Uploaded course instances: "
          this.cichangelist = response.body.cichangeList;

          /*
          console.log(response.body);
          console.log(response.statusText);
          console.log(response.body.courseInstance);
          console.log(response.body.message);         
          console.log(this.uploadStatus);
          */
        }
      }
    );

  }

  cleanUp()
  {
    this.ciHeader = "";
    this.cHeader = "";
    this.cichangelist = [];
    this.cchangelist = [];
  }

  fileCheck()
  {
    if (typeof this.fileToUpload === "undefined") {
      console.log("EMPTY FILE");
      this.uploadStatus = "Dit bestand lijkt leeg te zijn. Probeer het opnieuw."
      return;
    }
    let extension = this.fileToUpload!.name.split('.')[1].toLowerCase();
    if(extension !== "txt")
    {
        this.uploadStatus = "Onbekend bestand. Selecteer een .txt bestand."
        return;
    }
  }

}
