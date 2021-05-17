import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Product } from '../model/product.model';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  products: Product[];
  cols: any[];

  constructor(private productService: ProductService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private router: Router) { }

  ngOnInit(): void {

    this.cols = [
      { field: 'name', header: 'Name', hasSymbol: false },
      { field: 'price', header: 'Price', hasSymbol: true },
      { field: 'stock', header: 'Stock', hasSymbol: false },
      { field: 'color', header: 'Color', hasSymbol: false },
    ];

    this.productService.getAll().subscribe(data => {
      this.products = data;
    });

  }

  deleteProduct(id: number) {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete this product?',
      header: 'Delete Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        this.productService.deleteProduct(id).subscribe(() => {
          this.products = this.products.filter(x => x.id != id);
        });
      }
    });
  }

  redirect(id?: number) {
    if (id) {
      this.router.navigate(['products/', id]);
    } else {
      this.router.navigate(['products/0']);
    }
  }

}
