import { Ingredient } from "./ingredient";

export interface RecipeDetail {
  id: string;
  title: string;
  description: string;
  prepTime: number;
  cookTime: number;
  serves: number;
  rating: number;
  imageUrl: string;
  author: string;
  ingredients: Ingredient[];
  steps: string[];
  additionalImageUrls: string[];
  keywords: string[];
}
