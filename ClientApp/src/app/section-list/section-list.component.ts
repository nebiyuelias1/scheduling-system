import { Component, OnInit, ViewChild } from '@angular/core';
import { SectionService } from '../services/section.service';
import { MatPaginator, MatSort, MatTableDataSource, MatTable } from '@angular/material';

@Component({
  selector: 'app-section-list',
  templateUrl: './section-list.component.html',
  styleUrls: ['./section-list.component.css']
})
export class SectionListComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  sections: any[];
  dataSource: MatTableDataSource<any>;
  displayedColumns = ['name', 'entranceYear', 'studentCount', 'program', 'admissionLevel', 'action'];
  searchKey: string;

  constructor(private sectionService: SectionService) { }

  ngOnInit() {
    this.sectionService.getSections()
      .subscribe((result: any[]) => {
        this.sections = result;
        this.dataSource = new MatTableDataSource<any>(this.sections);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
        this.paginator.length = this.dataSource.data.length;
        this.paginator._changePageSize(this.paginator.pageSize);

        // this.dataSource.filterPredicate = (data, filter) => {
        //   return this.displayedColumns.some(d => {
        //     return d !== 'action' && data[d].toString().toLowerCase().indexOf(filter) !== -1;
        //   });
        // };
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
}
