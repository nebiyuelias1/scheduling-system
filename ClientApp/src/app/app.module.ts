import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

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
import { AcademicYearFormComponent } from './academic-year-form/academic-year-form.component';
import { AcademicSemesterFormComponent } from './academic-semester-form/academic-semester-form.component';
import { CourseOfferingsListComponent } from './course-offerings-list/course-offerings-list.component';
import { AssignInstructorComponent } from './assign-instructor/assign-instructor.component';
import { ScheduleConfigurationFormComponent } from './schedule-configuration-form/schedule-configuration-form.component';
import { ScheduleComponent } from './schedule/schedule.component';
import { ListGroupComponent } from './list-group/list-group.component';
import { BreadcrumbComponent } from './breadcrumb/breadcrumb.component';
import { AppRoutingModule } from './app-routing.module';
import { CurriculumListComponent } from './curriculum-list/curriculum-list.component';
import { HomeHeaderComponent } from './home-header/home-header.component';
import { TimetableComponent } from './timetable/timetable.component';
import { NgxFullCalendarModule } from 'ngx-fullcalendar';
import { AccountsModule } from './accounts/accounts.module';
import { MainComponent } from './main/main.component';
import { AuthGuard } from './accounts/auth-guard.service';
import { DataTableComponent } from './data-table/data-table.component';
import { MatTableModule, MatPaginatorModule, MatSortModule, MatDialogModule,
  MatIconModule, MatButtonModule, MatFormFieldModule, MatInputModule } from '@angular/material';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DeleteDialogComponent } from './delete-dialog/delete-dialog.component';
import { InstructorsListComponent } from './instructors-list/instructors-list.component';
import { CoursesListComponent } from './courses-list/courses-list.component';

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
    AcademicYearFormComponent,
    AcademicSemesterFormComponent,
    CourseOfferingsListComponent,
    AssignInstructorComponent,
    ScheduleConfigurationFormComponent,
    ScheduleComponent,
    ListGroupComponent,
    BreadcrumbComponent,
    CurriculumListComponent,
    HomeHeaderComponent,
    TimetableComponent,
    MainComponent,
    DataTableComponent,
    DeleteDialogComponent,
    InstructorsListComponent,
    CoursesListComponent,
  ],
  imports: [
    AppRoutingModule,
    AccountsModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    NgxFullCalendarModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatDialogModule,
    MatIconModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule
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
    InstructorService,
    AuthGuard
  ],
  bootstrap: [AppComponent],
  entryComponents: [DeleteDialogComponent]
})
export class AppModule { }
