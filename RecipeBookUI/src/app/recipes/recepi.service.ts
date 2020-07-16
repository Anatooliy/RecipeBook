import { ReplaySubject } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Recipe } from './recipe.model';
import { BaseApi } from '../shared/core/base-api';

@Injectable()
export class RecipeService extends BaseApi {
    subject: ReplaySubject<Recipe[]> = new ReplaySubject();
    obs: Observable<Recipe[]> = this.subject.asObservable();

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
        this.post('recipes', recipe).subscribe(response => {
            this.subject.next();
        });
    }

    updateRecipe(id: number, recipe: Recipe): void {
        this.put('recipes', recipe).subscribe(response => {
            this.subject.next();
        });
    }

    deleteRecipe(id: number): void {
        this.delete(`recipes/${id}`).subscribe(response => {
            this.subject.next();
        });
    }
}
