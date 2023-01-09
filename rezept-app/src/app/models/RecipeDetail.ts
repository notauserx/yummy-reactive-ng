import { Ingredient } from "./ingredient";
import { RecipeInstructionStep } from "./RecipeInstructionStep";

export interface RecipeDetail {
  id: string;
  title: string;
  description: string;
  prepTime: number;
  cookTime: number;
  serves: number;
  rating: number;
  imageUrls: string[];
  authorName: string;
  ingredients: Ingredient[];
  steps: RecipeInstructionStep[];
  keywords: string[];
}
