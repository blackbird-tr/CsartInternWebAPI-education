import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '@environments/environment';
import { Observable } from 'rxjs';
import { IPagedResults, IProduct } from 'src/app/shared/interfaces';
import { StorageService } from '../storage.service';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  productBaseUrl = environment.apiBaseUrl + "/api/v" + environment.apiVersion +"/product"
  
  constructor(private httpClient: HttpClient, private storageService: StorageService) { 
    console.log(storageService.getFromLocalStorage("jwt"));
  }

  getAll(pageNumber : number, pageSize: number): Observable<IPagedResults<IProduct>>{
    const parames = new HttpParams()
    .set('pageNumber', pageNumber)
    .set('pageSize', pageSize);

    return this.httpClient.get<IPagedResults<IProduct>>(this.productBaseUrl,{params:parames});
  }

  create(name: string, barcode: string, description:string, rate: number ){
    return this.httpClient.post(this.productBaseUrl, 
      {
        name: name,
        barcode: barcode,
        description: description,
        rate: rate
      });
  }


  delete(id: number){
    return this.httpClient.delete(`${this.productBaseUrl}/${id}`);
  }
}
