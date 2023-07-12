import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/services/auth.service';
import { AccountService } from 'src/app/core/services/data/account.service';
import { StorageService } from 'src/app/core/services/storage.service';

@Component({
  selector: 'ai-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
emailFormControl = new FormControl('', [Validators.required, Validators.email]);
passwordFormControl = new FormControl('',[Validators.required, Validators.minLength(8)]);


  constructor(private accountService: AccountService,
    private storageService: StorageService,
    private authService: AuthService,
    private router: Router) { }

  ngOnInit(): void {
    if(this.authService.isAuthenticated()){
      this.router.navigate(["products"]);
    }
  }


  login(){
    this.accountService.authenticate(this.emailFormControl.value, this.passwordFormControl.value).subscribe(
      response=>{
        this.storageService.addToLocalStorage("jwt", response.data.jwToken);
        this.router.navigate(["products"]);
      });
  }


}
