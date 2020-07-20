import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';

import { RecipeService } from '../recepi.service';
import { Recipe } from '../models/recipe.model';
import { TreesNode } from '../models/trees-node';

@Component({
  selector: 'app-recipe-edit',
  templateUrl: './recipe-edit.component.html',
  styleUrls: ['./recipe-edit.component.css']
})
export class RecipeEditComponent implements OnInit, OnDestroy {
  id: number;
  editMode = false;
  treeNodes: TreesNode[];
  editSubscr: Subscription = null;
  recipeForm: FormGroup;

  constructor(private route: ActivatedRoute,
              private router: Router,
              private recipeService: RecipeService) { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.id = +params.id;
      this.editMode = params.id != null;
      this.initForm();
    });
  }

  onSubmit(): void {
    if (this.editMode) {
      this.recipeService.updateRecipe(this.id, this.recipeForm.value);
    } else {
      this.recipeForm.controls.parentId.setValue(this.recipeForm.value.namesTree.id);
      this.recipeService.addRecipe(this.recipeForm.value);
    }

    this.onCancel();
  }

  onCancel(): void {
    this.router.navigate(['../'], { relativeTo: this.route });
  }

  private initForm(): void {
    this.recipeForm = new FormGroup({
      id: new FormControl(''),
      name: new FormControl('', Validators.required),
      description: new FormControl('', Validators.required),
      createdDate: new FormControl(''),
      namesTree: new FormControl(''),
      parentId: new FormControl('')
    });


    this.editSubscr = this.recipeService.getRecipes().subscribe((recipes: Recipe[]) => {
      let currentRecipe: Recipe;
      this.mapRecipesToTreesNode(recipes);

      if (this.editMode) {
        currentRecipe = recipes.find((recipe: Recipe) => {
          return recipe.id === this.id;
        });

        this.recipeForm.setValue(currentRecipe);
        this.recipeForm.controls.namesTree.disable();
      }

      this.recipeForm.controls.namesTree.setValue( this.getParentRecipe(currentRecipe), { onlySelf: true });
    });
  }

  private getParentRecipe(recipe: Recipe): TreesNode {
    return this.treeNodes.find((node: TreesNode) => {
      if (!recipe || recipe.parentId === null) {
        return node.id === 0;
      } else {
        return node.id === recipe.parentId;
      }
    });
  }

  private mapRecipesToTreesNode(recipes: Recipe[]): void {
    this.treeNodes = recipes.map((recipe: Recipe) => ({ id: recipe.id, name: this.getFullName(recipe) }));
    this.treeNodes.unshift(new TreesNode(0, 'Root'));
  }

  private getFullName(recipe): string {
    return recipe.namesTree.find(node => node.id === recipe.id).name;
  }

  ngOnDestroy(): void {
    if (this.editSubscr !== null) {
      this.editSubscr.unsubscribe();
    }
  }
}
