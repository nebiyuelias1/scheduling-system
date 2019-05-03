import { Component, OnInit, ViewChild } from '@angular/core';
import { CommonService } from '../services/common.service';
import { MatPaginator, MatSort } from '@angular/material';
import { CurriculumDataSource } from './curriculum-list-datasource';
import { SaveCurriculum } from '../models/save-curriculum-interface';

@Component({
  selector: 'app-curriculum-list',
  templateUrl: './curriculum-list.component.html',
  styleUrls: ['./curriculum-list.component.css']
})
export class CurriculumListComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  curriculums: SaveCurriculum[];
  dataSource: CurriculumDataSource;
  displayedColumns = ['nomenclature', 'stayYear', 'staySemester', 'action'];
    
  constructor(private commonService: CommonService) { }

  ngOnInit() {
    this.commonService.getCurriculums()
      .subscribe((result: SaveCurriculum[]) => {
        this.curriculums = result;
        this.dataSource = new CurriculumDataSource(this.paginator, this.sort, this.curriculums);
      });
  }

}
