import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { MoviesService } from '../movies.service';
import { Movie, MovieUpKeepGenre } from '../movies.models';

@Component({
    selector: 'app-movies-edit',
    templateUrl: './movies-edit.component.html',
    styleUrls: ['./movies-edit.component.css']
})
export class MoviesEditComponent implements OnInit {

    private routerLink: string = '../list';

    private movieID: number;

    private isEdit: boolean = false;

    public formGroup: FormGroup;

    constructor(
        private router: Router,
        private route: ActivatedRoute,
        private moviesService: MoviesService,
        private formBuilder: FormBuilder) { }

    ngOnInit() {

        this.movieID = parseInt(this.route.snapshot.params['id']);

        if (this.movieID) {
            this.routerLink = '../../list';

            this.moviesService.getMovie(this.movieID).subscribe(res => {
                this.initForm(res);
                this.isEdit = true;
            });
        }
        else {
            this.initForm(<Movie>{});
        }
    }

    save() {
        Object.keys(this.formGroup.controls).forEach(control => {
            this.formGroup.get(control).markAsTouched();
        });

        if (this.formGroup.valid) {
            let movie = this.formGroup.value as Movie;
            movie.MovieUpKeepGenre = MovieUpKeepGenre.Comedy;

            if (this.isEdit) {
                movie.Id = this.movieID;

                this.moviesService.modifyMovie(movie).subscribe(res => {
                    this.router.navigate(['/movies']);
                });
            } else {

                this.moviesService.saveMovie(movie).subscribe(res => {
                    this.router.navigate(['/movies']);
                });
            }
        }
    }

    initForm(movie: Movie) {
        this.formGroup = this.formBuilder.group({
            title: [movie.Title, Validators.required],
            description: [movie.Description, Validators.required],
            movieUpKeepGenre: [movie.MovieUpKeepGenre, Validators.required],
            durationInMin: [movie.DurationInMin, [Validators.required]],
            yearOfRealease: [movie.YearOfRelease, [Validators.required]],
            director: [movie.Director, [Validators.required]],
            dateAdded: [movie.DateAdded, [Validators.required]],
            rating: [movie.Rating, [Validators.required]],
            wasWatched: [movie.WasWatched, [Validators.required]],
        });
    }

}
