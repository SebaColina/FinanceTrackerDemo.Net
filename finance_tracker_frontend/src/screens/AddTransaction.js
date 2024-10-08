import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';

function AddTransaction() {
  const [transaction, setTransaction] = useState({
    description: '',
    amount: 0,
    category: '',
    userId: '',
  });
  const navigate = useNavigate();

  const handleSubmit = (e) => {
    e.preventDefault();
    if(transaction.amount === 0 || transaction.category === '' || transaction.description === '' || transaction.userId === ''){
      console.log('Fields missing');
    }else{
      // Logic to add a new transaction
      fetch('http://localhost:8080/api/transactions', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(transaction)
      }).then(() => navigate('/transactions'));
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <h2>Add Transaction</h2>
      <input
        type="text"
        placeholder="Description"
        value={transaction.description}
        onChange={(e) => setTransaction({ ...transaction, description: e.target.value })}
      />
      <input
        type="number"
        placeholder="Amount"
        value={transaction.amount}
        onChange={(e) => setTransaction({ ...transaction, amount: e.target.value })}
      />
      <input
        type="text"
        placeholder="Category"
        value={transaction.category}
        onChange={(e) => setTransaction({ ...transaction, category: e.target.value })}
      />
      <input
        type="text"
        placeholder="UserId"
        value={transaction.userId}
        onChange={(e) => setTransaction({ ...transaction, userId: e.target.value })}
      />
      <button type="submit">Add Transaction</button>
    </form>
  );
}

export default AddTransaction;
