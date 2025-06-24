export interface Product{
    idProduct?: number;
    productKey: string;
    name: string;
    stock: number;
}

export interface ProductResponse {
    selectedQuantity: number;
    idProduct: number;
    productKey: string;
    name: string;
    stock: number;
}