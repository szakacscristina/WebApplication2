import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Comment } from './comments.models';
import { ApplicationService } from '../core/services/application.service';


@Injectable()
export class CommentsService {

    constructor(
        private http: HttpClient,
        private applicationService: ApplicationService) { }

    getComment(id: number) {
        return this.http.get<Comment>(`${this.applicationService.baseUrl}api/Comments/${id}`);
    }

    listComments() {
        return this.http.get<Comment[]>(`${this.applicationService.baseUrl}api/Comments`);
    }

    saveComment(comment: Comment) {
        return this.http.post(`${this.applicationService.baseUrl}api/Comments`, comment);

    }

    modifyComment(comment: Comment) {
        return this.http.put(`${this.applicationService.baseUrl}api/Comments/${comment.id}`, comment);
    }

    deleteComment(id: number) {
        return this.http.delete<any>(`${this.applicationService.baseUrl}api/Comments/${id}`);
    }
}
