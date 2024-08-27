import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';

function Transactions() {
  const [transactions, setTransactions] = useState([]);

  useEffect(() => {
    fetch('http://localhost:8080/api/transactions')
      .then(response => response.json())
      .then(data => setTransactions(data))
      .catch(error => console.error('Error fetching transactions:', error));
  }, []);

  return (
    <div>
      <h2>Transactions</h2>
      <ul>
        {transactions.map(transaction => (
          <li key={transaction.id}>
            <Link to={`/edit-transaction/${transaction.id}`}>
              {transaction.description} - ${transaction.amount}
            </Link>
          </li>
        ))}
      </ul>
      <Link to="/add-transaction">Add New Transaction</Link>
    </div>
  );
}

export default Transactions;
