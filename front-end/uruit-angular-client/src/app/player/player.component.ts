import { Component, OnInit } from '@angular/core';
import { RestService } from '../rest.service';

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

  constructor(public rest: RestService) { }

  ngOnInit() {

  }

  public nextStep(): void {
    /*save players*/
    let p1: any = {
      name: this.player1Name
    };

    this.rest.addPlayer(p1).subscribe((result1) => {
      console.log(result1);
      let p2: any = {
        name: this.player2Name
      };
      this.rest.addPlayer(p2).subscribe((result2) => {
        console.log(result2);
      });
    });

    /*todo: save match*/
    this.playerView = false;
    this.matchView = true;
  }

}
