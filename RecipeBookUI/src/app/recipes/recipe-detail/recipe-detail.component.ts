import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Subscription } from 'rxjs';

import { Recipe } from '../models/recipe.model';
import { RecipeService } from '../recepi.service';

@Component({
  selector: 'app-recipe-detail',
  templateUrl: './recipe-detail.component.html',
  styleUrls: ['./recipe-detail.component.css']
})
export class RecipeDetailComponent implements OnInit, OnDestroy {
  id: number;
  recipe: Recipe;
  detailSubscr: Subscription;
  isLoaded = false;

  constructor(private route: ActivatedRoute,
              private router: Router,
              private recipeService: RecipeService) { }

  ngOnInit(): void {
    this.route.params.subscribe(
      (params: Params) => {
        this.id = params.id;

        this.detailSubscr = this.recipeService.getRecipe(this.id).subscribe((recipe: Recipe) => {
          this.recipe = recipe;
          this.isLoaded = true;
        });
      }
    );
  }

  onEditRecipe(): void {
    this.router.navigate(['edit'], {relativeTo: this.route});
  }

  onDeleteRecipe(): void {
    this.recipeService.deleteRecipe(this.id);
    this.router.navigate(['/recipes']);
  }

  getFullName(): string {
    return this.recipe.namesTree.find(node => node.id === this.recipe.id).name;
  }

  ngOnDestroy(): void {
    this.detailSubscr.unsubscribe();
  }
}
