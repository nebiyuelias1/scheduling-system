import { Component, OnInit, ViewChild } from '@angular/core';
import { SectionService } from '../services/section.service';
import { UserService } from '../accounts/user.service';
import { MatTableDataSource, MatSort, MatPaginator } from '@angular/material';

@Component({
  selector: 'app-schedule-list',
  templateUrl: './schedule-list.component.html',
  styleUrls: ['./schedule-list.component.css']
})
export class ScheduleListComponent implements OnInit {
  @ViewChild(MatPaginator, null) paginator: MatPaginator;
  @ViewChild(MatSort, null) sort: MatSort;

  sections: any;
  dataSource: MatTableDataSource<any>;
  displayedColumns = ['name', 'entranceYear', 'studentCount', 'program', 'admissionLevel', 'action'];
  searchKey: string;

  constructor(
    private sectionService: SectionService,
    private userService: UserService
  ) { }

  ngOnInit() {
    const query = {
      departmentId: this.userService.decodedToken.dept_id,
      includeSchedule: true
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

      }, (err) => console.error(err));
  }

  clearSearchKey() {
    this.searchKey = '';
    this.applyFilter();
  }

  applyFilter() {
    this.dataSource.filter = this.searchKey.trim().toLowerCase();
  }

}
