import { Component, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { SectionService } from '../services/section.service';
import { MatPaginator, MatSort, MatTableDataSource, MatTable, MatDialogConfig, MatDialog } from '@angular/material';
import { DeleteDialogComponent } from '../delete-dialog/delete-dialog.component';
import { UserService } from '../accounts/user.service';

@Component({
  selector: 'app-section-list',
  templateUrl: './section-list.component.html',
  styleUrls: ['./section-list.component.css']
})
export class SectionListComponent implements OnInit {
  @ViewChild(MatPaginator, null) paginator: MatPaginator;
  @ViewChild(MatSort, null) sort: MatSort;

  sections: any[];
  dataSource: MatTableDataSource<any>;
  displayedColumns = ['name', 'entranceYear', 'studentCount', 'program', 'admissionLevel', 'action'];
  searchKey: string;

  constructor(
    private sectionService: SectionService,
    private dialog: MatDialog,
    private changeDetectorRefs: ChangeDetectorRef,
    private userService: UserService) { }

  ngOnInit() {
    const query = {
      departmentId: this.userService.decodedToken.dept_id
    };

    this.sectionService.getSections(query)
      .subscribe((result: any) => {
        this.sections = result.items;
        this.dataSource = new MatTableDataSource<any>(this.sections);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
        this.paginator.length = this.dataSource.data.length;
        this.paginator._changePageSize(this.paginator.pageSize);

        this.dataSource.filterPredicate = (data, filter) => {
           return this.displayedColumns.some(d => {
             return d !== 'action' && data[d].toString().toLowerCase().indexOf(filter) !== -1;
           });
        };
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
      title: 'Delete Section?',
      message: 'Are you you want to delete this section?'
    };

    const dialogRef = this.dialog.open(DeleteDialogComponent, dialogConfig);
    dialogRef.afterClosed()
      .subscribe(result => {
        if (result) {
          this.sectionService.delete(id)
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
