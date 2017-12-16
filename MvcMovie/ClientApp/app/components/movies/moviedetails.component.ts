import { Component, Inject } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Http, Headers } from '@angular/http';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router'

@Component({
    selector: 'moviedetails',
    templateUrl: './moviedetails.component.html'
})
export class MovieDetailComponent {

    public movie: Movie;
    public movieReviews: MovieReviewModel;
    delResult: Object;

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string, private route: ActivatedRoute, private router: Router) {
        let id = route.snapshot.params['id'];
        http.get(baseUrl + 'api/Movies/' + id).subscribe(result => {
            this.movie = result.json() as Movie;
            
        }, error => console.error(error),
        );
        //this.movieReviews.Movie = this.movie;
    }

    

   
}
interface Movie {
    id: number;
    title: string;
    releaseDate: number;
    genre: string;
    price: number;
    rating: string;
    Review: Review;
}

interface Review {
    ID: number;
    movieID: number;
    Name: string;
    Comment: string;
}

interface MovieReviewModel {
    Movie: Movie;
    Reviews: Review[];
}