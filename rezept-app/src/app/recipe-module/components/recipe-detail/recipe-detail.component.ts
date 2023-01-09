import { Component, OnInit, ViewEncapsulation } from '@angular/core';
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

  responsiveOptions: any[] = [
    {
        breakpoint: '1024px',
        numVisible: 5
    },
    {
        breakpoint: '768px',
        numVisible: 3
    },
    {
        breakpoint: '560px',
        numVisible: 1
    }
];

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
