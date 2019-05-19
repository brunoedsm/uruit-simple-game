import { Component, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  encapsulation: ViewEncapsulation.None
})
export class AppComponent {
  public play = false;
  public playerView = false;

  public handSignalView = false;
  constructor() { }

  public start(): void {
    this.play = true;
    this.playerView = true;
  }

}
