import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AlertsModule } from 'angular-alert-module';

import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';
import { MatchComponent } from './match/match.component';
import { PlayerComponent } from './player/player.component';
import { HandsignalComponent } from './handsignal/handsignal.component';

@NgModule({
  declarations: [
    AppComponent,
    MatchComponent,
    PlayerComponent,
    HandsignalComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AlertsModule.forRoot(),
    RouterModule.forRoot(
      [
        { path: '', component: AppComponent },
        { path: 'player', component: PlayerComponent },
        { path: 'match', component: MatchComponent },
        { path: 'handsignal', component: HandsignalComponent }
      ]
    )
  ],
  providers: [],
  bootstrap: [AppComponent]

})
export class AppModule { }
