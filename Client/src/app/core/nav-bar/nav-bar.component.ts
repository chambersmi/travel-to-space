import { BreakpointObserver } from '@angular/cdk/layout';
import { Component, OnInit, makeEnvironmentProviders } from '@angular/core';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { AccountService } from 'src/app/account/account.service';
import { BasketService } from 'src/app/basket/basket.service';
import { BasketItem } from 'src/app/shared/models/basket';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent {

  constructor(public basketService:BasketService, public accountService:AccountService) {}


  getCount(items:BasketItem[]) {
    return items.reduce((sum, item) => sum + item.quantity, 0);
  }
}
