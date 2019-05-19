import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';
import { MatchComponent } from './match/match.component';
import { PlayerComponent } from './player/player.component';
import { HandsignalComponent } from './handsignal/handsignal.component';
import { RoundComponent } from './round/round.component';

@NgModule({
  declarations: [
    AppComponent,
    MatchComponent,
    PlayerComponent,
    HandsignalComponent,
    RoundComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(
      [
        { path: '', component: AppComponent },
        { path: 'match', component: MatchComponent }
      ]
    )
  ],
  providers: [],
  bootstrap: [AppComponent]

})
export class AppModule { }
