import { Component, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { CommonService } from '../services/common.service';
import { MatPaginator, MatSort, MatTableDataSource, MatDialog, MatDialogConfig } from '@angular/material';
import { DeleteDialogComponent } from '../delete-dialog/delete-dialog.component';
import { UserService } from '../accounts/user.service';

@Component({
  selector: 'app-course-offerings-list',
  templateUrl: './course-offerings-list.component.html',
  styleUrls: ['./course-offerings-list.component.css']
})
export class CourseOfferingsListComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  courseOfferings: any[];
  dataSource: MatTableDataSource<any>;
  displayedColumns = ['courseName', 'courseCode', 'sectionName', 'entranceYear', 'isAssignmentCompleted', 'action'];
  searchKey: string;

  constructor(
    private commonService: CommonService,
    private dialog: MatDialog,
    private changeDetectorRefs: ChangeDetectorRef,
    private userService: UserService) { }

  ngOnInit() {
    this.commonService.getCourseOfferings()
      .subscribe((result: any[]) => {
        this.courseOfferings = result;
        this.dataSource = new MatTableDataSource<any>(this.courseOfferings);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
        this.paginator.length = this.dataSource.data.length;
        this.paginator._changePageSize(this.paginator.pageSize);

        this.dataSource.filterPredicate = (data, filter) => {
          const nameColumn = data['course']['name'].toString().toLowerCase().indexOf(filter);
          const courseCodeColumn = data['course']['courseCode'].toString().toLowerCase().indexOf(filter);
          const sectionNameColumn = data['section']['name'].toString().toLowerCase().indexOf(filter);
          const entranceYearColumn = data['section']['entranceYear'].toString().toLowerCase().indexOf(filter);

          return nameColumn !== -1
            || courseCodeColumn !== -1
            || sectionNameColumn !== -1
            || entranceYearColumn !== -1;
        };

        this.dataSource.sortingDataAccessor = (data, sortHeaderId) => {
          switch (sortHeaderId) {
            case 'courseName':
              return data['course']['name'];
            case 'courseCode':
              return data['course']['courseCode'];
            case 'sectionName':
              return data['section']['name'];
            case 'entranceYear':
              return data['section']['entranceYear'];
            default:
              return data[sortHeaderId];
          }
        };
      },
        (error) => console.error(error));
  }

  createCourseOfferings() {
    const deptId = this.userService.decodedToken.dept_id;
    this.commonService.createCourseOfferings(deptId)
      .subscribe((result: any[]) => {
        this.courseOfferings = result;
        this.dataSource.data = this.courseOfferings;
        this.changeDetectorRefs.detectChanges();
      },
        (error) => console.error(error));
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
      title: 'Delete Course Offering?',
      message: 'Are you you want to delete this course offering?'
    };

    const dialogRef = this.dialog.open(DeleteDialogComponent, dialogConfig);
    dialogRef.afterClosed()
      .subscribe(result => {
        if (result) {
          this.commonService.deleteCourseOffering(id)
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

  isAssignmentCompleted(courseOffering) {
    const instAssignmentCompleted = !(courseOffering.instructors.some(x => x.instructor === null));
    const roomAssignmentCompleted = !(courseOffering.rooms.some(x => x.room === null));

    return instAssignmentCompleted || roomAssignmentCompleted;
  }
}
