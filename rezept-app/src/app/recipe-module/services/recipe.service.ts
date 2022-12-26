import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Recipe } from 'src/app/models/recipe';
import { environment } from 'src/environment/environment';

const BASE_URL = environment.baseUrl
@Injectable({
  providedIn: 'root'
})
export class RecipeService {
  recipeList$ = this.http.get<Recipe[]>(`${BASE_URL}/Rezept`);

  constructor(private http: HttpClient) { }
}
