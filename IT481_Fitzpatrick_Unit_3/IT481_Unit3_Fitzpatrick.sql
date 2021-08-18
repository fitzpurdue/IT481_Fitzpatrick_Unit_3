CREATE ROLE CEORole;
CREATE ROLE HRRole;
CREATE ROLE SalesRole;

GRANT SELECT ON Customers TO SalesRole;
GRANT SELECT ON Orders TO SalesRole;
GRANT SELECT ON Employees TO HRRole;
GRANT SELECT ON Orders TO CEORole;
GRANT SELECT ON Customers TO CEORole;
GRANT SELECT ON Employees TO CEORole;

CREATE LOGIN User_CEO WITH PASSWORD = 'ceo123';
CREATE LOGIN User_HR WITH PASSWORD = 'hr123';
CREATE LOGIN User_Sales WITH PASSWORD = 'sales123';

CREATE USER User_CEO FOR LOGIN User_CEO;
CREATE USER User_HR FOR LOGIN User_HR;
CREATE USER User_Sales FOR LOGIN User_Sales;

EXEC sp_addrolemember 'CEORole', 'User_CEO';
EXEC sp_addrolemember 'HRRole', 'User_HR';
EXEC sp_addrolemember 'SalesRole', 'User_Sales';

SELECT DP1.name AS DatabaseRoleName,   
   isnull (DP2.name, 'No members') AS DatabaseUserName   
 FROM sys.database_role_members AS DRM  
 RIGHT OUTER JOIN sys.database_principals AS DP1  
   ON DRM.role_principal_id = DP1.principal_id  
 LEFT OUTER JOIN sys.database_principals AS DP2  
   ON DRM.member_principal_id = DP2.principal_id  
WHERE DP1.type = 'R'
ORDER BY DP1.name;