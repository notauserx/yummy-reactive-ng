import { NgModule } from '@angular/core';
import { RecipeService } from './services/recipe.service';
import { PrimeNgModule } from '../primeng.module';
import { RecipeListComponent } from './components/recipe-list/recipe-list.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RecipeDetailComponent } from './components/recipe-detail/recipe-detail.component';
import { RecipesRoutingModule } from './recipe-routing.module';

@NgModule({
  declarations: [
    RecipeListComponent,
    RecipeDetailComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    PrimeNgModule,
    RecipesRoutingModule,
  ],
  providers: [
    RecipeService,
  ]
})
export class RecipeModule { }
