import { Component, OnInit, Input } from '@angular/core';

import { Recipe } from '../../models/recipe.model';

@Component({
  selector: 'app-recipe-item',
  templateUrl: './recipe-item.component.html',
  styleUrls: ['./recipe-item.component.css']
})
export class RecipeItemComponent implements OnInit {
  @Input() recipe: Recipe;

  ngOnInit(): void {
  }

  getFullName(): string {
    return this.recipe.namesTree.find(node => node.id === this.recipe.id).name;
  }

  getLeftMargin(): string {
    if (this.recipe.namesTree.length > 1) {
      return ((this.recipe.namesTree.length - 1) * 3) + '%';
    } else {
      return '0';
    }
  }
}
