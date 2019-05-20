import { Component, OnInit } from '@angular/core';
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
  constructor(public rest: RestService) { }

  ngOnInit() {
    /*load match*/
    /*load players*/

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
}
