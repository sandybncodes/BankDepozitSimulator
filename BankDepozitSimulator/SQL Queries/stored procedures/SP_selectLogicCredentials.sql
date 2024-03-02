-- Create stored procedure which will select the login credentials
CREATE PROCEDURE selectLoginCredentials @username varchar(100)
AS
SELECT SSN, USERNAME, [PASSWORD]
FROM USERS.ACCOUNTS
WHERE USERNAME = @username;

EXEC selectLoginCredentials @username = 'john.doe'

SELECT a.SSN, a.USERNAME, a.[PASSWORD], a.account_id, b.BANK_ACCOUNT_ID, b.BANK_ID
FROM users.ACCOUNTS a
join commissions.BANK_ACCOUNTS b
on a.ACCOUNT_ID = b.ACCOUNT_ID