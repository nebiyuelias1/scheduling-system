import { Component, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource, MatDialog, MatDialogConfig } from '@angular/material';
import { RoomService } from '../services/room.service';
import { DeleteDialogComponent } from '../delete-dialog/delete-dialog.component';
import { CommonService } from '../services/common.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-rooms-list',
  templateUrl: './rooms-list.component.html',
  styleUrls: ['./rooms-list.component.css']
})
export class RoomsListComponent implements OnInit {
  @ViewChild(MatPaginator, null) paginator: MatPaginator;
  @ViewChild(MatSort, null) sort: MatSort;

  rooms: any[];
  dataSource: MatTableDataSource<any>;
  displayedColumns = ['name', 'building', 'size', 'floor', 'types', 'action'];
  searchKey: string;
  selectedValue = -1;
  types: any[];

  constructor(
    private roomService: RoomService,
    private commonService: CommonService,
    private changeDetectorRefs: ChangeDetectorRef,
    private dialog: MatDialog
  ) { }

  ngOnInit() {
    const sources = [this.roomService.getRooms({}), this.commonService.getTypes()];

    Observable.forkJoin(sources)
      .subscribe((x: any) => {
        this.rooms = x[0].items;
        this.types = x[1];
        this.dataSource = new MatTableDataSource<any>(this.rooms);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
        this.paginator.length = this.dataSource.data.length;
        this.paginator._changePageSize(this.paginator.pageSize);

        this.dataSource.filterPredicate = (data, filter) => {
          const nameColumnFound = data.name.toString().toLowerCase().indexOf(filter) !== -1;
          const building = data.building;
          const buildingColumnFound = (building.name.toString().toLowerCase() + '-' +
            building.number.toString().toLowerCase()).indexOf(filter) !== -1;

          const sizeColumnFound = data.size.toString().toLowerCase().indexOf(filter) !== -1;

          return (nameColumnFound || buildingColumnFound || sizeColumnFound);
        };

        this.dataSource.sortingDataAccessor = (data, sortHeaderId) => {
          switch (sortHeaderId) {
            case 'building':
              return data['building']['name'] + '-' + data['building']['number'];
            default:
              return data[sortHeaderId];
          }
        };
      }, err => console.error(err));
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
      title: 'Delete Room?',
      message: 'Are you you want to delete this room?'
    };

    const dialogRef = this.dialog.open(DeleteDialogComponent, dialogConfig);
    dialogRef.afterClosed()
      .subscribe(result => {
        if (result) {
          this.roomService.delete(id)
            .subscribe(x => {
              const itemIndex = this.rooms.findIndex(obj => obj.id === id);
              this.rooms.splice(itemIndex, 1);
              this.dataSource.data = this.rooms;
              this.dataSource.paginator = this.paginator;
              this.changeDetectorRefs.detectChanges();
            },
              err => console.error(err));
        }
      });
  }

  onTypeChange() {
    if (+this.selectedValue === -1) {
      this.dataSource.data = this.rooms;
    } else {
      this.dataSource.data = this.rooms;
      const filtered = this.dataSource.data.filter(val => {
        return val.types.some(t => {
          return t.id === this.selectedValue;
        });
      });

      this.dataSource.data = filtered;
    }

    this.dataSource.paginator = this.paginator;
    this.changeDetectorRefs.detectChanges();
  }
}
