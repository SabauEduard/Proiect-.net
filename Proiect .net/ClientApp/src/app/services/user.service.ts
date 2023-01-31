import {Inject, Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {UserWithCredentials} from "../models/user.interface";
import {BehaviorSubject} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class UserService {
  localStorageKey: string = "user"
  baseUrl: string
  user$: BehaviorSubject<UserWithCredentials | null>

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string)
  {
    this.baseUrl = baseUrl;
    this.user$ = new BehaviorSubject<UserWithCredentials | null>(null)
    this.autoRefresh()
    this.saveUserToLocalStorage()
    this.getUserFromLocalStorage()
  }
  saveUserToLocalStorage()
  {
    this.user$.subscribe(data => localStorage.setItem(this.localStorageKey, JSON.stringify(data)))
  }
  getUserFromLocalStorage()
  {
    let user = JSON.parse(localStorage.getItem(this.localStorageKey)??"null")
    this.user$.next(user)
  }
  login(username: string, password: string)
  {
    this.http.post<UserWithCredentials>(this.baseUrl + "api/Users/authenticate", {username, password})
      .subscribe((data)=>this.user$.next(data))
  }
  logout()
  {
    this.user$.next(null)
  }
  refresh(token: string)
  {
    this.http.post<UserWithCredentials>(this.baseUrl + "api/Users/refreshToken", {token})
      .subscribe((data) => this.user$.next(data), () => this.logout())
  }
  autoRefresh()
  {
    this.user$.subscribe(data => {
      if(data === null)
        return;
      let currentDate = new Date()
      let expirationDate = this.getExpirationDate(data.token)
      let timeOut = expirationDate.getTime() - currentDate.getTime()
      timeOut = timeOut > 0 ? timeOut : 0
      setTimeout(()=>{
        this.refresh(data.refreshToken)
      }, timeOut)
    })
  }
  getTokenClaims(token: string): any {
    const base64Url = token.split('.')[1];
    if (!base64Url) return {};
    const base64 = base64Url.replace('-', '+').replace('_', '/');
    return JSON.parse(window.atob(base64));
  }
  getExpirationDate(token: string | null | undefined): Date {
    if (!token) return new Date();
    const claims = this.getTokenClaims(token);
    return new Date(claims.exp * 1000);
  }
}
