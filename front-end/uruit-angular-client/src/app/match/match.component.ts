import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { RestService } from '../rest.service';

@Component({
  selector: 'app-match',
  templateUrl: './match.component.html',
  styleUrls: ['./match.component.css']
})

/*MAIN COMPONENT OF APP*/

export class MatchComponent implements OnInit {
  public defaultView = true;
  public roundView = false;
  public moveOneVisible = true;
  public moveTwoVisible = false;

  public p1: any;
  public p2: any;
  public match: any;
  public handSignals: any;
  public rounds: any;
  public choices: any;
  public p1selectedHand: any;
  public p2selectedHand: any;
  public winnerName: string;

  constructor(private rest: RestService) { }

  ngOnInit() {
    this.loadPlayers();
    this.loadMatch();
    this.loadHandSignals();
    this.moveOneVisible = true;
    this.choices = [];
  }

  public selectMoveOne(): void {
    this.moveOneVisible = false;
    this.moveTwoVisible = true;
    this.choices.push({ hand: this.p1selectedHand.description });
  }

  public selectMoveTwo(): void {

    this.choices.push({ hand: this.p2selectedHand.description });
    this.validateMatch();
  }

  public loadMatch(): void {
    this.match = JSON.parse(localStorage.getItem('match'));
  }

  public loadPlayers(): void {
    this.p1 = JSON.parse(localStorage.getItem('player1'));
    this.p2 = JSON.parse(localStorage.getItem('player2'));
  }

  public loadHandSignals(): void {
    this.rest.getHandSignal().subscribe((res) => {
      this.handSignals = res.data;
      this.p1selectedHand = this.p2selectedHand = this.handSignals[0];
    });
  }

  public loadRounds(): void {
    this.rest.filterRound({ matchId: this.match.id }).subscribe((res) => {
      this.rounds = res.data;
    });
  }

  public validateMatch(): void {
    const choiceP1 = this.choices[0].hand;
    const choiceP2 = this.choices[1].hand;
    let _winnerId: any;

    if ((choiceP1 === 'Rock' && choiceP2 === 'Scissor') ||
      (choiceP1 === 'Paper' && choiceP2 === 'Rock') ||
      (choiceP1 === 'Scissor' && choiceP2 === 'Paper')) {
      _winnerId = this.p1.id;
    } else if (choiceP1 === choiceP2) {
      _winnerId = 0;
    } else {
      _winnerId = this.p2.id;
    }

    const round = {
      matchId: this.match.id,
      playerId: this.p1.id,
      handsignalId: this.p1selectedHand.id,
      secondPlayerId: this.p2.id,
      secondHandSignalId: this.p2selectedHand.id,
      winnerId: _winnerId
    };

    const p1 = this.p1;
    const p2 = this.p2;

    this.rest.addRound(round).subscribe((res) => {

      this.match.currentRound++;
      this.loadRounds();

      this.rest.updateMatch(this.match.id, this.match).subscribe((res) => {

        if (this.match.currentRound <= 3) {
          this.moveOneVisible = true;
          this.moveTwoVisible = false;
          this.choices = [];
          this.roundView = true;
        } else {
          this.moveOneVisible = false;
          this.moveTwoVisible = false;
          let p1Wins = 0;
          let p2Wins = 0;
          this.rest.filterRound({ matchId: this.match.id }).subscribe((res) => {
            /*Calculate and show the winner*/
            p1Wins = res.data.filter(function (x) { return x.winnerId === p1.id; }).length;
            p2Wins = res.data.filter(function (x) { return x.winnerId === p2.id; }).length;
            if (p1Wins > p2Wins) {
              this.winnerName = p1.name;
            } else if (p1Wins < p2Wins) {
              this.winnerName = p2.name;
            } else {
              this.winnerName = 'Draw';
            }
          });
        }
      });
    });
  }
}
