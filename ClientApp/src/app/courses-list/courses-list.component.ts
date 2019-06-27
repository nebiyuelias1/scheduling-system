import { Component, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource, MatDialog, MatDialogConfig } from '@angular/material';
import { CourseService } from '../services/course.service';
import { DeleteDialogComponent } from '../delete-dialog/delete-dialog.component';
import { UserService } from '../accounts/user.service';
import { CurriculumService } from '../services/curriculum.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-courses-list',
  templateUrl: './courses-list.component.html',
  styleUrls: ['./courses-list.component.css']
})
export class CoursesListComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  courses: any[];
  dataSource: MatTableDataSource<any>;
  displayedColumns = ['courseCode', 'name', 'lecture', 'lab', 'tutor', 'deliveryYear', 'deliverySemester', 'curriculum', 'action'];
  searchKey: string;
  curriculums: any[];
  curriculumId = -1;

  constructor(
    private courseService: CourseService,
    private curriculumService: CurriculumService,
    private dialog: MatDialog,
    private changeDetectorRefs: ChangeDetectorRef,
    private userService: UserService
  ) { }

  ngOnInit() {
    const query = {
      departmentId: this.userService.decodedToken.dept_id,
    };

    const sources = [ this.curriculumService.getCurriculums(query),
      this.courseService.getCourses(query)];

    Observable.forkJoin(sources)
      .subscribe((result: any) => {
        this.curriculums = result[0].items;
        this.courses = result[1].items;
        this.dataSource = new MatTableDataSource<any>(this.courses);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
        this.paginator.length = this.dataSource.data.length;
        this.paginator._changePageSize(this.paginator.pageSize);

        this.dataSource.filterPredicate = (data, filter) => {
          const courseCodeFound = data.courseCode.toString().toLowerCase().indexOf(filter) !== -1;
          const courseNameFound = data.name.toString().toLowerCase().indexOf(filter) !== -1;

          return courseCodeFound || courseNameFound;
        };
      }, err => console.error(err));
  }

  clearSearchKey() {
    this.searchKey = '';
    this.applyFilter();
  }

  applyFilter() {
    this.dataSource.filter = this.searchKey.trim().toLowerCase();
  }

  openDeleteDialog(id) {
    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = '400px';

    dialogConfig.data = {
      id: id,
      title: 'Delete Course?',
      message: 'Are you you want to delete this course?'
    };

    const dialogRef = this.dialog.open(DeleteDialogComponent, dialogConfig);
    dialogRef.afterClosed()
      .subscribe(result => {
        if (result) {
          this.courseService.delete(id)
            .subscribe(x => {
              const itemIndex = this.dataSource.data.findIndex(obj => obj.id === id);
              this.dataSource.data.splice(itemIndex, 1);
              this.dataSource.paginator = this.paginator;
              this.changeDetectorRefs.detectChanges();
            },
            err => console.error(err));
        }
      });
  }

  onCurriculumChange() {
    if (+this.curriculumId === -1) {
      this.dataSource.data = this.courses;
    } else {
      this.dataSource.data = this.courses;
      const filtered = this.dataSource.data.filter(val => {
        return val.curriculum.id === this.curriculumId;
      });

      this.dataSource.data = filtered;
    }

    this.dataSource.paginator = this.paginator;
    this.changeDetectorRefs.detectChanges();
  }
}
