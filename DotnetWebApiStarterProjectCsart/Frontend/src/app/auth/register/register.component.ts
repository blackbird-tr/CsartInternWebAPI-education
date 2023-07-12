import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'ai-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  
  registerForm: FormGroup;
 
  get email() { return this.registerForm.get('email'); }
  get name() { return this.registerForm.get('name'); }
  get surname() { return this.registerForm.get('surname'); }
  get password() { return this.registerForm.get('password'); }
  get confirmPassword() { return this.registerForm.get('confirmPassword'); }

  constructor() { }

  ngOnInit(): void {
    this.registerForm = new FormGroup(
      {
        name: new FormControl('', [Validators.required, Validators.minLength(2)]),
        surname: new FormControl('', [Validators.required, Validators.minLength(2)]),
        email: new FormControl('', [Validators.required, Validators.email]),
        password: new FormControl('', [Validators.required, Validators.minLength(8)]),
        confirmPassword: new FormControl('', [Validators.required, Validators.minLength(8)])
      }, 
      this.passwordMatchValidator
    );
  }

  passwordMatchValidator(form: FormGroup) {
    if(form.get('password').invalid || form.get('confirmPassword').invalid){
      return null;
    }
    return  form.get('password').value === form.get('confirmPassword').value
      ? null : { 'passwordMismatch': true };
  }

  register(){
    console.log(this.registerForm);
  }
}
