import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { CollegeListComponent } from './college-list/college-list.component';
import { CollegeService } from './services/college.service';
import { DepartmentFormComponent } from './department-form/department-form.component';
import { DepartmentService } from './services/department.service';
import { CurriculumFormComponent } from './curriculum-form/curriculum-form.component';
import { CurriculumService } from './services/curriculum.service';
import { CourseFormComponent } from './course-form/course-form.component';
import { CourseService } from './services/course.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    CollegeListComponent,
    DepartmentFormComponent,
    CurriculumFormComponent,
    CourseFormComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'colleges', component: CollegeListComponent },
      { path: 'departments/new', component: DepartmentFormComponent },
      { path: 'curriculums/new', component: CurriculumFormComponent },
      { path: 'courses/new', component: CourseFormComponent }
    ])
  ],
  providers: [
    CollegeService,
    DepartmentService,
    CurriculumService,
    CourseService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
