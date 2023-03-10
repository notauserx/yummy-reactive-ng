import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { RecipeFilter } from 'src/app/models/recipeFilter';
import { RecipeListResponse } from 'src/app/models/RecipeListResponse';
import { RecipeService } from '../../services/recipe.service';

@Component({
  selector: 'app-recipe-list',
  templateUrl: './recipe-list.component.html',
  styleUrls: ['./recipe-list.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class RecipeListComponent implements OnInit {
  
  recipeCategoryList$ = this.service.recipeCategoryList$
  recipeResponse$: Observable<RecipeListResponse>| undefined;

  filter: RecipeFilter = {
    searchTerm: '',
    category: '',
    pageNumber: 1,
    pageSize: 9
  }
  
  constructor(private service : RecipeService) { }
  
  ngOnInit(): void {
    this.recipeResponse$ = this.service.getRecipes(this.filter);
  }

  onPaginate($event: PaginatorEvent) {
    console.log($event);
    var page = ($event.first / $event.rows) + 1;
    this.filter.pageNumber = page;
    this.filter.pageSize = $event.rows;

    this.updateRecipeList();
  }

  onSearch() {
    this.filter.pageNumber = 1

    this.updateRecipeList();
  }

  private updateRecipeList() {
    this.recipeResponse$ = this.service.getRecipes(this.filter);
  }
}

interface PaginatorEvent { first: number, rows: number }