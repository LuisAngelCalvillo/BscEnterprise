export interface Order{
    customerName: string;
    orderNumber: string;
    orderItems: OrderItem[];
}

export interface OrderItem {
    orderId: number;
    productId: number;
    quantity: number;
}

export interface OrderPrev {
    productId: number;
    productName: string;
    quantity: number;
}

export interface OrderResponse {
    idOrder: number;
    customerName: string;
    orderNumber: string;
    orderDate: Date;
}

export interface OrderDetailResponse {
    quantity: number;
    productId: number;
    name: string;
    productKey: string;
}