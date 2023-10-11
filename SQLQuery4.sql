CREATE PROCEDURE sp_GetAllEntities
    @TableName NVARCHAR(128)
AS
BEGIN
    DECLARE @Sql NVARCHAR(MAX);
    SET @Sql = N'SELECT * FROM ' + @TableName;
    EXEC sp_executesql @Sql;
END
