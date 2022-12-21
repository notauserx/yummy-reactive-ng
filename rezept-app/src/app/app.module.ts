import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { RecipiesService } from './services/recipies.service';

import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { RecipeListComponent } from './components/recipe-list/recipe-list.component';

import {DataViewModule} from 'primeng/dataview';
import {ButtonModule} from 'primeng/button';
import {PanelModule} from 'primeng/panel';
import {DropdownModule} from 'primeng/dropdown';
import {DialogModule} from 'primeng/dialog';
import {InputTextModule} from 'primeng/inputtext';
import {RatingModule} from 'primeng/rating';
import {RippleModule} from 'primeng/ripple';
import { HeaderComponent } from './components/layout/header/header.component';
import { ContainerComponent } from './components/layout/container/container.component';

@NgModule({
  declarations: [
    AppComponent,
    RecipeListComponent,
    HeaderComponent,
    ContainerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    
    DataViewModule,
    ButtonModule,
    PanelModule,
    DropdownModule,
    DialogModule,
    InputTextModule,
    RatingModule,
    RippleModule
  ],
  providers: [RecipiesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
