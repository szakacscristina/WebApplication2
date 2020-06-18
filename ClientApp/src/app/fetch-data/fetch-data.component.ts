import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-fetch-data',
    templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
    public movies: Movie[];

    public name: string = "test";

    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
        this.loadMovies();
    }


    loadMovies() {
        this.http.get<Movie[]>(this.baseUrl + 'api/Movies').subscribe(result => {
            this.movies = result;
            console.log(this.movies);
        }, error => console.error(error))
    };

    delete(movieId: string) {
        if (confirm('Are you sure you want to delete the movie with id ' + movieId + '?')) {
            this.http.delete(this.baseUrl + 'api/Movies/' + movieId)
                .subscribe
                (
                    result => {
                        alert('Movie successfully deleted!');
                        this.loadMovies();
                    },
                    error => alert('Cannot delete movie - maybe it has comments?')
                )
        }
    }

    submit() {

        var movie: Movie = <Movie>{};
        movie.Title = this.name;
        movie.Description = this.name;
        movie.MovieUpKeepGenre = MovieUpKeepGenre.Comedy;
        movie.DurationInMin = 80;
        movie.YearOfRelease = 2005;
        movie.Director = this.name;
        movie.DateAdded = new Date();
        movie.Rating = 6;
        movie.WasWatched = true;
    
     

        this.http.post(this.baseUrl + 'api/Movies', movie).subscribe(result => {
            console.log('success!');
            this.loadMovies();
        },
            error => {
                if (error.status == 400) {
                    console.log(error.error.errors)
                }
            });
    }
}



interface Movie {
    Id: number;
    Title: string;
    Description: string;
   MovieUpKeepGenre: MovieUpKeepGenre;
   DurationInMin: number;
   YearOfRelease: number;
    Director: string;
    DateAdded: Date;
     Rating: number;
    WasWatched: boolean;
}
enum MovieUpKeepGenre
{
    Action,
    Comedy,
    Horror,
    Thriller 
}


