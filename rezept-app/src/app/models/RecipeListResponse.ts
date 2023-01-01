import { Recipe } from "./recipe";


export interface RecipeListResponse {
  totalCount: number;
  totalPages: number;
  currentPage: number;
  pageSize: number;
  recipes: Recipe[];
}
