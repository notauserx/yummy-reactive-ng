import { NgModule } from '@angular/core';
import { RecipeService } from './services/recipe.service';
import { PrimeNgModule } from '../primeng.module';
import { RecipeListComponent } from './components/recipe-list/recipe-list.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [
    RecipeListComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    PrimeNgModule,
  ],
  providers: [
    RecipeService,
  ]
})
export class RecipeModule { }
