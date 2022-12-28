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
  
  constructor(private service : RecipeService) { }
}
