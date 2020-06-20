
import { Component, OnInit } from '@angular/core';
import { Movie} from '../movies.models';
import { MoviesService } from '../movies.service';

@Component({
  selector: 'app-movies-list',
  templateUrl: './movies-list.component.html',
  styleUrls: ['./movies-list.component.css']
})
export class MoviesListComponent implements OnInit {


    public displayedColumns: string[] = ['title', 'description', 'movieUpKeepGenre', 'durationInMin', 'yearOfRelease', 'director', 'dateAdded', 'rating','wasWatched', 'numberOfComments','action'];
    public movies: Movie[];

    constructor(private moviesService: MoviesService) {
    }

    ngOnInit() {
        this.loadMovies();
    }

    loadMovies() {
        this.moviesService.listMovies().subscribe(res => {
            this.movies = res;
        });
    }
    deleteMovie(movie: Movie) {
        this.moviesService.deleteMovie(movie.Id).subscribe(x => {
            this.loadMovies();
        });
    }

}

