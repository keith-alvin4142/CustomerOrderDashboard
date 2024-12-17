import { useState, FormEvent } from 'react';
import { OrderItem, Order } from '../types';
import { orderApi } from '../orderApi';
import { v4 as uuid } from 'uuid';

interface IProps {
    setOrders: (orders: Order[]) => void;
}

export const OrderForm = ({ setOrders }: IProps) => {
    let [customerName, setCustomerName] = useState('');
    const [items, setItems] = useState<OrderItem[]>([]);
    const [numberOfItems, setNumberOfItems] = useState(0);

    const handleSubmit = async (e: FormEvent) => {
        e.preventDefault();

        const newOrder = {
            id: uuid(),
            customerName,
            orderDate: new Date().toISOString(),
            items,
            total: items.reduce((acc, item) => acc + (item.quantity + item.price), items[0].price),
            creditCardNumber: "1234-5678-1234-5678",
        };

        const updateOrders = await orderApi.createOrder(newOrder);
        setOrders(updateOrders);

        setItems([]);
        setNumberOfItems(0);
        customerName = '';
    };

    return (
        <form onSubmit={handleSubmit}>
            <input
                className="customer-name"
                value={customerName}
                onChange={e => setCustomerName(e.target.value)}
                placeholder="Customer Name"
            />

            {numberOfItems > 0 && (
                <div className="item-headers">
                    <h3>Item Name</h3>
                    <h3>Quantity</h3>
                    <h3>Price</h3>
                </div>
            )}

            {items.map((item, index) => (
                <div key={item.id} className="item-row">
                    <input
                        value={item.name}
                        onChange={e => {
                            const newItems = [...items];
                            newItems[index] = { ...item, name: e.target.value };
                            setItems(newItems);
                        }}
                        placeholder="Item name"
                    />
                    <input
                        type="number"
                        value={item.quantity}
                        onChange={e => {
                            const newItems = [...items];
                            newItems[index] = { ...item, quantity: Number(e.target.value) };
                            setItems(newItems);
                        }}
                        placeholder="1"
                    />
                    <input
                        type="number"
                        value={item.price}
                        onChange={e => {
                            const newItems = [...items];
                            newItems[index] = { ...item, price: Number(e.target.value) };
                            setItems(newItems);
                        }}
                        placeholder="0"
                    />
                </div>
            ))}

            <div className="buttons">
                <button
                    type="button"
                    onClick={() => {
                        setItems([...items, { id: uuid(), name: '', quantity: 1, price: 0 }]);
                        setNumberOfItems(numberOfItems + 1);
                    }}
                >
                    Add Item
                </button>
                <button type="submit">
                    Submit Order
                </button>
            </div>
        </form>
    );
};
