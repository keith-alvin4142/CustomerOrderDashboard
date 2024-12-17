import { Order } from '../types';

interface IProps {
    orders: Order[];
    setOrders: (orders: Order[]) => void;
}

export const OrderList = ({ orders, setOrders }: IProps) => {
    const calculateTotals = () => orders.reduce((acc, order) => acc + order.total, 0);

    return (
        <div>
            <h2>Orders (Total: £{calculateTotals()})</h2>
            {orders.map((order) => (
                <div key={order.id}>
                    <h3>{order.customerName}</h3>
                    <p>
                        Date: {new Date(order.orderDate).toLocaleDateString('en', {
                            year: 'numeric',
                            month: 'short',
                            day: 'numeric'
                        })}
                    </p>
                    <p>Total: £{order.total}</p>
                    <button onClick={() => {
                        setOrders(orders.filter(o => {
                            if (o.id == order.id) {
                                return false
                            } else {
                                return true
                            }
                        }))
                    }}>
                        Delete
                    </button>
                </div>
            ))}
        </div>
    );
};
