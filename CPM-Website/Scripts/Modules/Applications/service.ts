import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
//import { catchError, map, tap } from 'rxjs/operators';

import { Application } from '../../Models/application';

const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()
export class ApplicationService {

    constructor(private http: HttpClient) {
    }

    /** GET heroes from the server */
    getApplications(): Observable<Application[]> {
        return this.http.get<Application[]>('application/searchProcess');
    }
}