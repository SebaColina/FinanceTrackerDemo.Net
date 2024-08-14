CREATE TABLE IF NOT EXISTS Transactions (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Amount DECIMAL(10, 2),
    Date DATE,
    Description VARCHAR(255),
    Category VARCHAR(255),
    UserId VARCHAR(255),
);