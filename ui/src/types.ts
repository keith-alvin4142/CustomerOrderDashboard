export interface OrderItem {
  id: any;
  name: any;
  quantity: any;
  price: any;
}

export interface Order {
  id: any;
  customerName: any;
  orderDate: any;
  items: OrderItem[];
  total: any;
  creditCardNumber: any;
}
