import { Component, OnInit } from '@angular/core';
import { Recipe } from 'src/app/models/recipe';
import { RecipiesService } from 'src/app/services/recipies.service';

@Component({
  selector: 'app-recipe-list',
  templateUrl: './recipe-list.component.html',
  styleUrls: ['./recipe-list.component.scss']
})
export class RecipeListComponent implements OnInit {
  result$ = this.service.result$;

  constructor (private service: RecipiesService) { }
  
  ngOnInit(): void { }
}
