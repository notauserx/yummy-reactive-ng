import { ChangeDetectionStrategy, Component } from '@angular/core';
import { catchError, EMPTY } from 'rxjs';
import { RecipeService } from '../../services/recipe.service';

@Component({
  selector: 'app-recipe-list',
  templateUrl: './recipe-list.component.html',
  styleUrls: ['./recipe-list.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class RecipeListComponent {
  recipeList$ = this.service.recipeList$
    .pipe(
      catchError(_ => EMPTY)
    );

  filter: RecipeFilter = {searchTerm: ''}
  
  constructor(private service : RecipeService) { }

  onSearch() {
    console.log(this.filter)
    this.recipeList$ = this.service.getFilteredRecipes(this.filter.searchTerm);


  }
}

interface RecipeFilter{
  searchTerm: string,
}