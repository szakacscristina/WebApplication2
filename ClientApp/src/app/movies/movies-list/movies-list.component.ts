import { Component, OnInit } from '@angular/core';
import { Movie } from '../movies.models';
import { MoviesService } from '../movies.service';
import { MatTableDataSource } from '@angular/material/table';


@Component({
    selector: 'app-movies-list',
    templateUrl: './movies-list.component.html',
    styleUrls: ['./movies-list.component.css']
})
export class MoviesListComponent implements OnInit {

    public displayedColumns: string[] = ['title', 'description', 'movieUpKeepGenre', 'durationInMin', 'yearOfRelease', 'director', 'dateAdded', 'rating', 'numberOfComments', 'action'];
    public movies: Movie[];

    public dataSource;
    public isloading = false;

    constructor(private moviesService: MoviesService) { }

    ngOnInit() {
        this.loadMovies();
    }



    async loadMovies() {
        try {
            this.moviesService.listMovies().subscribe(res => {
                this.movies = res;
                this.dataSource = new MatTableDataSource(this.movies);
                this.isloading = true;
            });
        } catch (err) {
            console.error(`this is not good: ${err.Message}`);
            this.isloading = false;
        }
    }

    applyFilter(filterValue: string) {
        this.dataSource.filter = filterValue.trim().toLowerCase();
    }


    deleteMovie(movie: Movie) {
        this.moviesService.deleteMovie(movie.id).subscribe(x => {
            this.loadMovies();
        });
    }

}
