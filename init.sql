CREATE TABLE IF NOT EXISTS Transactions (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Amount int,
    Date DATE,
    Description VARCHAR(255),
    Category VARCHAR(255),
    UserId VARCHAR(255)
);

INSERT INTO Transactions (Amount, Date, Description, Category, UserId) VALUES
(150, '2024-08-01', 'Grocery shopping at Walmart', 'Groceries', 'user_001'),
(45, '2024-08-02', 'Dinner at Grill', 'Dining', 'user_002'),
(2500, '2024-08-03', 'Salary for August', 'Income', 'user_001'),
(125, '2024-08-04', 'Car repair service', 'Auto Maintenance', 'user_003'),
(89, '2024-08-05', 'Purchase of new headphones', 'Electronics', 'user_002'),
(75, '2024-08-06', 'Utility bill payment', 'Utilities', 'user_001'),
(300, '2024-08-07', 'Freelance work payment', 'Income', 'user_004');
