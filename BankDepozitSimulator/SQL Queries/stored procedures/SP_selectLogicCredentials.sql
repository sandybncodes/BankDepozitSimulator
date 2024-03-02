-- Create stored procedure which will select the login credentials
CREATE PROCEDURE selectLoginCredentials @username varchar(100)
AS
SELECT a.SSN, a.USERNAME, a.[PASSWORD], a.account_id, b.BANK_ACCOUNT_ID, b.BANK_ID
FROM users.ACCOUNTS a
join commissions.BANK_ACCOUNTS b
on a.ACCOUNT_ID = b.ACCOUNT_ID
where a.USERNAME = @username;


EXEC selectLoginCredentials @username = 'john.doe'
