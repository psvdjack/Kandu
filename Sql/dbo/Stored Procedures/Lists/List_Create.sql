﻿CREATE PROCEDURE [dbo].[List_Create]
	@boardId int,
	@name nvarchar(64),
	@sort int = 0
AS
DECLARE @id int = NEXT VALUE FOR SequenceLists
IF @sort <= 0 BEGIN
	SELECT @sort = MAX(sort) + 1
	FROM Lists WHERE boardId=@boardId
	IF @sort IS NULL SET @sort = 0
END
INSERT INTO Lists (listId, boardId, [name], sort)
VALUES (@id, @boardId, @name, @sort)

EXEC Board_Modified @boardId=@boardId

SELECT @id