import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-fetch-data',
    templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
    public forecasts: WeatherForecast[];

    public movies: Movie[];


    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

        http.get<WeatherForecast[]>(baseUrl + 'weatherforecast').subscribe(result => {

            this.forecasts = result;

        }, error => console.error(error));

        http.get<Movie[]>(baseUrl + 'api/Movies').subscribe(result => {
            this.movies = result;

            console.log(this.movies);

        }, error => console.error(error));
    }
}

    //submit() {

       // var movie: Movie = <Movie>{};
      //  movie.Title = 'The circle of live';
       // movie.Description = 'a nice movie about true friendship';
       // movie.MovieUpKeepGenre = MovieUpKeepGenre.Action;
        //movie.DurationInMin = 50;
       // movie.YearOfRelease = 2011;
       // movie.Director = 'hgfhjgd';
        //movie.DateAdded = new Date();
       // movie.Rating = 5;
       // movie.WasWatched = true;
        //movie.Comments = this.comments;

       // this.http.post(this.baseUrl + 'api/Movies', movie).subscribe(result => {

           // console.log('success!');
     //   },
           // error => {

             //   if (error.status == 400) {
                   // console.log(error.error.errors)
                //}

       // })

   // }


interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
    summary: string;
}

interface Movie {
    Title: string;
    Description: string;
   MovieUpKeepGenre: MovieUpKeepGenre;
   DurationInMin: number;
   YearOfRelease: number;
    Director: string;
    DateAdded: Date;
     Rating: number;
    WasWatched: boolean;
    Comments: string;
}
enum MovieUpKeepGenre
{
    Action,
    Comedy,
    Horror,
    Thriller 
}


