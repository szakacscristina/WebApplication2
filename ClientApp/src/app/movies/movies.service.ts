import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Movie } from './movies.models';
import { ApplicationService } from '../core/services/application.service';
import { PaginatedMovies } from './paginatedMovies.models';
import { PageEvent } from '@angular/material/paginator';


@Injectable()
export class MoviesService {
    filter: any;

    constructor(
        private http: HttpClient,
        private applicationService: ApplicationService) { }

    getMovie(id: number) {
        return this.http.get<Movie>(`${this.applicationService.baseUrl}api/Movies/${id}`);
    }

    listMovies(event?: PageEvent) {

        let pageIndex = event ? event.pageIndex + "" : "0";
        let itemsPerPage = event ? event.pageSize + "" : "25";
        console.log(event);
        let params = new HttpParams().set("page", pageIndex).set("itemsPerPage", itemsPerPage); //Create new HttpParams
        return this.http.get<PaginatedMovies>(`${this.applicationService.baseUrl}api/Movies`, { params: params });
    }

    saveMovie(movie: Movie) {
        return this.http.post(`${this.applicationService.baseUrl}api/Movies`, movie);

    }

    modifyMovie(movie: Movie) {
        return this.http.put(`${this.applicationService.baseUrl}api/Movies/${movie.id}`, movie);
    }

    deleteMovie(id: number) {
        return this.http.delete<any>(`${this.applicationService.baseUrl}api/Movies/${id}`);
    }
}
