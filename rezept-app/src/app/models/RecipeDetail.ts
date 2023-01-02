
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
  ingredients: string[];
  steps: string[];
  additionalImageUrls: string[];
  keywords: string[];
}
