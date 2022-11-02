CREATE TABLE [dbo].[Tokens] (
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int]  NOT NULL,
	[createDate] [datetime] NOT NULL DEFAULT GETDATE(),
	[expirationDate] [datetime] NOT NUll DEFAULT GETDATE()+1,
	[token] [varchar](1000) NOT NULL,
	PRIMARY KEY (Id)
)