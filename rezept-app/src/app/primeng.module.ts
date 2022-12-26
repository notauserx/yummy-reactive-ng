import { NgModule } from '@angular/core';
import {DataViewModule} from 'primeng/dataview';
import {ButtonModule} from 'primeng/button';
import {PanelModule} from 'primeng/panel';
import {DropdownModule} from 'primeng/dropdown';
import {DialogModule} from 'primeng/dialog';
import {InputTextModule} from 'primeng/inputtext';
import {RatingModule} from 'primeng/rating';
import {RippleModule} from 'primeng/ripple';

@NgModule({
  exports: [
    DataViewModule,
    ButtonModule,
    PanelModule,
    DropdownModule,
    DialogModule,
    InputTextModule,
    RatingModule,
    RippleModule
  ]
})

export class PrimeNgModule {}