import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Recipe } from '../models/recipe';
import { environment } from 'src/environment/environment';

@Injectable({
  providedIn: 'root'
})
export class RecipiesService {
  constructor(private http:  HttpClient) { }

  result$ = this.http.get<Result>(`${environment.baseUrl}/recipies/records`);
}


interface Result {
  page: number;
  pageSize: number;
  items:Recipe[];
}