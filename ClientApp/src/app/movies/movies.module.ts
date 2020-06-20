import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { CoreModule } from '../core/core.module';
import { AngularMaterialModule } from '../shared/angular-material.module';

import { MoviesRoutingModule } from './movies-routing.module';

import { MoviesService } from './movies.service';

@NgModule({
    declarations: [MoviesRoutingModule.routedComponents],
    imports: [
        CommonModule,
        MoviesRoutingModule,
        AngularMaterialModule,
        CoreModule,
        FormsModule,
        ReactiveFormsModule
    ],
    providers: [MoviesService],
})
export class MoviesModule { }
