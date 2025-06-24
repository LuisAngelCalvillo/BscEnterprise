import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { TableModule } from 'primeng/table';
import { Product } from '../../shared/interfaces/product.models';
import { OrderDetailResponse, OrderResponse } from '../../shared/interfaces/order.models';
import { InputNumberModule } from 'primeng/inputnumber';
import { DialogModule } from 'primeng/dialog';
import { DividerModule } from 'primeng/divider';
import { ProductService } from '../../shared/services/product.service';
import { OrderService } from '../../shared/services/order.service';
import { ReportService } from '../../shared/services/report.service';

@Component({
  selector: 'app-staff',
  imports: [TableModule, CommonModule, FormsModule, ButtonModule, InputTextModule, InputNumberModule, DialogModule, DividerModule, ReactiveFormsModule],
  templateUrl: './staff.component.html',
  styleUrl: './staff.component.scss'
})
export class StaffComponent implements OnInit {
  showOrderDialog: boolean = false;
  showProductDialog: boolean = false;
  orders: OrderResponse[] = [];
  orderDetails: OrderDetailResponse[] = [];
  productForm: FormGroup;
  product: Product | undefined;

  constructor(
    private orderService: OrderService,
    private productService: ProductService,
    private reportService: ReportService,
    private fb: FormBuilder
  ){
    this.productForm = this.fb.group({
      productKey: ['', [Validators.required, Validators.minLength(3)]],
      name: ['', [
        Validators.required,
        Validators.minLength(3),
      ]],
      stock: [1, [Validators.required, Validators.min(1)]],
    });
  }

  ngOnInit(): void {
    this.getOrdersData()
  }

  getOrdersData(){
    this.orderService.getOrders().subscribe({
      next: (response) => {
        if (response.completed) {
          this.orders = response.data as OrderResponse[];
        } else {  
          console.error('Obtencion de pedidos fallida:', response.message);
        }
      },
      error: (error) => {
        console.error('Error al obtener pedidos:', error);
      }
    });
  }

  showOrder(idOrder: number){
    this.showOrderDialog = true;
    this.orderService.getDetailOrder(idOrder).subscribe({
      next: (response) => {
        if (response.completed) {
          this.orderDetails = response.data as OrderDetailResponse[];
          console.log(this.orderDetails);
        } else {  
          console.error('Obtencion de detalles del pedido fallida:', response.message);
        }
      },
      error: (error) => {
        console.error('Error al obtener detalles del pedido:', error);
      }
    });
  }

  showCreateProduct(){
    this.showProductDialog = !this.showProductDialog
  }

  createProduct(){
    this.product = this.productForm.value as Product;
    this.productService.createProduct(this.product).subscribe({
      next: (response) => {
        if (response.completed) {
          console.log('Producto creado exitosamente:', response.message);
        } else {  
          console.error('Creacion de producto fallida:', response.message);
        }
      },
      error: (error) => {
        console.error('Error al crear producto:', error);
      }
    });
    this.showCreateProduct()
    this.productForm.reset();
  }

  generateProductReport(){
    this.reportService.getProductsReport().subscribe((data: ArrayBuffer) => {
      const blob = new Blob([data], { type: 'application/pdf' });
      const url = window.URL.createObjectURL(blob);

      const link = document.createElement('a');
      link.href = url;
      link.download = 'ReporteProductos.pdf';
      link.click();

      window.URL.revokeObjectURL(url);
    });
  }

  get productKey() { return this.productForm.get('productKey'); }
  get name() { return this.productForm.get('name'); }
  get stock() { return this.productForm.get('stock'); }
}
