import { Component, OnInit } from '@angular/core';
import { Comment } from '../comments.models';
import { CommentsService } from '../comments.service';

@Component({
    selector: 'app-comments-list',
    templateUrl: './comments-list.component.html',
    styleUrls: ['./comments-list.component.css']
})
export class CommentsListComponent implements OnInit {


    public displayedColumns: string[] = ['text', 'movieId', 'action'];
    public comments: Comment[];

    constructor(private commentsService: CommentsService) { }

    ngOnInit() {
        this.loadComments();
    }

    loadComments() {
        this.commentsService.listComments().subscribe(res => {
            this.comments = res;
        });
    }

    deleteComment(comment: Comment) {
        this.commentsService.deleteComment(comment.id).subscribe(x => {
            this.loadComments();
        });
    }
}
