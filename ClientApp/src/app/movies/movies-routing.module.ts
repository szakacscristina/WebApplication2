import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MoviesComponent } from './movies.component';
import { MoviesEditComponent } from './movies-edit/movies-edit.component';
import { MoviesListComponent } from './movies-list/movies-list.component';

const routes: Routes = [
    {
        path: '', component: MoviesComponent,
        children: [
            { path: '', redirectTo: 'list', pathMatch: 'full' },
            { path: 'list', component: MoviesListComponent },
            { path: 'edit/:id', component: MoviesEditComponent },
            { path: 'edit', component: MoviesEditComponent },
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class MoviesRoutingModule {
    static routedComponents = [MoviesComponent, MoviesListComponent, MoviesEditComponent];
}
