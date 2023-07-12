import { NgModule, Optional, SkipSelf } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { EnsureModuleLoadedOnceGuard } from './ensure-module-loaded-once.guard';
import { Meta } from '@angular/platform-browser';
import { StorageService } from './services/storage.service';
import { AccountService } from './services/data/account.service';
import { ProductService } from './services/data/product.service';
import { AuthService } from './services/auth.service';

@NgModule({
  imports: [CommonModule, RouterModule, HttpClientModule ],
  exports: [RouterModule, HttpClientModule],
  providers: [
    Meta,
    AuthService,
    StorageService,
    AccountService,
    ProductService,
    /*
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorHandleInterceptor,
      multi: true,
    },*/
    { provide: 'Window', useFactory: () => window },
  ], // these should be singleton
})
export class CoreModule extends EnsureModuleLoadedOnceGuard {
  // Ensure that CoreModule is only loaded into AppModule

  // Looks for the module in the parent injector to see if it's already been loaded (only want it loaded once)
  constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
    super(parentModule);
  }
}
