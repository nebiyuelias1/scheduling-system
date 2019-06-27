import { Component, OnInit } from '@angular/core';
import { CommonService } from '../services/common.service';
import { FormGroup, FormControl } from '@angular/forms';
import { SectionService } from '../services/section.service';
import { SaveSection } from '../models/save-section-interface';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { CurriculumService } from '../services/curriculum.service';
import { UserService } from '../accounts/user.service';

@Component({
  selector: 'app-section-form',
  templateUrl: './section-form.component.html',
  styleUrls: ['./section-form.component.css']
})
export class SectionFormComponent implements OnInit {
  section: SaveSection = {
    id: 0,
    admissionLevelId: 0,
    departmentId: 0,
    entranceYear: 0,
    programTypeId: 0,
    studentCount: 0,
    name: ''
  };

  programTypes: any[];
  admissionLevels: any[];
  form = new FormGroup({
    name: new FormControl(),
    entranceYear: new FormControl(),
    studentCount: new FormControl(),
    curriculumId: new FormControl(),
    programTypeId: new FormControl(),
    admissionLevelId: new FormControl()
  });
  curriculums: any;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private commonService: CommonService,
    private sectionService: SectionService,
    private curriculumService: CurriculumService,
    private userService: UserService) {
      this.route.params
      .subscribe(x => this.section.id = +x['id'] || 0);
    }

  ngOnInit() {
    const query = {
      departmentId: this.userService.decodedToken.dept_id,
    };

    const sources = [
      this.commonService.getProgramTypes(),
      this.commonService.getAdmissionLevels(),
      this.curriculumService.getCurriculums(query)
    ];

    if (this.section.id) {
      sources.push(this.commonService.getSection(this.section.id));
    }

    Observable.forkJoin(sources)
      .subscribe((data: any) => {
        this.programTypes = data[0];
        this.admissionLevels = data[1];
        this.curriculums = data[2].items;

        if (this.section.id) {
          this.setVehicle(data[3]);
          this.populateForm();
        }
      });
  }

  populateForm() {
    this.form.get('name').setValue(this.section.name);
    this.form.get('entranceYear').setValue(this.section.entranceYear);
    this.form.get('studentCount').setValue(this.section.studentCount);
    this.form.get('departmentId').setValue(this.section.departmentId);
    this.form.get('programTypeId').setValue(this.section.programTypeId);
    this.form.get('admissionLevelId').setValue(this.section.admissionLevelId);
  }

  submit() {
    const result$ = (this.section.id) ?
      this.sectionService.update(this.section.id, this.form.value) :
      this.sectionService.save(this.form.value);

    result$.subscribe(x => {
      this.router.navigate(['/sections']);
    }, err => console.error(err));
  }

  private setVehicle(s: SaveSection) {
    this.section.id = s.id;
    this.section.name = s.name;
    this.section.entranceYear = s.entranceYear;
    this.section.studentCount = s.studentCount;
    this.section.departmentId = s.departmentId;
    this.section.programTypeId = s.programTypeId;
    this.section.admissionLevelId = s.admissionLevelId;
  }
}
