import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Movie } from './movies.models';
import { ApplicationService } from '../core/services/application.service';


@Injectable()
export class MoviesService {

    constructor(
        private http: HttpClient,
        private applicationService: ApplicationService) { }

    getMovie(id: number) {
        return this.http.get<Movie>(`${this.applicationService.baseUrl}api/Movies/${id}`);
    }

    listMovies() {
        return this.http.get<Movie[]>(`${this.applicationService.baseUrl}api/Movies`);
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
