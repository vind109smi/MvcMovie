import { Component, Inject } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Http, Headers } from '@angular/http';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router'

@Component({
    selector: 'deletemovie',
    templateUrl: './deletemovie.component.html'
})
export class DeleteMovieComponent {

    public movie: Movie;
    delResult: Object;

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string, private route: ActivatedRoute, private router: Router) {
        let id = route.snapshot.params['id'];
        http.get(baseUrl + 'api/Movies/' + id).subscribe(result => {
            this.movie = result.json() as Movie;
        }, error => console.error(error),
        );
    }

    Delete() {
        this.http.delete(this.baseUrl + 'api/Movies/' + this.movie.id, JSON.stringify(this.movie)).subscribe(result => {
                this.delResult = result;
                this.router.navigate(['/movies']);
            });
    }


}
interface Movie {
    id: number;
    title: string;
    releaseDate: number;
    genre: string;
    price: number;
    rating: string;
}