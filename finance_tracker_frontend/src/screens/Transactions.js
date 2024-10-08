import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';

function Transactions() {
  const [transactions, setTransactions] = useState([]);
  const [loading, setLoading] = useState(true); // Add loading state

  useEffect(() => {
    fetch('http://localhost:8080/api/transactions')
      .then(response => response.json())
      .then(data => {
        setTransactions(data);
        setLoading(false); // Set loading to false after data is fetched
      })
      .catch(error => {
        console.error('Error fetching transactions:', error);
        setLoading(false); // Set loading to false even if there's an error
      });
  }, []);

  if (loading) {
    return <div>Loading...</div>; // Display loading message while fetching data
  }

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