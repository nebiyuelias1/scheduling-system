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
import { BuildingFormComponent } from './building-form/building-form.component';
import { BuildingService } from './services/building.service';
import { RoomFormComponent } from './room-form/room-form.component';
import { RoomService } from './services/room.service';
import { SectionFormComponent } from './section-form/section-form.component';
import { CommonService } from './services/common.service';
import { SectionService } from './services/section.service';
import { InstructorFormComponent } from './instructor-form/instructor-form.component';
import { InstructorService } from './services/instructor.service';
import { SectionRoomAssignmentFormComponent } from './section-room-assignment-form/section-room-assignment-form.component';
import { SectionListComponent } from './section-list/section-list.component';
import { SectionDetailComponent } from './section-detail/section-detail.component';

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
    CourseFormComponent,
    BuildingFormComponent,
    RoomFormComponent,
    SectionFormComponent,
    InstructorFormComponent,
    SectionRoomAssignmentFormComponent,
    SectionListComponent,
    SectionDetailComponent,
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
      { path: 'courses/new', component: CourseFormComponent },
      { path: 'buildings/new', component: BuildingFormComponent },
      { path: 'rooms/new', component: RoomFormComponent },
      { path: 'sections/new', component: SectionFormComponent },
      { path: 'instructors/new', component: InstructorFormComponent },
      { path: 'sections', component: SectionListComponent },
      { path: 'sections/:id', component: SectionDetailComponent },
      { path: 'sections/assign/:id', component: SectionRoomAssignmentFormComponent }
    ])
  ],
  providers: [
    CollegeService,
    DepartmentService,
    CurriculumService,
    CourseService,
    BuildingService,
    RoomService,
    CommonService,
    SectionService,
    InstructorService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
