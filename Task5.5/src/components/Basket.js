import React from 'react'

export default function Basket(props) {
    const { cartItems, onAdd, onRemove } = props;
    const TotalPrice = cartItems.reduce((a, c) => a + c.price * c.qty, 0);

    return <aside className='block col-1'>
        <h2>Basket Items</h2>
        <div>
            {cartItems.length === 0 && <div>Basket Is Empty</div>}
        </div>
        {cartItems.map((item) => (
            <div key={item.id} className='row'>
                <div className='col-2'>{item.name}</div>
                <div className='col-2'>
                    <button onClick={() => onAdd(item)} className='add'>Add</button>
                    <button onClick={() => onRemove(item)} className='remove'>Remove</button>
                </div>
                <div className='col-2 text-right'>
                    {item.qty} x ${item.price}
                </div>
            </div>
        ))}
        {cartItems.length !== 0 && (
            <>
                <hr></hr>
                <div className='row'>
                    <div className='col-2'>Total Price</div>
                    <div className='col-1 text-right'>${TotalPrice}</div>

                </div>

                <hr />
                <div className='row'>
                    <button onClick={() => alert('Your order has been purchased!')}>
                        Checkout
                    </button>
                </div>
            </>
        )}
    </aside>;
}