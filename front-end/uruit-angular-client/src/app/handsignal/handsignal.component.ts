import { Component, OnInit } from '@angular/core';
import { RestService } from '../rest.service';

@Component({
  selector: 'app-handsignal',
  templateUrl: './handsignal.component.html',
  styleUrls: ['./handsignal.component.css']
})
export class HandsignalComponent implements OnInit {

  constructor(private rest: RestService) { }

  ngOnInit() {
  }

}
