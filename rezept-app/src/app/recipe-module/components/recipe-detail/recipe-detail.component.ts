import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { RecipeDetail } from 'src/app/models/RecipeDetail';
import { RecipeDetailService } from '../../services/recipe-detail.service';

@Component({
  selector: 'app-recipe-detail',
  templateUrl: './recipe-detail.component.html',
  styleUrls: ['./recipe-detail.component.scss'],
})
export class RecipeDetailComponent implements OnInit {
  recipeDetail$: Observable<RecipeDetail> | undefined;

  constructor(
    private route: ActivatedRoute,
    private service: RecipeDetailService
  ) {}

  ngOnInit(): void {
    this.recipeDetail$ = this.route.paramMap.pipe(
      switchMap((params: ParamMap) =>
        this.service.getRecipeDetail(params.get('id')!)
      )
    );
  }
}
