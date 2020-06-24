import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { CommentsService } from '../comments.service';
import { Comment } from '../comments.models';

@Component({
    selector: 'app-comments-edit',
    templateUrl: './comments-edit.component.html',
    styleUrls: ['./comments-edit.component.css']
})
export class CommentsEditComponent implements OnInit {

    private routerLink: string = '../list';

    private commentID: number;

    private isEdit: boolean = false;

    public formGroup: FormGroup;

    constructor(
        private router: Router,
        private route: ActivatedRoute,
        private commentsService: CommentsService,
        private formBuilder: FormBuilder) { }

    ngOnInit() {

        this.commentID = parseInt(this.route.snapshot.params['id']);

        if (this.commentID) {
            this.routerLink = '../../list';

            this.commentsService.getComment(this.commentID).subscribe(res => {
                this.initForm(res);
                this.isEdit = true;
            });
        }
        else {
            this.initForm(<Comment>{});
        }
    }

    save() {
        Object.keys(this.formGroup.controls).forEach(control => {
            this.formGroup.get(control).markAsTouched();
        });

        if (this.formGroup.valid) {
            let comment = this.formGroup.value as Comment;
          

            if (this.isEdit) {
                comment.id = this.commentID;

                this.commentsService.modifyComment(comment).subscribe(res => {
                    this.router.navigate(['/comments']);
                });
            } else {

                this.commentsService.saveComment(comment).subscribe(res => {
                    this.router.navigate(['/comments']);
                });
            }
        }
    }

    initForm(comment: Comment) {
        this.formGroup = this.formBuilder.group({
            text: [comment.Text, Validators.required],
           // important: [comment.Important, Validators.required],
            movieId: [comment.MovieId, Validators.required]
        });
    }

}
