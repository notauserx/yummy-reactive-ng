import { Ingredient } from "./ingredient";
import { RecipeStep } from "./recipeStep";

export interface Recipe {
  id: string;
  title: string;
  description: string;
  prepTime: number;
  cookTime: number;
  recipeServings: number;
  rating: number;
  ingredients: Ingredient[],
  imageUrl: string;
  steps: RecipeStep[]
}


