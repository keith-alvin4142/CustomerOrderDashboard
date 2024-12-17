import { useState, useEffect } from 'react';
import { OrderForm } from './components/OrderForm';
import { OrderList } from './components/OrderList';
import { Order } from './types';
import './styles.css';
import { orderApi } from './orderApi.ts';

export const App = () => {
  const [orders, setOrders] = useState<Order[]>([]);

  useEffect(() => {
    orderApi.getOrders().then(data => setOrders(data));
  }, []);

  return (
    <div>
      <h1>Order Dashboard</h1>
      <OrderForm setOrders={setOrders} />
      <OrderList orders={orders} setOrders={setOrders} />
    </div>
  );
};
