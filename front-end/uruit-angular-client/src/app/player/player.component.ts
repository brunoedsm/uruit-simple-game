import { Component, OnInit } from '@angular/core';
import { RestService } from '../rest.service';
import { ResponseStatus } from '../util/enumerators';

@Component({
  selector: 'app-player',
  templateUrl: './player.component.html',
  styleUrls: ['./player.component.css']
})
export class PlayerComponent implements OnInit {
  public playerView = true;
  public matchView = false;
  public player1Name = '';
  public player2Name = '';

  public p1: any;
  public p2: any;
  public match: any;

  constructor(private rest: RestService) { }

  ngOnInit() {
    localStorage.clear();
  }

  public nextStep(): void {
    /*save player 1*/
    this.p1 = {
      name: this.player1Name
    };

    this.rest.addPlayer(this.p1).subscribe((result1) => {
      if (result1.status === ResponseStatus.Success) {
        this.rest.filterPlayer(this.p1).subscribe((res) => {
          localStorage.setItem('player1', JSON.stringify(res.data[0]));
        });
        /*save player 2*/
        this.saveNextPlayer();
      }
    });
  }

  private saveNextPlayer() {
    this.p2 = {
      name: this.player2Name
    };
    this.rest.addPlayer(this.p2).subscribe((result2) => {
      if (result2.status === ResponseStatus.Success) {
        this.rest.filterPlayer(this.p2).subscribe((res) => {
          localStorage.setItem('player2', JSON.stringify(res.data[0]));
        });
        /*save match to play*/
        this.saveMatch();
      }
    });
  }

  private saveMatch() {
    const _hashId = this.uuidv4();
    this.match = {
      hashId: _hashId ,
      currentRound: 1
    };
    this.rest.addMatch(this.match).subscribe((result3) => {
      if (result3.status === ResponseStatus.Success) {
        this.rest.filterMatch(this.match).subscribe((res) => {
          localStorage.setItem('match', JSON.stringify(res.data[0]));
          this.playerView = false;
          this.matchView = true;
        });
      }
    });
  }

  private uuidv4(): string {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
      const r = Math.random() * 16 | 0, v = c === 'x' ? r : (r & 0x3 | 0x8);
      return v.toString(16);
    });
  }
}
