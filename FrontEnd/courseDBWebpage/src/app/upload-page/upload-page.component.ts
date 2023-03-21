import { Component, ElementRef, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'file-upload',
  template: `<input type="file" #fileInput (change)="onFileSelected()">`,
  styleUrls: ['./upload-page.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class UploadPageComponent {
  @ViewChild('fileInput') fileInput?: ElementRef;
  fileToUpload? : File = undefined;


  constructor(private http: HttpClient) {}

  onFileSelected() {

    this.fileToUpload = this.fileInput?.nativeElement.files[0];

    if(typeof this.fileToUpload == "undefined")
    {
      console.log("EMPTY FILE");
      return;
    }

    
    console.log(this.fileToUpload!.name);


    const formData = new FormData();
    formData.append('file', this.fileToUpload!);



    this.http.post('https://localhost:7177/api/upload', formData).subscribe(
      (response) => {
        console.log('File uploaded successfully.');
      }
    );
  }
}
