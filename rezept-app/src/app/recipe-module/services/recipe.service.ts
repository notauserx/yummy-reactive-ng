import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MessageService } from 'primeng/api';
import { catchError, throwError } from 'rxjs';
import { Recipe } from 'src/app/models/recipe';
import { environment } from 'src/environment/environment';

const BASE_URL = environment.baseUrl;
@Injectable({
  providedIn: 'root',
})
export class RecipeService {
  recipeList$ = this.http.get<Recipe[]>(`${BASE_URL}/recipes`)
  .pipe(
    catchError(err => {
      console.log("Logging from catchError...");
      console.log(err);
      this.showError("There was a problem loading recipes. Make sure the server is running and the api call works correctly.");
      return throwError(() => new Error(err));
    })
  );

  constructor(
    private http: HttpClient,
    private messageService: MessageService
  ) {}

  // todo :: refactor and introduce a messageService wrapper in core module
  showError(msg: string) {
    this.messageService.add({
      severity: 'error',
      summary: 'Error',
      detail: msg,
    });
  }
}
