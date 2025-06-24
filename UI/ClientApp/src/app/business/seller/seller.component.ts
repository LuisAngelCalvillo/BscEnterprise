import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { TableModule } from 'primeng/table';
import { ProductResponse } from '../../shared/interfaces/product.models';
import { Order, OrderPrev } from '../../shared/interfaces/order.models';
import { InputNumberModule } from 'primeng/inputnumber';
import { DialogModule } from 'primeng/dialog';
import { DividerModule } from 'primeng/divider';
import { ProductService } from '../../shared/services/product.service';
import { OrderService } from '../../shared/services/order.service';

@Component({
  selector: 'app-seller',
  imports: [TableModule, CommonModule, FormsModule, ButtonModule, InputTextModule, InputNumberModule, DialogModule, DividerModule],
  templateUrl: './seller.component.html',
  styleUrl: './seller.component.scss'
})
export class SellerComponent {
  products: ProductResponse[] = [];
  orderPrev: OrderPrev[] = [];
  order: Order = {
    customerName: '',
    orderNumber: '',
    orderItems: []
  };
  customerName: string = '';
  showCartDialog: boolean = false;

  constructor(
    private productService: ProductService,
    private orderService: OrderService
  ) {}

  ngOnInit(): void {
    this.getProductsData()
  }

  addToOrder(product: ProductResponse): void {
    if (!product.selectedQuantity || product.selectedQuantity <= 0 || product.selectedQuantity > product.stock) {
      alert('Cantidad inválida');
      return;
    }

    const existingItem = this.orderPrev.find(item => item.productId === product.idProduct);

    if (existingItem) {
      existingItem.quantity += product.selectedQuantity;
    } else {
      this.orderPrev.push({
        productId: product.idProduct,
        quantity: product.selectedQuantity,
        productName: product.name
      });
    }
    product.selectedQuantity = 0;
  }

  removeFromOrder(idProduct: number): void {
    this.orderPrev = this.orderPrev.filter(item => item.productId !== idProduct);
    console.log(this.orderPrev)
  }

  submitOrder(): void {
    this.order.customerName = this.customerName;
    this.order.orderNumber = `ORD-${Math.floor(Math.random() * 10000)}`;
    this.order.orderItems = this.orderPrev.map(item => ({
      orderId: 0,
      productId: item.productId,
      quantity: item.quantity
    }));
    this.orderService.insertOrder(this.order).subscribe({
      next: (response) => { 
        if (response.completed) {
          alert('Pedido realizado con éxito');
          this.orderPrev = [];
          this.customerName = '';
          this.showCartDialog = false;
          this.getProductsData()
        } else {
          alert('Error al realizar el pedido: ' + response.message);
        }
      }
    });
  }

  showCart(){
    this.showCartDialog = !this.showCartDialog;
  }

  getProductsData(){
    this.productService.getProducts().subscribe({
      next: (response) => {
        if (response.completed) {
          this.products = response.data as ProductResponse[];
          this.products = (response.data as ProductResponse[]).map(product => ({
            ...product,
            selectedQuantity: 0
          }));
          console.log(this.products)
        } else {
          console.error('Error obteniendo productos:', response.message);
        }
      }
    })
  }
}
