import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { BehaviorSubject, Subscription } from 'rxjs';
import { User } from './user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  serviceUrl = "api/user/";

  private messageSource = new BehaviorSubject(null);
  currentUser = this.messageSource.asObservable();

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.serviceUrl = baseUrl + this.serviceUrl;
  }

  Login(user: User){
    console.log("inLogin");
    return this.http.put(this.serviceUrl + 'login', user);
  }

  Logout(){
    this.http.put(this.serviceUrl + 'logout', -1).subscribe();
    this.messageSource.next(null);
  }

  UpdateCurrentUser(){
    this.http.get(this.serviceUrl + 'getcurrentuser').subscribe(
      (response:any) => { this.messageSource.next(response);
        console.log("in updatecurrentuser:");
        console.log(response);
        console.log(this.currentUser); }
    )
  };
}
