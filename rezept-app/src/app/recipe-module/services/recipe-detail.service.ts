import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MessageService } from 'primeng/api';
import { Observable } from 'rxjs';
import { RecipeDetail } from 'src/app/models/RecipeDetail';
import { environment } from 'src/environment/environment';

const BASE_URL = environment.baseUrl;

@Injectable({
  providedIn: 'root'
})
export class RecipeDetailService {

  getRecipeDetail(id: string) : Observable<RecipeDetail> {
    return this.http.get<RecipeDetail>(`${BASE_URL}/recipes/${id}`);
  }
  

  //getUrlForRecipeDetail() => $`BASE_URL/recipe/{this.route.}`
  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }
}
