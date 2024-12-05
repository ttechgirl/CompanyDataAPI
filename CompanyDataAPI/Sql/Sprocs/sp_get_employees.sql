	CREATE PROCEDURE [dbo].[sp_get_employees]
AS
	SELECT * FROM Employee WHERE IsDeleted <> 1
