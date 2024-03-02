-- create the stored procedure which will select the trades details
CREATE PROCEDURE selectTrades @userSSN varchar(15), @userAccountID INT, @bankAccountID INT
AS
SELECT a.SSN, a.USERNAME, a.[PASSWORD], a.account_id, b.BANK_ACCOUNT_ID, b.BANK_ID, c.*
FROM users.ACCOUNTS a
join commissions.BANK_ACCOUNTS b
on a.ACCOUNT_ID = b.ACCOUNT_ID
join commissions.TRADES c
on b.BANK_ACCOUNT_ID = c.BANK_ACCOUNT_ID
where a.ssn = @userSSN and a.ACCOUNT_ID = @userAccountID and b.BANK_ACCOUNT_ID = @bankAccountID;