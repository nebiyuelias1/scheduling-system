import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SectionService } from '../services/section.service';

@Component({
  selector: 'app-section-detail',
  templateUrl: './section-detail.component.html',
  styleUrls: ['./section-detail.component.css']
})
export class SectionDetailComponent implements OnInit {
  section: any;

  constructor(private route: ActivatedRoute,
    private sectionService: SectionService) { }

  ngOnInit() {
    const sectionId = +this.route.snapshot.paramMap.get('id');
    this.sectionService.getSection(sectionId)
      .subscribe((result) => this.section = result,
      (error) => console.error(error));
  }

}
