import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Recipe } from '../models/recipe';
import { environment } from 'src/environment/environment';

@Injectable({
  providedIn: 'root'
})
export class RecipiesService {

  result$ = this.http.get<Result>(`${environment.baseUrl}/recipies/records`);
  
  constructor(private http:  HttpClient) { }

  filterRecipies(criteria: Recipe) {
    //this.filterRecipiesSubject.next(criteria);
  }
}


interface Result {
  page: number;
  pageSize: number;
  items:Recipe[];
}