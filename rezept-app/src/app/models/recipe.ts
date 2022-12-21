import { Ingredient } from "./ingredient";
import { RecipeStep } from "./recipeStep";

export interface Recipe {
  id: string;
  title: string;
  prepTime: number;
  cookingTime: number;
  serves: number;
  rating: number;
  ingredients: Ingredient[],
  imageUrl: string;
  steps: RecipeStep[]
}


