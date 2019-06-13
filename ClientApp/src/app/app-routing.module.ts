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
import { CourseOfferingDetailComponent } from './course-offering-detail/course-offering-detail.component';
import { CourseOfferingsListComponent } from './course-offerings-list/course-offerings-list.component';
import { ScheduleComponent } from './schedule/schedule.component';
import { ScheduleConfigurationFormComponent } from './schedule-configuration-form/schedule-configuration-form.component';
import { CurriculumListComponent } from './curriculum-list/curriculum-list.component';
import { MainComponent } from './main/main.component';
import { AuthGuard } from './accounts/auth-guard.service';
import { InstructorsListComponent } from './instructors-list/instructors-list.component';
import { CoursesListComponent } from './courses-list/courses-list.component';
import { AssignInstructorComponent } from './assign-instructor/assign-instructor.component';
import { CollegeDeanAssignmentFormComponent } from './college-dean-assignment-form/college-dean-assignment-form.component';

const routes: Routes = [
    {
        path: '',
        component: MainComponent,
        // pathMatch: 'full',
        children: [
            {
                path: '',
                component: HomeComponent
            },
            {
                path: 'colleges',
                data: {
                    breadcrumb: 'Colleges'
                },
                canActivate: [AuthGuard],
                children: [
                    {
                        path: '',
                        data: {
                            breadcrumb: 'List'
                        },
                        component: CollegeListComponent
                    },
                    {
                        path: ':id/assign',
                        data: {
                            breadcrumb: 'Assign'
                        },
                        component: CollegeDeanAssignmentFormComponent
                    }
                ]
            },
            {
                path: 'departments',
                data: {
                    breadcrumb: 'Departments'
                },
                children: [
                    {
                        path: 'new',
                        data: {
                            breadcrumb: 'New'
                        },
                        component: DepartmentFormComponent
                    }
                ]
            },
            {
                path: 'curriculums',
                data: {
                    breadcrumb: 'Curriculums'
                },
                canActivate: [AuthGuard],
                children: [
                    {
                        path: '',
                        data: {
                            breadcrumb: 'List'
                        },
                        component: CurriculumListComponent
                    },
                    {
                        path: 'new',
                        data: {
                            breadcrumb: 'New'
                        },
                        component: CurriculumFormComponent
                    },
                    {
                        path: 'edit/:id',
                        data: {
                            breadcrumb: 'Edit'
                        },
                        component: CurriculumFormComponent
                    }
                ]
            },
            {
                path: 'courses',
                data: {
                    breadcrumb: 'Courses'
                },
                children: [
                    {
                        path: '',
                        data: {
                            breadcrumb: 'List'
                        },
                        component: CoursesListComponent
                    },
                    {
                        path: 'new',
                        data: {
                            breadcrumb: 'New'
                        },
                        component: CourseFormComponent
                    },
                    {
                        path: 'edit/:id',
                        data: {
                            breadcrumb: 'Edit'
                        },
                        component: CourseFormComponent
                    },
                ]
            },
            {
                path: 'instructors',
                data: {
                    breadcrumb: 'Instructors'
                },
                children:  [
                    {
                        path: '',
                        data: {
                            breadcrumb: 'List'
                        },
                        component: InstructorsListComponent
                    },
                    {
                        path: 'new',
                        data: {
                            breadcrumb: 'New'
                        },
                        component: InstructorFormComponent
                    },
                    {
                        path: 'edit/:id',
                        data: {
                            breadcrumb: 'Edit'
                        },
                        component: InstructorFormComponent
                    }
                ]
            },
            {
                path: 'buildings',
                data: {
                    breadcrumb: 'Buildings'
                },
                children: [
                    {
                        path: 'new',
                        data: {
                            breadcrumb: 'New'
                        },
                        component: BuildingFormComponent
                    }
                ]
            },
            {
                path: 'rooms',
                data: {
                    breadcrumb: 'Rooms'
                },
                children: [
                    {
                        path: 'new',
                        data: {
                            breadcrumb: 'New'
                        },
                        component: RoomFormComponent
                    }
                ]
            },
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
                        path: 'edit/:id',
                        component: SectionFormComponent,
                        data: {
                            breadcrumb: 'Edit'
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
            {
                path: 'courseofferings',
                data: {
                    breadcrumb: 'Course Offerings'
                },
                children: [
                    {
                        path: '',
                        data: {
                            breadcrumb: 'List'
                        },
                        component: CourseOfferingsListComponent
                    },
                    {
                        path: ':id',
                        data: {
                            breadcrumb: 'Detail'
                        },
                        component: CourseOfferingDetailComponent,
                        children: [
                            {
                                path: 'assign/:typeId',
                                data: {
                                    breadcrumb: 'Assign'
                                },
                                component: AssignInstructorComponent
                            }
                        ],
                        runGuardsAndResolvers: 'always'
                    }
                ]
            },
            {
                path: 'scheduleconfigurations',
                data: {
                    breadcrumb: 'Schedule Configurations'
                },
                children: [
                    {
                        path: 'new',
                        data: {
                            breadcrumb: 'New'
                        },
                        component: ScheduleConfigurationFormComponent
                    }
                ]
            },
            {
                path: 'schedules',
                data: {
                    breadcrumb: 'Schedules'
                },
                children: [
                    {
                        path: ':id',
                        data: {
                            breadcrumb: 'Section Schedule'
                        },
                        component: ScheduleComponent
                    }
                ]
            },
            {
                path: 'years',
                data: {
                    breadcrumb: 'Years'
                },
                children: [
                    {
                        path: 'new',
                        data: {
                            breadcrumb: 'New'
                        },
                        component: AcademicYearFormComponent
                    }
                ]
            },
            {
                path: 'semesters',
                data: {
                    breadcrumb: 'Semesters'
                },
                children: [
                    {
                        path: 'new',
                        data: {
                            breadcrumb: 'New'
                        },
                        component: AcademicSemesterFormComponent
                    }
                ]
            }
        ]
    },
];



@NgModule({
    declarations: [],
    imports: [RouterModule.forRoot(routes, { onSameUrlNavigation: 'reload'})],
    exports: [RouterModule],
    providers: [],
})
export class AppRoutingModule { }
