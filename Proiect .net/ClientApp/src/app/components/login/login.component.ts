import {Component, OnInit} from '@angular/core';
import {UserService} from "../../services/user.service";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {Router} from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl:'./login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;

  constructor(
    private userService: UserService,
    private router: Router
  ) {
    this.loginForm = new FormGroup({
      email: new FormControl(null, [Validators.required]),
      password: new FormControl(null, [Validators.required, Validators.minLength(2)])
    })
  }

  ngOnInit(): void {

  }

  onSubmit(){
    if(this.loginForm.invalid)
      return;
    this.userService.login(this.loginForm.value.email, this.loginForm.value.password)
  }
  register(){
    this.router.navigate(["/register"])
  }
}
