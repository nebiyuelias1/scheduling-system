import { Component, OnInit, ViewChild } from '@angular/core';
import { CommonService } from '../services/common.service';
import { MatPaginator, MatSort, MatDialog, MatDialogConfig, MatTable } from '@angular/material';
import { CurriculumDataSource } from './curriculum-list-datasource';
import { SaveCurriculum } from '../models/save-curriculum-interface';
import { CurriculumDeleteDialogComponent } from '../curriculum-delete-dialog/curriculum-delete-dialog.component';
import { CurriculumService } from '../services/curriculum.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-curriculum-list',
  templateUrl: './curriculum-list.component.html',
  styleUrls: ['./curriculum-list.component.css']
})
export class CurriculumListComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatTable) table: MatTable<SaveCurriculum[]>

  curriculums: SaveCurriculum[];
  dataSource: CurriculumDataSource;
  displayedColumns = ['nomenclature', 'stayYear', 'staySemester', 'action'];
    
  constructor(
    private curriculumService: CurriculumService,
    private dialog: MatDialog,
    private router: Router) { }

  ngOnInit() {
    this.curriculumService.getCurriculums()
      .subscribe((result: SaveCurriculum[]) => {
        this.curriculums = result;
        this.dataSource = new CurriculumDataSource(this.paginator, this.sort, this.curriculums);
      });
  }

  openDeleteDialog(id) {
    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;

    dialogConfig.data = {
      id: id,
      title: 'Delete Curriculum'
    };

    const dialogRef = this.dialog.open(CurriculumDeleteDialogComponent, dialogConfig);
    dialogRef.afterClosed()
      .subscribe(result => {
        if (result == true) {
          this.curriculumService.delete(id)
            .subscribe(x => {
              console.log('before removing', this.table);

              let curriculum = this.curriculums.find(c => c.id == x);
              let index = this.curriculums.indexOf(curriculum);
              this.curriculums.splice(index, 1);
              this.dataSource.data = this.curriculums;
              this.table.renderRows();
              console.log('after removing', this.table, this.curriculums);
            }, 
            err => console.error(err));
        }
      });
  }  
}
