import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RecipeDetailComponent } from './components/recipe-detail/recipe-detail.component';
import { RecipeListComponent } from './components/recipe-list/recipe-list.component';

const recipesRoutes: Routes = [
  { path: '',  component: RecipeListComponent },
  { path: 'recipes',  component: RecipeListComponent },
  { path: 'recipe/:id', component: RecipeDetailComponent }
];

@NgModule({
  imports: [
    RouterModule.forChild(recipesRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class RecipesRoutingModule { }