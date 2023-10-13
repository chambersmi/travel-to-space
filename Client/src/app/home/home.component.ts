import { Component } from '@angular/core';
import { AppComponent } from '../app.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  title:string = '';

  constructor(private appComponent:AppComponent) {
  this.title = this.appComponent.getTitle();

  }
}
