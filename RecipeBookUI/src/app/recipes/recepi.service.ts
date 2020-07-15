import { Subject } from 'rxjs';

import { Recipe } from './recipe.model';

export class RecipeService {
    recipesChanged = new Subject<Recipe[]>();

    private recipes: Recipe[] = [
        new Recipe(0, 'Fried Chicken', 'Description of Fried Chicken', new Date()),
        new Recipe(1, 'Fried Chicken with Mayo', 'Description of Fried Chicken with Mayo', new Date()),
        new Recipe(2, 'Fried Chicken with Mayo and Mustard', 'Description of Fried Chicken with Mayo and Mustard', new Date())
    ];

    getRecipes(): Recipe[] {
        return this.recipes.slice();
    }

    getRecipe(id: number): Recipe {
        return this.recipes.slice()[id];
    }

    addRecipe(recipe: Recipe): void {
        recipe.id = this.recipes.length;

        this.recipes.push(recipe);
        this.recipesChanged.next(this.recipes.slice());
    }

    updateRecipe(id: number, recipe: Recipe): void {
        this.recipes[id] = recipe;
        this.recipesChanged.next(this.recipes.slice());
    }

    deleteRecipe(id: number): void {
        this.recipes.splice(id, 1);
        this.recipesChanged.next(this.recipes.slice());
    }
}
