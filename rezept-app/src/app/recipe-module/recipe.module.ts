import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RecipeService } from './services/recipe.service';
import { PrimeNgModule } from '../primeng.module';
import { RecipeListComponent } from './components/recipe-list/recipe-list.component';



@NgModule({
  declarations: [
    RecipeListComponent
  ],
  imports: [
    CommonModule,
    PrimeNgModule
  ],
  providers: [
    RecipeService
  ]
})
export class RecipeModule { }
