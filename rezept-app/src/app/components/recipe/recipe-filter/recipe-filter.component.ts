import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { RecipiesService } from 'src/app/services/recipies.service';

@Component({
  selector: 'app-recipe-filter',
  templateUrl: './recipe-filter.component.html',
  styleUrls: ['./recipe-filter.component.scss']
})
export class RecipeFilterComponent implements OnInit{
  recipeFilterForm = this.fb.group({
    title: [''],
    ingredient: [''],
    prepTime: [''],
    cookingTime: [''],
  })

  constructor(private service: RecipiesService, private fb: FormBuilder) { }

  ngOnInit(): void { }

  filterResults() {
  }
  clearFilter() {

  }
}
