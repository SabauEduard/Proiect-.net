import { Component } from '@angular/core';
import {BehaviorSubject, Observable} from "rxjs";
import {UserWithCredentials} from "../models/user.interface";
import {UserService} from "../services/user.service";

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  user$: Observable<UserWithCredentials | null>
  isExpanded = false;
  constructor(private userService: UserService) {
    this.user$ = userService.user$.asObservable()
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
  login()
  {
    this.userService.login("kanyjmk", "123")
  }

}
