import { Component, Input, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { User } from '../user';
import { UserService } from '../user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit, OnDestroy {

  currentUser: User;
  subscription: Subscription;
  message: string;

  userLogin: User = {userId:0, username: "", password: "", displayName: ""};

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.subscription = this.userService.currentUser.subscribe( (response:any) =>{
      this.currentUser = response; }
      );
  }

  ngOnDestroy(): void {
      this.subscription.unsubscribe();
  }

  Login(){
    let success;
    this.userService.Login(this.userLogin).subscribe(
      (response:any) => { success = response;
      console.log(response);

    if(success){
      this.userService.UpdateCurrentUser();
    }
    else{
      this.message = "Invalid username or password.";
    } }
    );
  }
}
