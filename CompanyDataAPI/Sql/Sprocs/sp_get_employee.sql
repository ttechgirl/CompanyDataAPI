	CREATE PROCEDURE [dbo].[sp_get_employee]
	@Id uniqueidentifier
AS
	SELECT c.Id,c.Address,c.City,c.State
	FROM Company c JOIN Employee e ON c.Id= e.CompanyId
	WHERE e.Id = @Id
