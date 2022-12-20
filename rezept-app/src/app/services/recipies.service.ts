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

  getRecipies(): Observable<Recipe[]> {
    return this.http.get<Recipe[]>(`${environment.basePath}/recipes`);
  }
}
