import { Component, OnInit } from '@angular/core';
import { CommonService } from '../services/common.service';

@Component({
  selector: 'app-home-header',
  templateUrl: './home-header.component.html',
  styleUrls: ['./home-header.component.css']
})
export class HomeHeaderComponent implements OnInit {
  currentAcacemicSemester;

  constructor(private commonService: CommonService) {  }

  ngOnInit() {
    this.commonService.getCurrentAcademicSemester()
      .subscribe(x => this.currentAcacemicSemester = x);
  }

}
