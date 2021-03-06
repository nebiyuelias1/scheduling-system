import { Component, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { MatPaginator, MatSort, MatDialog, MatDialogConfig, MatTable, MatTableDataSource } from '@angular/material';
import { SaveCurriculum } from '../models/save-curriculum-interface';
import { DeleteDialogComponent } from '../delete-dialog/delete-dialog.component';
import { CurriculumService } from '../services/curriculum.service';
import { UserService } from '../accounts/user.service';

@Component({
  selector: 'app-curriculum-list',
  templateUrl: './curriculum-list.component.html',
  styleUrls: ['./curriculum-list.component.css']
})
export class CurriculumListComponent implements OnInit {
  @ViewChild(MatPaginator, null) paginator: MatPaginator;
  @ViewChild(MatSort, null) sort: MatSort;

  curriculums: SaveCurriculum[];
  dataSource: MatTableDataSource<any>;
  displayedColumns = ['nomenclature', 'stayYear', 'staySemester', 'action'];
  searchKey: string;

  constructor(
    private curriculumService: CurriculumService,
    private dialog: MatDialog,
    private changeDetectorRefs: ChangeDetectorRef,
    private userService: UserService) { }

  ngOnInit() {
    const query = {
      departmentId: this.userService.decodedToken.dept_id,
    };

    this.curriculumService.getCurriculums(query)
      .subscribe((result: any) => {
        this.curriculums = result.items;
        this.dataSource = new MatTableDataSource<any>(this.curriculums);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
        this.paginator.length = this.dataSource.data.length;
        this.paginator._changePageSize(this.paginator.pageSize);

        this.dataSource.filterPredicate = (data, filter) => {
          return this.displayedColumns.some(d => {
            return d !== 'action' && data[d].toString().toLowerCase().indexOf(filter) !== -1;
          });
        };
      });
  }

  openDeleteDialog(id) {
    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = '400px';

    dialogConfig.data = {
      id: id,
      title: 'Delete Curriculum?',
      message: 'Are you you want to delete this curriculum?'
    };

    const dialogRef = this.dialog.open(DeleteDialogComponent, dialogConfig);
    dialogRef.afterClosed()
      .subscribe(result => {
        if (result) {
          this.curriculumService.delete(id)
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

  clearSearchKey() {
    this.searchKey = '';
    this.applyFilter();
  }

  applyFilter() {
    this.dataSource.filter = this.searchKey.trim().toLowerCase();
  }
}
