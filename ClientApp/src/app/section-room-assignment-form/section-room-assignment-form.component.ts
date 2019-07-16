import { Component, OnInit, ViewChild } from '@angular/core';
import { CommonService } from '../services/common.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl } from '@angular/forms';
import { RoomService } from '../services/room.service';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';

@Component({
  selector: 'app-section-room-assignment-form',
  templateUrl: './section-room-assignment-form.component.html',
  styleUrls: ['./section-room-assignment-form.component.css']
})
export class SectionRoomAssignmentFormComponent implements OnInit {
  @ViewChild(MatPaginator, null) paginator: MatPaginator;
  @ViewChild(MatSort, null) sort: MatSort;
  typeId;
  rooms: any[];
  courseOffering;
  dataSource: MatTableDataSource<any>;
  displayedColumns = ['name', 'building', 'size', 'floor', 'action'];
  searchKey: string;

  constructor(
    private commonService: CommonService,
    private roomService: RoomService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit() {
    this.typeId = this.route.snapshot.paramMap.get('typeId');
    const query: any = {
      typeId: this.typeId
    };


    this.route.parent.params
      .subscribe(x => {
        this.commonService.getCourseOffering(x.id)
          .subscribe(co => {
            this.courseOffering = co;

            if (this.typeId === '2') {
              query.labTypeId = this.courseOffering.course.labTypeId;
            }

            this.roomService.getRooms(query)
              .subscribe((r: any) => {
                this.rooms = r.items;
                this.dataSource = new MatTableDataSource<any>(this.rooms);
                this.dataSource.sort = this.sort;
                this.dataSource.paginator = this.paginator;
                this.paginator.length = this.dataSource.data.length;
                this.paginator._changePageSize(this.paginator.pageSize);

                this.dataSource.filterPredicate = (data, filter) => {
                  const nameFound = data['name'].toString().toLowerCase().indexOf(filter);
                  const buildingString = data['building']['name'] + '-' + data['building']['number'];
                  const buildingFound = buildingString.toString().toLowerCase().indexOf(filter);

                  return nameFound !== -1
                    || buildingFound !== -1;
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
          },
            err => console.error(err));
      });


  }

  clearSearchKey() {
    this.searchKey = '';
    this.applyFilter();
  }

  applyFilter() {
    this.dataSource.filter = this.searchKey.trim().toLowerCase();
  }

  assign(id) {
    this.commonService.assignToCourseOffering({
      courseOfferingId: this.courseOffering.id,
      roomId: id,
      typeId: this.typeId
    })
      .subscribe(x => {
        this.router.navigate(['courseofferings', this.courseOffering.id]);
      }, err => console.error(err));
  }

}
