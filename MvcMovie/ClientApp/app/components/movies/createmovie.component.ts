import { Component, Inject } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Http, Headers } from '@angular/http';
import { Router } from '@angular/router';

@Component({
    selector: 'createmovie',
    templateUrl: './createmovie.component.html'
})
export class CreateMovieComponent {
    model = new Movie();
    postResult: Object;

    constructor(public http: Http, @Inject('BASE_URL') public baseUrl: string, public router: Router) { }

    onSubmit(form: NgForm) {


        let headers = new Headers({ 'Content-Type': 'application/json' });

        this.http.post(this.baseUrl + 'api/Movies', this.model,
            { headers: headers }).subscribe(result => {
                this.postResult = result;
                this.router.navigate(['/movies']);
            });
    }

    
}
class Movie {
    id: number;
    title: string;
    releaseDate: number;
    genre: string;
    price: number;
    rating: string;
}