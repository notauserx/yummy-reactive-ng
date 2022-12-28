import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, EMPTY } from 'rxjs';
import { Recipe } from 'src/app/models/recipe';
import { environment } from 'src/environment/environment';

const BASE_URL = environment.baseUrl
@Injectable({
  providedIn: 'root'
})
export class RecipeService {
  errorMessage = ''

  recipeList$ = this.http
    .get<Recipe[]>(`${BASE_URL}/rezept`)
    .pipe(
      catchError(err => {
        this.errorMessage = err;
        console.log("Logging from catchError...");
        console.log(err);
        return EMPTY;
      })
    );

  constructor(private http: HttpClient) { }
}
