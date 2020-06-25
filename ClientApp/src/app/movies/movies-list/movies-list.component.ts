import { Component, OnInit } from '@angular/core';

import { Movie } from '../movies.models';
import { MoviesService } from '../movies.service';
import { PaginatedMovies } from '../paginatedMovies.models';
import { PageEvent } from '@angular/material/paginator';

@Component({
    selector: 'app-movies-list',
    templateUrl: './movies-list.component.html',
    styleUrls: ['./movies-list.component.css']
})
export class MoviesListComponent implements OnInit {

    public displayedColumns: string[] = ['title', 'description', 'movieUpKeepGenre', 'durationInMin', 'yearOfRelease', 'director', 'dateAdded', 'rating', 'numberOfComments', 'action'];

    public dataSource;
    public isloading = false;
    public movies: PaginatedMovies;
    public pageEvent: PageEvent;

    constructor(private moviesService: MoviesService) {
    }

    ngOnInit() {
        this.loadMovies(null);
    }

    loadMovies(event?: PageEvent) {
        this.movies = null;
        this.moviesService.listMovies(event).subscribe(res => {
            this.movies = res;
        });
    }

    deleteMovie(movie: Movie) {
        this.moviesService.deleteMovie(movie.id).subscribe(x => {
            this.loadMovies();
        });
    }

}
