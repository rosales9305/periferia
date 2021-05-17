import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { Product } from '../model/product.model';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  id: number;
  product: Product;
  productForm: FormGroup;
  cardLabel: string = 'Create a new Product';
  backLabel: string = 'Back';

  constructor(private productService: ProductService,
    private route: ActivatedRoute,
    private router: Router,
    private messageService: MessageService) { }

  ngOnInit(): void {

    this.route.params.subscribe((params: Params) => {
      this.id = +params['id'];
    });

    this.productForm = new FormGroup({
      'id': new FormControl(0),
      'name': new FormControl(null, Validators.required),
      'price': new FormControl(null, Validators.required),
      'stock': new FormControl(null, Validators.required),
      'color': new FormControl(null)
    });

    if (this.id) {
      this.cardLabel = "Edit this Product";
      this.backLabel = "Cancel";

      this.productService.getById(this.id).subscribe(data => {
        this.product = data

        this.productForm.patchValue({
          'id': this.product.id,
          'name': this.product.name,
          'price': this.product.price,
          'stock': this.product.stock,
          'color': this.product.color
        });
      });
    }

  }

  return() {
    this.router.navigate(['products']);
  }

  onSubmit() {
    const product = this.productForm.value as Product;

    if (product.id) {
      this.productService.updateProduct(product.id, product).subscribe(() => {
        this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Product information updated successfully' });
      });
    } else {
      this.productService.createProduct(product).subscribe(() => {
        this.router.navigate(['products']);
        this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Product created successfully' });
      });
    }

  }

}
