import { Component, Inject } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Http, Headers } from '@angular/http';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router'

@Component({
    selector: 'editmovie',
    templateUrl: './editmovie.component.html'
})
export class EditMovieComponent {

    public movie: Movie;
    putResult: Object;

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string, private route: ActivatedRoute, private router: Router) {
        let id = route.snapshot.params['id'];
        http.get(baseUrl + 'api/Movies/' + id).subscribe(result => {
            this.movie = result.json() as Movie;
        }, error => console.error(error),
        );
    }

    onSubmit() {
        this.http.put(this.baseUrl + 'api/Movies/' + this.movie.id, this.movie).subscribe(result => {
            this.putResult = result;
            this.router.navigate(['/movies']);
        });
    }



}

function formatDate() {

}
interface Movie {
    id: number;
    title: string;
    releaseDate: number;
    genre: string;
    price: number;
    rating: string;
}