import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { RouterModule, Routes } from '@angular/router';
import { ContentLayoutComponent } from './layout/content-layout/content-layout.component';
import { PageNotFoundComponent } from './pagenotfound/pagenotfound.component';
import { AuthLayoutComponent } from './layout/auth-layout/auth-layout.component';

const app_routes: Routes = [
  {
    path: '',
    component: AppComponent,
    redirectTo: 'auth'
  },
  {
    path: 'auth',
    component: AuthLayoutComponent,
    title: 'Authentication',
    loadChildren: () => import('./auth/auth.module').then((m) => m.AuthModule),
  },
  {
    path: 'products',
    component: ContentLayoutComponent,
    title: 'Products',
    loadChildren: () => import('./products/products.module').then((m) => m.ProductsModule),
  },
  {
    path: '404',
    component: PageNotFoundComponent,
    title: 'Not Found | 404',
  },
  { 
    path: '**', 
    redirectTo: '/404' 
  }
];

@NgModule({
  imports: [RouterModule.forRoot(app_routes, { enableTracing: true })],
  exports: [RouterModule],
  providers: [],
})
export class AppRoutingModule { }
