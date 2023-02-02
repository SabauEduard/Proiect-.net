import {Component, OnInit} from '@angular/core';
import {FormGroup, FormBuilder, Validators} from "@angular/forms";
import {UserService} from "../../services/user.service";
import {Router} from "@angular/router";


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})

export class RegisterComponent implements OnInit{
  registerForm: FormGroup;

  constructor(
    private userService: UserService,
    private formBuilder: FormBuilder,
    private router: Router
  ) {
    this.registerForm = this.formBuilder.group({
      username: [null, [Validators.required]],
      email: [null, [Validators.required]],
      password: [null, [Validators.required, Validators.minLength(2)]],
      lastName: [null, [Validators.required]],
      firstName: [null, [Validators.required]]
    })
  }

  ngOnInit() {

  }
  onSubmit(){
    if(this.registerForm.invalid)
      return;
    console.log(this.registerForm.value);
    this.userService.register(this.registerForm.value.username, this.registerForm.value.password, this.registerForm.value.email,
      this.registerForm.value.lastName, this.registerForm.value.firstName)
  }

}
