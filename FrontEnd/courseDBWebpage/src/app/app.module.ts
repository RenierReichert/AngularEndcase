import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { CoursesPageComponent } from './courses/courses-page/courses-page.component';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CoursesListComponent } from './courses/courses-list/courses-list.component';
import { routes } from './routes';
import { HttpClient, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import { UploadPageComponent } from './upload-page/upload-page.component';
import { ErrorInterceptor } from './interceptors/ErrorInterceptor';

@NgModule({
  declarations: [
    AppComponent,
    CoursesListComponent,
    CoursesPageComponent,
    UploadPageComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes),
    HttpClientModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
