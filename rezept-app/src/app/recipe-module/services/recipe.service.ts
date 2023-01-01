import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MessageService } from 'primeng/api';
import { catchError, Observable, share, throwError } from 'rxjs';
import { RecipeCategory } from 'src/app/models/recipeCategory';
import { RecipeFilter } from 'src/app/models/recipeFilter';
import { RecipeListResponse } from 'src/app/models/RecipeListResponse';
import { environment } from 'src/environment/environment';

const BASE_URL = environment.baseUrl;
@Injectable({
  providedIn: 'root',
})
export class RecipeService {
  recipeCategoryList$ = this.http.get<RecipeCategory[]>(`${BASE_URL}/recipes/categories`)

  constructor(
    private http: HttpClient,
    private messageService: MessageService
  ) {}

  getRecipes(filter: RecipeFilter | null) : Observable<RecipeListResponse> {
    const href = `${BASE_URL}/recipes`;
    let requestUrl =  `${href}`;
    
    return this.http.get<RecipeListResponse>(requestUrl, 
      {
        params: {...filter}
      })
    .pipe(
      catchError(err => {
        console.log("Logging from catchError...");
        console.log(err);
        this.showError("There was a problem searching recipes. Make sure the server is running and the api call works correctly.");
        return throwError(() => new Error(err));
      })
    );;
  }

  // todo :: refactor and introduce a messageService wrapper in core module
  showError(msg: string) {
    this.messageService.add({
      severity: 'error',
      summary: 'Error',
      detail: msg,
    });
  }
}
