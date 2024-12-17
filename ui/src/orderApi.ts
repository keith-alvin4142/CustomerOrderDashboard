import { Order } from './types';
import { v4 as uuid } from 'uuid';

const useMockApi = true;

const mockOrders: Order[] = [
  {
    id: uuid(),
    customerName: "John Smith",
    orderDate: "2024-03-15T10:30:00",
    items: [
      { id: uuid(), name: "Widget", quantity: 2, price: 10 },
      { id: uuid(), name: "Gadget", quantity: 1, price: 20 }
    ],
    total: 40,
    creditCardNumber: "1234-5678-1234-5678",
  },
  {
    id: uuid(),
    customerName: "Jane Doe",
    orderDate: "2024-03-14T15:45:00",
    items: [
      { id: uuid(), name: "Thingamajig", quantity: 3, price: 15 }
    ],
    total: 45,
    creditCardNumber: "1234-5678-1234-5678",
  }
];

export const orderApi = {
  mockOrders: [...mockOrders],
  getOrders: function() {
    if (useMockApi) {
      return Promise.resolve(this.mockOrders);
    } else {
      return fetch('http://localhost:5000/api/orders')
        .then(res => res.json());
    }
  },
  createOrder: function(newOrder: Order): Promise<Order[]> {
    if (useMockApi) {
      this.mockOrders = [...this.mockOrders, newOrder];
      return Promise.resolve(this.mockOrders);
    } else {
      return fetch('http://localhost:5000/api/orders', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(newOrder)
      }).then(res => res.json());
    }
  }
};
