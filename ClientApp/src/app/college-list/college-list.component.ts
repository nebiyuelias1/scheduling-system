import { Component, OnInit } from '@angular/core';
import { CollegeService } from '../services/college.service';

@Component({
  selector: 'app-college-list',
  templateUrl: './college-list.component.html',
  styleUrls: ['./college-list.component.css']
})
export class CollegeListComponent implements OnInit {
  colleges: any[];

  constructor(private collegeService: CollegeService) { }

  ngOnInit() {
    this.collegeService.getColleges()
      .subscribe((result: any[]) => {
        this.colleges = result;
      });
  }

}
