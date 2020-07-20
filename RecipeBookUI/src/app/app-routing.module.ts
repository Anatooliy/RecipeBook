import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

const routes: Routes = [
    { path: '', redirectTo: 'recipes', pathMatch: 'full' }
    /*,
    { path: 'page-not-found', component: PageNotFoundComponent },
    { path: '**', pathMatch: 'full', redirectTo: 'page-not-found' }*/
];

export const appRouting = RouterModule.forRoot(routes);

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {}
