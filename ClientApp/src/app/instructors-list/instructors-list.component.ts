import { Component, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource, MatDialog, MatDialogConfig } from '@angular/material';
import { InstructorService } from '../services/instructor.service';
import { DeleteDialogComponent } from '../delete-dialog/delete-dialog.component';
import { UserService } from '../accounts/user.service';

@Component({
  selector: 'app-instructors-list',
  templateUrl: './instructors-list.component.html',
  styleUrls: ['./instructors-list.component.css']
})
export class InstructorsListComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  instructors: any[];
  dataSource: MatTableDataSource<any>;
  displayedColumns = ['firstName', 'fatherName', 'grandFatherName', 'action'];
  searchKey: string;

  constructor(
    private instructorService: InstructorService,
    private dialog: MatDialog,
    private changeDetectorRefs: ChangeDetectorRef,
    private userService: UserService
  ) { }

  ngOnInit() {
    this.instructorService.getInstructorsWithinADept(this.userService.decodedToken.dept_id)
      .subscribe((result: any[]) => {
        this.instructors = result;
        this.dataSource = new MatTableDataSource<any>(this.instructors);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
        this.paginator.length = this.dataSource.data.length;
        this.paginator._changePageSize(this.paginator.pageSize);

        this.dataSource.filterPredicate = (data, filter) => {
          const firstName = data['user']['firstName'].toString().toLowerCase().indexOf(filter);
          const fatherName = data['user']['fatherName'].toString().toLowerCase().indexOf(filter);
          const grandFatherName = data['user']['grandFatherName'].toString().toLowerCase().indexOf(filter);

          return firstName !== -1
          || fatherName !== -1
          || grandFatherName !== -1;
      };

        this.dataSource.sortingDataAccessor = (data, sortHeaderId) => {
          switch (sortHeaderId) {
            case 'firstName':
              return data['user']['firstName'];
            case 'fatherName':
              return data['user']['fatherName'];
            case 'grandFatherName':
              return data['user']['grandFatherName'];
            default:
              return data[sortHeaderId];
          }
        };
      },
        (err) => console.error(err));
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
      title: 'Delete Instructor?',
      message: 'Are you you want to delete this instructor?'
    };

    const dialogRef = this.dialog.open(DeleteDialogComponent, dialogConfig);
    dialogRef.afterClosed()
      .subscribe(result => {
        if (result) {
          this.instructorService.delete(id)
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
}
