import { Component, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource, MatDialogConfig, MatDialog } from '@angular/material';
import { DepartmentService } from '../services/department.service';
import { DeleteDialogComponent } from '../delete-dialog/delete-dialog.component';

@Component({
  selector: 'app-department-list',
  templateUrl: './department-list.component.html',
  styleUrls: ['./department-list.component.css']
})
export class DepartmentListComponent implements OnInit {
  @ViewChild(MatPaginator, null) paginator: MatPaginator;
  @ViewChild(MatSort, null) sort: MatSort;
  departments: any[];
  dataSource: MatTableDataSource<any>;
  displayedColumns = ['departmentName', 'departmentHead', 'action'];

  constructor(
    private departmentService: DepartmentService,
    private dialog: MatDialog,
    private changeDetectorRefs: ChangeDetectorRef) { }

  ngOnInit() {
    this.departmentService.getDepartments()
      .subscribe((result: any[]) => {
        this.departments = result;
        this.dataSource = new MatTableDataSource<any>(this.departments);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
        this.paginator.length = this.dataSource.data.length;
        this.paginator._changePageSize(this.paginator.pageSize);
      });
  }

  buttonClicked(id) {
    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = '400px';

    dialogConfig.data = {
      id: id,
      title: 'Remove Department Head Assignment?',
      message: 'Are you you want to remove the assignment?'
    };

    const dialogRef = this.dialog.open(DeleteDialogComponent, dialogConfig);
    dialogRef.afterClosed()
      .subscribe(result => {
        if (result) {
          this.departmentService.removeAssignment(id)
            .subscribe(x => {
              const itemIndex = this.dataSource.data.findIndex(obj => obj.id === id);
              this.dataSource.data[itemIndex].departmentHead = null;
              this.dataSource.paginator = this.paginator;
              this.changeDetectorRefs.detectChanges();
            },
              err => console.error(err));
        }
      });
  }

}
