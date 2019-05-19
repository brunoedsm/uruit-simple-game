import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-player',
  templateUrl: './player.component.html',
  styleUrls: ['./player.component.css']
})
export class PlayerComponent implements OnInit {
  public playerView = true;
  public matchView = false;
  constructor() { }

  ngOnInit() {

  }

  public nextStep(): void {
      /*todo: save players*/
      /*todo: save match*/
      this.playerView = false;
      this.matchView = true;
  }

}
