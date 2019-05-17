import { Component, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource, MatDialog } from '@angular/material';
import { InstructorService } from '../services/instructor.service';

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
    private changeDetectorRefs: ChangeDetectorRef
  ) { }

  ngOnInit() {
    this.instructorService.getInstructors()
      .subscribe((result: any[]) => {
        this.instructors = result;
        this.dataSource = new MatTableDataSource<any>(this.instructors);
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
        (err) => console.error(err));
  }

  clearSearchKey() {
    this.searchKey = '';
    this.applyFilter();
  }

  applyFilter() {
    this.dataSource.filter = this.searchKey.trim().toLowerCase();
  }

}
