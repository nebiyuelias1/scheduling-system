import { Component, OnInit } from '@angular/core';
import { CommonService } from '../services/common.service';
import { UserService } from '../accounts/user.service';

@Component({
  selector: 'app-home-header',
  templateUrl: './home-header.component.html',
  styleUrls: ['./home-header.component.css']
})
export class HomeHeaderComponent implements OnInit {
  currentAcacemicSemester;

  constructor(private commonService: CommonService, private userService: UserService) {  }

  ngOnInit() {
    this.commonService.getCurrentAcademicSemester()
      .subscribe(x => this.currentAcacemicSemester = x);
  }

}
