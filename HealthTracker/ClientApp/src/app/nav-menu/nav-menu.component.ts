import { Component, Input, OnDestroy, OnInit, SimpleChanges } from '@angular/core';
import { Subscription } from 'rxjs';
import { User } from '../user';
import { UserService } from '../user.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit, OnDestroy {

  isExpanded = false;
  currentUser: User;
  subscription: Subscription;

  constructor(private userService: UserService){}
  ngOnInit() {
    this.subscription = this.userService.currentUser.subscribe( (response:any) =>
    {this.currentUser = response;})
  }

  ngOnDestroy(): void {
      this.subscription.unsubscribe();
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  LogOut(){
    this.userService.Logout();
  }
}
