export interface OrderItem {
  id: string;
  name: string;
  quantity: number;
  price: any;
}

export interface Order {
  id: string;
  customerName: string;
  orderDate: string;
  items: OrderItem[];
  total: number;
}

export interface OrderFormData {
  customerName: string;
  orderDate: string;
  items: Omit<OrderItem, 'id'>[];
  total: number;
}
