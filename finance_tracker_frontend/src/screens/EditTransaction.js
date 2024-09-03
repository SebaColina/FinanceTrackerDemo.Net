import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';

function EditTransaction() {
  const { id } = useParams();
  const [transaction, setTransaction] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    // Fetch transaction data by ID
    fetch(`http://localhost:8080/api/transactions/${id}`)
      .then(response => response.json())
      .then(data => {
        console.warn('Fetched transaction data:', data); // Print the response data here
        setTransaction(data); // Set the state with the fetched data
      })
      .catch(error => console.error('Error fetching transaction:', error));
  }, [id]);

  const handleSubmit = (e) => {
    e.preventDefault();
    console.warn("HEREEEEEEEEEEEEEEEEE",transaction);
    // Logic to update the transaction
    fetch(`http://localhost:8080/api/transactions/`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json'
      },
      mode: 'cors',
      body: JSON.stringify(transaction)
    }).then(() => navigate('/transactions'));
  };

  if (!transaction) return <div>Loading...</div>;

  return (
    <form onSubmit={handleSubmit}>
      <h2>Edit Transaction</h2>
      <input
        type="text"
        value={transaction.description}
        onChange={(e) => setTransaction({ ...transaction, description: e.target.value })}
      />
      <input
        type="text"
        value={transaction.category}
        onChange={(e) => setTransaction({ ...transaction, category: e.target.value })}
      />
      <input
        type="text"
        value={transaction.userId}
        onChange={(e) => setTransaction({ ...transaction, userId: e.target.value })}
      />
      <input
        type="number"
        value={transaction.amount}
        onChange={(e) => setTransaction({ ...transaction, amount: e.target.value })}
      />
      <button type="submit">Save</button>
    </form>
  );
}

export default EditTransaction;
