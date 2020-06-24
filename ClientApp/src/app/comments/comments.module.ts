import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { CoreModule } from '../core/core.module';
import { AngularMaterialModule } from '../shared/angular-material.module';

import { CommentsRoutingModule } from './comments-routing.module';

import { CommentsService } from './comments.service';

@NgModule({
    declarations: [CommentsRoutingModule.routedComponents],
    imports: [
        CommonModule,
        CommentsRoutingModule,
        AngularMaterialModule,
        CoreModule,
        FormsModule,
        ReactiveFormsModule
    ],
    providers: [CommentsService],
})
export class CommentsModule { }
