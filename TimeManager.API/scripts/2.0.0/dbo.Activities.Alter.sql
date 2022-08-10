ALTER TABLE [dbo].[Activities]
ADD DateAdded DATETIME NOT NULL DEFAULT GETDATE(),
    DateCompleted DATETIME,
	Deadline DATETIME 