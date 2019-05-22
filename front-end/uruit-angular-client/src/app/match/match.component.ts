import { Component, OnInit, Input } from '@angular/core';
import { RestService } from '../rest.service';

@Component({
  selector: 'app-match',
  templateUrl: './match.component.html',
  styleUrls: ['./match.component.css']
})
export class MatchComponent implements OnInit {
  public defaultView = true;
  public roundView = false;
  public moveOneVisible = true;
  public moveTwoVisible = false;

  public p1: any;
  public p2: any;
  public match: any;

  constructor(public rest: RestService) { }

  ngOnInit() {
    this.loadPlayers();
    this.loadMatch();
    this.moveOneVisible = true;
  }

  public selectMoveOne(): void {
    this.moveOneVisible = false;
    this.moveTwoVisible = true;
  }

  public selectMoveTwo(): void {
    this.moveOneVisible = true;
    this.moveTwoVisible = false;
    this.roundView = true;
  }

  public loadMatch(): void {
    this.match = JSON.parse(localStorage.getItem('match'));
    console.log(this.match);
  }

  public loadPlayers(): void {
    this.p1 = JSON.parse(localStorage.getItem('player1'));
    console.log(this.p1);
    this.p2 = JSON.parse(localStorage.getItem('player2'));
    console.log(this.p2);
  }

}
