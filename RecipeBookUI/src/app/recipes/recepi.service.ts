import { Subject } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

import { Recipe } from './recipe.model';
import { BaseApi } from '../shared/core/base-api';

@Injectable()
export class RecipeService extends BaseApi {
    recipesChanged = new Subject<Recipe[]>();

    private recipes: Recipe[] = [
        new Recipe(0, 'Fried Chicken', 'Description of Fried Chicken', new Date()),
        new Recipe(1, 'Fried Chicken with Mayo', 'Description of Fried Chicken with Mayo', new Date()),
        new Recipe(2, 'Fried Chicken with Mayo and Mustard', 'Description of Fried Chicken with Mayo and Mustard', new Date())
    ];

    constructor(public http: HttpClient) {
        super(http);
    }

    getRecipes(): Observable<Recipe[]> {
        return this.get<Recipe[]>('recipes');
    }

    getRecipe(id: number): Observable<Recipe> {
        return this.get<Recipe>(`recipes/${id}`);
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
