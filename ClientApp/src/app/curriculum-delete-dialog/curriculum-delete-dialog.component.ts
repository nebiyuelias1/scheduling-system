import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-curriculum-delete-dialog',
  templateUrl: './curriculum-delete-dialog.component.html',
  styleUrls: ['./curriculum-delete-dialog.component.css']
})
export class CurriculumDeleteDialogComponent implements OnInit {

  constructor(
    private dialogRef: MatDialogRef<CurriculumDeleteDialogComponent>,
    @Inject(MAT_DIALOG_DATA) data) { }

  ngOnInit() {
  }

  close() {
    this.dialogRef.close();
  }

  delete() {
    this.dialogRef.close(true);
  }
}
