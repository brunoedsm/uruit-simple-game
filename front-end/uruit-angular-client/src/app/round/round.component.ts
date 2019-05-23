import { Component, OnInit } from '@angular/core';
import { RestService } from '../rest.service';

@Component({
  selector: 'app-round',
  templateUrl: './round.component.html',
  styleUrls: ['./round.component.css']
})
export class RoundComponent implements OnInit {

  public roundView = true;
  public p1: any;
  public p2: any;
  public match: any;
  public score: any;

  constructor(public rest: RestService) { }

  ngOnInit() {
    this.loadPlayers();
    this.loadMatch();
    this.loadRounds();
  }

  public loadPlayers(): void {
    this.p1 = JSON.parse(localStorage.getItem('player1'));
    this.p2 = JSON.parse(localStorage.getItem('player2'));
  }

  public loadRounds(): void {
    this.rest.filterRound({ matchId: this.match.id }).subscribe((res) => {
         this.score = res.data;
         console.log(this.score);
    });
  }

  public loadMatch(): void {
    this.match = JSON.parse(localStorage.getItem('match'));
  }
}
