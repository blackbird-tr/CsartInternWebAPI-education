import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { StorageService } from 'src/app/core/services/storage.service';

@Component({
  selector: 'ai-content-layout',
  templateUrl: './content-layout.component.html',
  styleUrls: ['./content-layout.component.scss'],
})
export class ContentLayoutComponent implements OnInit {
  loginDisplay: boolean=false;



  //region .. Constructors ..
  constructor(
    private storageService: StorageService,
    private router: Router
  ) {
   
  }

  ngOnInit() {

   
  }
  //#endregion


  login(){

  }
  logout(){
    this.storageService.removeFromLocalStorage("jwt");
    this.router.navigate(['auth']);
  }


  
  //#endregion
}
