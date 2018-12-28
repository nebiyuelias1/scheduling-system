import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-section-detail',
  templateUrl: './section-detail.component.html',
  styleUrls: ['./section-detail.component.css']
})
export class SectionDetailComponent implements OnInit {
  sectionId: number;

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.sectionId = +this.route.snapshot.paramMap.get('id'); 
  }

}
