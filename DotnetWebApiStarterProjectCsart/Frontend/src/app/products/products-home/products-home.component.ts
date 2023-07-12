import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/core/services/data/product.service';
import { IProduct } from 'src/app/shared/interfaces';

@Component({
  selector: 'ai-products-home',
  templateUrl: './products-home.component.html',
  styleUrls: ['./products-home.component.scss']
})
export class ProductsHomeComponent implements OnInit {

  products: IProduct[];
  displayedColumns: string[] = ['name', 'barcode', 'description', 'rate','action'];
  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.loadProducts();
  }



  loadProducts(){
    this.productService.getAll(1,100).subscribe(resp=>{this.products = resp.data});
  }

  delete(product:IProduct){
    this.productService.delete(product.id).subscribe(t=>{
      alert("Success");
      this.loadProducts();
    })
  }

  create(){
    this.productService.create(this.randomString(5),this.randomString(8),this.randomString(20), Math.floor(Math.random() * 99 + 1)).subscribe(t=> {
      alert("Success");
      this.loadProducts();
    });
  }

  randomString(length) {
    var randomChars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    var result = '';
    for ( var i = 0; i < length; i++ ) {
        result += randomChars.charAt(Math.floor(Math.random() * randomChars.length));
    }
    return result;
}

}
