import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { CommonService } from '../services/common.service';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { InstructorService } from '../services/instructor.service';
import { UserService } from '../accounts/user.service';

@Component({
  selector: 'app-assign-instructor',
  templateUrl: './assign-instructor.component.html',
  styleUrls: ['./assign-instructor.component.css']
})
export class AssignInstructorComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  courseOffering;
  typeId;
  instructors;
  dataSource: MatTableDataSource<any>;
  displayedColumns = ['firstName', 'fatherName', 'grandFatherName', 'action'];
  searchKey: string;

  constructor(private route: ActivatedRoute,
    private commonService: CommonService,
    private instructorService: InstructorService,
    private userService: UserService,
    private router: Router) { }

  ngOnInit() {
    this.typeId = this.route.snapshot.paramMap.get('typeId');

    this.route.parent.params
      .subscribe(x => {
        this.commonService.getCourseOffering(x.id)
          .subscribe(co => this.courseOffering = co,
            err => console.error(err));
      });

    const query = {
      departmentId: this.userService.decodedToken.dept_id
    };

    this.instructorService.getInstructors(query)
      .subscribe((i: any) => {
        this.instructors = i.items;
        this.dataSource = new MatTableDataSource<any>(this.instructors);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
        this.paginator.length = this.dataSource.data.length;
        this.paginator._changePageSize(this.paginator.pageSize);

        this.dataSource.filterPredicate = (data, filter) => {
          const firstName = data['firstName'].toString().toLowerCase().indexOf(filter);
          const fatherName = data['fatherName'].toString().toLowerCase().indexOf(filter);
          const grandFatherName = data['grandFatherName'].toString().toLowerCase().indexOf(filter);

          return firstName !== -1
            || fatherName !== -1
            || grandFatherName !== -1;
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

  assign(id) {
    this.commonService.assignToCourseOffering({
      courseOfferingId: this.courseOffering.id,
      instructorId: id,
      typeId: this.typeId
    })
    .subscribe(x => {
      this.router.navigate(['courseofferings', this.courseOffering.id]);
    }, err => console.error(err));
  }
}
