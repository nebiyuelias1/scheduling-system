import { Routes, RouterModule, Router } from '@angular/router';
import { NgModule } from '@angular/core';
import { HomeComponent } from './home/home.component';
import { SectionListComponent } from './section-list/section-list.component';
import { CollegeListComponent } from './college-list/college-list.component';
import { DepartmentFormComponent } from './department-form/department-form.component';
import { CurriculumFormComponent } from './curriculum-form/curriculum-form.component';
import { CourseFormComponent } from './course-form/course-form.component';
import { BuildingFormComponent } from './building-form/building-form.component';
import { RoomFormComponent } from './room-form/room-form.component';
import { SectionFormComponent } from './section-form/section-form.component';
import { InstructorFormComponent } from './instructor-form/instructor-form.component';
import { SectionDetailComponent } from './section-detail/section-detail.component';
import { SectionRoomAssignmentFormComponent } from './section-room-assignment-form/section-room-assignment-form.component';
import { AcademicYearFormComponent } from './academic-year-form/academic-year-form.component';
import { AcademicSemesterFormComponent } from './academic-semester-form/academic-semester-form.component';
import { AssignInstructorComponent } from './assign-instructor/assign-instructor.component';
import { CourseOfferingsListComponent } from './course-offerings-list/course-offerings-list.component';
import { ScheduleComponent } from './schedule/schedule.component';
import { ScheduleConfigurationFormComponent } from './schedule-configuration-form/schedule-configuration-form.component';

const routes: Routes = [
    {
        path: '',
        component: HomeComponent,
        pathMatch: 'full',
    },
    { path: 'colleges', component: CollegeListComponent },
    { path: 'departments/new', component: DepartmentFormComponent },
    { path: 'curriculums/new', component: CurriculumFormComponent },
    { path: 'courses/new', component: CourseFormComponent },
    { path: 'buildings/new', component: BuildingFormComponent },
    { path: 'rooms/new', component: RoomFormComponent },
    { path: 'instructors/new', component: InstructorFormComponent },
    {
        path: 'sections',
        data: {
            breadcrumb: 'Sections'
        },
        children: [
            {
                path: '',
                component: SectionListComponent,
                data: {
                    breadcrumb: 'List'
                }
            },
            {
                path: 'new',
                component: SectionFormComponent,
                data: {
                    breadcrumb: 'New'
                }
            },
            {
                path: ':id',
                component: SectionDetailComponent,
                data: {
                    breadcrumb: 'Detail'
                },
                children: [
                    {
                        path: 'assign',
                        component: SectionRoomAssignmentFormComponent,
                        data: {
                            breadcrumb: 'Assign'
                        }
                    }
                ]
            },
        ]
    },
    { path: 'years/new', component: AcademicYearFormComponent },
    { path: 'semesters/new', component: AcademicSemesterFormComponent },
    { path: 'courseofferings/assign/:id', component: AssignInstructorComponent },
    { path: 'courseofferings', component: CourseOfferingsListComponent },
    { path: 'schedules/:id', component: ScheduleComponent },
    { path: 'scheduleconfigurations', component: ScheduleConfigurationFormComponent }
];



@NgModule({
    declarations: [],
    imports: [RouterModule.forRoot(routes, { enableTracing: true })],
    exports: [RouterModule],
    providers: [],
})
export class AppRoutingModule { }
