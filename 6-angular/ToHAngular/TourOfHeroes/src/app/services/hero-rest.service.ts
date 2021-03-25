import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { hero } from '../models/hero';

@Injectable({
  providedIn: 'root'
})
export class HeroRESTService {
  //This is where you set up your properties
  //Set up headers
  httpOptions = {
    headers: new HttpHeaders(
      {
        'Content-Type': 'application/json'
      }
    )
  }
  //defines the url we'll be querying
  url: string = environment.HEROES_REST;

  //This is where you inject your deps
  //the httpClient is what you'll be using to query your external REST API
  constructor(private http: HttpClient) { }

  //Logic goes here
  //Observables - kinda like a promise, in a sense that it is async, 
  //an asynchronous stream of data which can be subscribed to, can be cancelled, 
  //can be resolved more than once
  // uses promises under the hood
  GetAllHeroes(): Observable<hero[]> {
    return this.http.get<hero[]>(this.url, this.httpOptions);
  }
  GetHero(heroName: string): Observable<hero> {
    return this.http.get<hero>(`${this.url}/${heroName}`, this.httpOptions);
  }
  AddHero(hero2Add: hero): Observable<hero> {
    return this.http.post<hero>(this.url, hero2Add, this.httpOptions);
  }
  DeleteHero(hero2BDeleted: string): Observable<any> {
    return this.http.delete<any>(`${this.url}/${hero2BDeleted}`, this.httpOptions);
  }
  EditHero(hero2BEdited: hero): Observable<any> {
    return this.http.put<any>(`${this.url}/${hero2BEdited.id}`, hero2BEdited, this.httpOptions)
  }
}
