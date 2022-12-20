import { Ingredient } from "./ingredient";
import { Rating } from "./Rating";
import { RecipeStep } from "./recipeStep";

export interface Recipe {
  id: string;
  title: string;
  prepTime: number;
  cookingTime: number;
  serves: number;
  ratings: Rating[];
  ingredients: Ingredient[],
  imageUrl: string;
  steps: RecipeStep[]
}


