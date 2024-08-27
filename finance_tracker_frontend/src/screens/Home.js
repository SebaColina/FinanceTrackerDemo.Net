import React from 'react';

const Home = () => {
  return (
    <div style={{ padding: '20px' }}>
      <h1>Welcome to Finance Tracker</h1>
      <p>
        This application helps you manage and track your financial transactions.
      </p>
      <p>
        Use the navigation bar to access different sections of the app:
      </p>
      <ul>
        <li><strong>Transactions:</strong> View all your transactions.</li>
        <li><strong>Add Transaction:</strong> Add a new transaction to your records.</li>
        <li><strong>Edit Transaction:</strong> Modify an existing transaction.</li>
        <li><strong>Reports:</strong> View reports based on your transactions.</li>
        <li><strong>Settings:</strong> Configure your preferences.</li>
      </ul>
    </div>
  );
};

export default Home;
