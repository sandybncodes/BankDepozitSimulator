-- COMMISSIONS

use BankDepositSimulator;

CREATE SCHEMA commissions;
GO

CREATE TABLE commissions.BANK_ACCOUNTS (
	BANK_ACCOUNT_ID INT PRIMARY KEY IDENTITY(1, 1),
	BANK_ID INT, -- will be updated to foreigk key
	ACCOUNT_ID INT FOREIGN KEY REFERENCES USERS.ACCOUNTS(ACCOUNT_ID) NOT NULL,
	TITLE VARCHAR(100) NOT NULL,
	COMMENTS VARCHAR(255),
	CURRENT_BALANCE DECIMAL(11, 2) NOT NULL,
	[STATUS] INT CHECK([STATUS] IN (10, 60)) NOT NULL,
	CREATED_DATE DATE NOT NULL,
	UPDATED_DATE DATE,
	UPDATED_COMMENTS VARCHAR(255),
	TERMINATED_DATE DATE
)
GO

INSERT INTO commissions.BANK_ACCOUNTS
VALUES
(9999, 1, 'Demo Title', 'test account', 2555.67, 10, '01-MAR-24', NULL, NULL, NULL)

SELECT * FROM commissions.BANK_ACCOUNTS

CREATE TABLE commissions.TRADES (
	TRADE_ID INT PRIMARY KEY IDENTITY(1, 1),
	DEPOSIT_TYPE VARCHAR(100) NOT NULL,
	CURRENCY VARCHAR(50) NOT NULL,
	BANK_ACCOUNT_ID INT FOREIGN KEY REFERENCES COMMISSIONS.BANK_ACCOUNTS(BANK_ACCOUNT_ID) NOT NULL,
	INVESTED_AMT DECIMAL(11, 2) NOT NULL,
	ANNUAL_RATE_PCT DECIMAL(5, 2) NOT NULL,
	ANNUAL_CHARGED_PCT DECIMAL(5, 2) NOT NULL,
	ANNUAL_PROFIT_AMT DECIMAL(11, 2) NOT NULL,
	ANNUAL_CHARGED_AMT DECIMAL(11, 2) NOT NULL,
	REINVEST VARCHAR(10) CHECK(REINVEST IN ('TRUE', 'FALSE')) NOT NULL
)
GO

INSERT INTO commissions.TRADES
VALUES
('Demo Deposit', 'DOLLAR', 1, 1000.00, 3.44, 0.20, 34.40, 1.24, 'FALSE'),
('Demo Deposit', 'DOLLAR', 1, 15000.00, 3.44, 0.20, 105.34, 10.78, 'FALSE'),
('Demo Deposit', 'DOLLAR', 1, 23455.00, 3.44, 0.20, 498.78, 46.72, 'FALSE')

select * from commissions.TRADES
GO

select * from users.INDIVIDUALS
select * from users.ACCOUNTS
select * from commissions.BANK_ACCOUNTS
select * from commissions.TRADES