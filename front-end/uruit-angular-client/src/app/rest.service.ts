import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';

const endpoint = 'http://localhost:5000/api/';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class RestService {

  constructor(private http: HttpClient) { }

  private extractData(res: Response) {
    let body = res;
    return body || {};
  }
  // # region Player
  getPlayer(): Observable<any> {
    return this.http.get(endpoint + 'player').pipe(
      map(this.extractData));
  }

  getPlayerById(id): Observable<any> {
    return this.http.get(endpoint + 'player/' + id).pipe(
      map(this.extractData));
  }

  addPlayer(player): Observable<any> {

    return this.http.post<any>(endpoint + 'player', JSON.stringify(player), httpOptions).pipe(
      tap((player) => console.log(`added player`)),
      catchError(this.handleError<any>('addPlayer'))
    );
  }

  filterPlayer(player): Observable<any> {

    return this.http.post<any>(endpoint + 'player/filter', JSON.stringify(player), httpOptions).pipe(
      map(this.extractData));
  }

  updatePlayer(id, player): Observable<any> {

    return this.http.put(endpoint + 'player/' + id, JSON.stringify(player), httpOptions).pipe(
      tap(_ => console.log(`updated player`)),
      catchError(this.handleError<any>('updatePlayer'))
    );
  }

  deletePlayer(id): Observable<any> {
    return this.http.delete<any>(endpoint + 'player/' + id, httpOptions).pipe(
      tap(_ => console.log(`deleted player`)),
      catchError(this.handleError<any>('deletePlayer'))
    );
  }

  // #end region

  // # region Match
  getMatch(): Observable<any> {
    return this.http.get(endpoint + 'match').pipe(
      map(this.extractData));
  }

  getMatchById(id): Observable<any> {
    return this.http.get(endpoint + 'match/' + id).pipe(
      map(this.extractData));
  }

  addMatch(match): Observable<any> {

    return this.http.post<any>(endpoint + 'match', JSON.stringify(match), httpOptions).pipe(
      tap((match) => console.log(`added match`)),
      catchError(this.handleError<any>('addMatch'))
    );
  }

  filterMatch(match): Observable<any> {
    return this.http.post<any>(endpoint + 'match/filter', JSON.stringify(match), httpOptions).pipe(
      map(this.extractData));
  }

  updateMatch(id, match): Observable<any> {

    return this.http.put(endpoint + 'match/' + id, JSON.stringify(match), httpOptions).pipe(
      tap(_ => console.log(`updated match`)),
      catchError(this.handleError<any>('updateMatch'))
    );
  }

  deleteMatch(id): Observable<any> {
    return this.http.delete<any>(endpoint + 'match/' + id, httpOptions).pipe(
      tap(_ => console.log(`deleted match`)),
      catchError(this.handleError<any>('deleteMatch'))
    );
  }

  // #end region

  // # region Round
  getRound(): Observable<any> {
    return this.http.get(endpoint + 'round').pipe(
      map(this.extractData));
  }

  getRoundById(id): Observable<any> {
    return this.http.get(endpoint + 'round/' + id).pipe(
      map(this.extractData));
  }

  addRound(round): Observable<any> {

    return this.http.post<any>(endpoint + 'round', JSON.stringify(round), httpOptions).pipe(
      tap((match) => console.log(`added round`)),
      catchError(this.handleError<any>('addRound'))
    );
  }

  filterRound(round): Observable<any> {
    return this.http.post<any>(endpoint + 'round/filter', JSON.stringify(round), httpOptions).pipe(
      map(this.extractData));
  }

  updateRound(id, round): Observable<any> {

    return this.http.put(endpoint + 'round/' + id, JSON.stringify(round), httpOptions).pipe(
      tap(_ => console.log(`updated round`)),
      catchError(this.handleError<any>('updateRound'))
    );
  }

  deleteRound(id): Observable<any> {
    return this.http.delete<any>(endpoint + 'Round/' + id, httpOptions).pipe(
      tap(_ => console.log(`deleted round`)),
      catchError(this.handleError<any>('deleteRound'))
    );
  }

  // #end region

  // # region HandSignal
  getHandSignal(): Observable<any> {
    return this.http.get(endpoint + 'handsignal').pipe(
      map(this.extractData));
  }

  getHandSignalById(id): Observable<any> {
    return this.http.get(endpoint + 'handsignal/' + id).pipe(
      map(this.extractData));
  }

  addHandSignal(handSignal): Observable<any> {

    return this.http.post<any>(endpoint + 'handsignal', JSON.stringify(handSignal), httpOptions).pipe(
      tap((match) => console.log(`added handSignal`)),
      catchError(this.handleError<any>('addHandSignal'))
    );
  }

  filterHandSignal(handSignal): Observable<any> {
    return this.http.post<any>(endpoint + 'handsignal/filter', JSON.stringify(handSignal), httpOptions).pipe(
      map(this.extractData));
  }

  updateHandSignal(id, handSignal): Observable<any> {

    return this.http.put(endpoint + 'handsignal/' + id, JSON.stringify(handSignal), httpOptions).pipe(
      tap(_ => console.log(`updated handSignal`)),
      catchError(this.handleError<any>('updateHandSignal'))
    );
  }

  deleteHandSignal(id): Observable<any> {
    return this.http.delete<any>(endpoint + 'handsignal/' + id, httpOptions).pipe(
      tap(_ => console.log(`deleted handSignal`)),
      catchError(this.handleError<any>('deleteHandSignal'))
    );
  }

  // #end region

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      console.log(`${operation} failed: ${error.message}`);
      return of(result as T);
    };
  }




}
