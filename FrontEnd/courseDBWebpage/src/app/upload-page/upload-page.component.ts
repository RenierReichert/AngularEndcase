import { Component, ElementRef, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'file-upload',
  templateUrl: './upload-page.component.html',
  styleUrls: ['./upload-page.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class UploadPageComponent {

  uploadStatus: string = "Kies een bestand.";
  @ViewChild('fileInput') fileInput?: ElementRef;
  fileToUpload?: File = undefined;



  constructor(private http: HttpClient) { }

  onFileSelected() {

    this.fileToUpload = this.fileInput?.nativeElement.files[0];

    if (typeof this.fileToUpload === "undefined") {
      console.log("EMPTY FILE");
      this.uploadStatus = "Dit bestand lijkt leeg te zijn. Probeer het opnieuw."
      return;
    }


    console.log(this.fileToUpload!.name);


    const formData = new FormData();
    formData.append('file', this.fileToUpload!);
    this.uploadStatus = this.fileToUpload!.name + " is geupload! Opslaan...";


    try {
      this.http.post('https://localhost:7177/api/upload', formData, { observe: "response" }).subscribe(
        (response) => {
          console.log(response.body)

          this.uploadStatus = response.statusText;
        }
      );
    }
    catch (ex) {
      this.uploadStatus = "YOU BROKE IT YOU RUINED IT";
    }
  }
}
