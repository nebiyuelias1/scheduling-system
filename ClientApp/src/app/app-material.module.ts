import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { A11yModule } from '@angular/cdk/a11y';
import { CdkStepperModule } from '@angular/cdk/stepper';
import { CdkTableModule } from '@angular/cdk/table';
import { CdkTreeModule } from '@angular/cdk/tree';
import {
    MatAutocompleteModule, MatBadgeModule, MatBottomSheetModule,
    MatButtonModule, MatButtonToggleModule, MatCardModule, MatCheckboxModule,
    MatChipsModule, MatStepperModule, MatDatepickerModule, MatDialogModule,
    MatDividerModule, MatExpansionModule, MatGridListModule, MatIconModule,
    MatInputModule, MatListModule, MatMenuModule, MatNativeDateModule,
    MatPaginatorModule, MatProgressBarModule, MatProgressSpinnerModule,
    MatRadioModule, MatRippleModule, MatSelectModule, MatSidenavModule,
    MatSliderModule, MatSlideToggleModule, MatSnackBarModule, MatSortModule,
    MatTableModule, MatTabsModule, MatToolbarModule, MatTooltipModule,
    MatTreeModule,
    MatFormFieldModule,
    MatOptionModule
} from '@angular/material';
import { PortalModule } from '@angular/cdk/portal';
import { ScrollingModule } from '@angular/cdk/scrolling';

@NgModule({
    exports: [
        A11yModule,
        CdkStepperModule,
        CdkTableModule,
        CdkTreeModule,
        MatAutocompleteModule,
        MatBadgeModule,
        MatBottomSheetModule,
        MatButtonModule,
        MatButtonToggleModule,
        MatCardModule,
        MatCheckboxModule,
        MatChipsModule,
        MatStepperModule,
        MatDatepickerModule,
        MatDialogModule,
        MatDividerModule,
        MatExpansionModule,
        MatGridListModule,
        MatIconModule,
        MatInputModule,
        MatListModule,
        MatMenuModule,
        MatNativeDateModule,
        MatPaginatorModule,
        MatProgressBarModule,
        MatProgressSpinnerModule,
        MatRadioModule,
        MatRippleModule,
        MatSelectModule,
        MatSidenavModule,
        MatSliderModule,
        MatSlideToggleModule,
        MatSnackBarModule,
        MatSortModule,
        MatTableModule,
        MatTabsModule,
        MatToolbarModule,
        MatTooltipModule,
        MatTreeModule,
        PortalModule,
        ScrollingModule,
        MatPaginatorModule,
        MatFormFieldModule,
        MatOptionModule,
    ],
    providers: [],
})
export class AppMaterialModule { }
