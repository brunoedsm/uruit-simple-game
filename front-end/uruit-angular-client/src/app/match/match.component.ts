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
  public handSignals: any;

  public choices: any;
  public p1selectedHand: any;
  public p2selectedHand: any;
  public winnerName:string;

  constructor(public rest: RestService) { }

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
    });
  }

  public validateMatch(): void {  
    var choiceP1 = this.choices[0].hand;
    var choiceP2 = this.choices[1].hand;
    var _winnerId: any;
    if ((choiceP1 == "Rock" && choiceP2 == "Scissor") || (choiceP1 == "Paper" && choiceP2 == "Rock") || (choiceP1 == "Scissor" && choiceP2 == "Paper")) {
      /*Log P1 win*/
      _winnerId = this.p1.id;
    }
    else if (choiceP1 == choiceP2) {
      /*Log Draw */
      _winnerId = 0;
    }
    else {
      /*Log P2 win */
      _winnerId = this.p2.id;
    }

    var round = {
      matchId: this.match.id,
      playerId: this.p1.id,
      handsignalId: this.p1selectedHand.id,
      secondPlayerId: this.p2.id,
      secondHandSignalId: this.p2selectedHand.id,
      winnerId: _winnerId
    }

    this.rest.addRound(round).subscribe((res) => {
      this.match.currentRound++;
      this.rest.updateMatch(this.match.id, this.match).subscribe((res) => {
        if (this.match.currentRound <= 3) {
          this.moveOneVisible = true;
          this.moveTwoVisible = false;
          this.choices = [];
          this.roundView = true;
        }
        else {
          this.moveOneVisible = false;
          this.moveTwoVisible = false;
          var p1Wins = 0;
          var p2Wins = 0;
          /*Calculate and show the winner*/
          this.rest.filterRound({ matchId: this.match.id, playerId: this.p1.id }).subscribe((res) => {
            p1Wins = res.data.length;
            this.rest.filterRound({ matchId: this.match.id, secondPlayerId: this.p2.id }).subscribe((res) => {
              p2Wins = res.data.length;
              if(p1Wins > p2Wins)
              {
                  this.winnerName = this.p1.name;
              }
              else if(p1Wins < p2Wins)
              {
                  this.winnerName = this.p2.name;
              }
              else{
                  this.winnerName = "Draw";
              }

            });
          });
        }
      });
    });
  }
}
