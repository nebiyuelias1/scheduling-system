import { Component, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { CollegeService } from '../services/college.service';
import { MatPaginator, MatSort, MatTableDataSource, MatDialogConfig, MatDialog } from '@angular/material';
import { DeleteDialogComponent } from '../delete-dialog/delete-dialog.component';

@Component({
  selector: 'app-college-list',
  templateUrl: './college-list.component.html',
  styleUrls: ['./college-list.component.css']
})
export class CollegeListComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  colleges: any[];
  dataSource: MatTableDataSource<any>;
  displayedColumns = ['collegeName', 'collegeDean', 'action'];

  constructor(private collegeService: CollegeService,
    private dialog: MatDialog,
    private changeDetectorRefs: ChangeDetectorRef
  ) { }

  ngOnInit() {
    this.collegeService.getColleges()
      .subscribe((result: any[]) => {
        this.colleges = result;
        this.dataSource = new MatTableDataSource<any>(this.colleges);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
        this.paginator.length = this.dataSource.data.length;
        this.paginator._changePageSize(this.paginator.pageSize);

        this.dataSource.sortingDataAccessor = (data, sortHeaderId) => {
          switch (sortHeaderId) {
            case 'collegeName':
              return data['name'];
            default:
              return data[sortHeaderId];
          }
        };
      });
  }

  removeAssignment(id) {
    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = '400px';

    dialogConfig.data = {
      id: id,
      title: 'Remove College Dean Assign?',
      message: 'Are you you want to remove the assignment?'
    };

    const dialogRef = this.dialog.open(DeleteDialogComponent, dialogConfig);
    dialogRef.afterClosed()
      .subscribe(result => {
        if (result) {
          this.collegeService.removeAssignment(id)
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

  buttonClicked(id) {
    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = '400px';

    dialogConfig.data = {
      id: id,
      title: 'Remove College Dean Assign?',
      message: 'Are you you want to remove the assignment?'
    };

    const dialogRef = this.dialog.open(DeleteDialogComponent, dialogConfig);
    dialogRef.afterClosed()
      .subscribe(result => {
        if (result) {
          this.collegeService.removeAssignment(id)
            .subscribe(x => {
              const itemIndex = this.dataSource.data.findIndex(obj => obj.id === id);
              this.dataSource.data[itemIndex].collegeDean = null;
              this.dataSource.paginator = this.paginator;
              this.changeDetectorRefs.detectChanges();
            },
              err => console.error(err));
        }
      });
  }
}
