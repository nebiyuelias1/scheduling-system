import { Component, OnInit } from '@angular/core';
import { SectionService } from '../services/section.service';

@Component({
  selector: 'app-section-list',
  templateUrl: './section-list.component.html',
  styleUrls: ['./section-list.component.css']
})
export class SectionListComponent implements OnInit {
  sections: any[];

  constructor(private sectionService: SectionService) { }

  ngOnInit() {
    this.sectionService.getSections()
      .subscribe((result: any[]) => this.sections = result,
        (error) => console.error(error));
  }

}
