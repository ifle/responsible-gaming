CREATE TABLE [dbo].[Log] (
    [Id] INT NOT NULL IDENTITY  ,
    [Action] NVARCHAR(50) NOT NULL, 
    [CustomerId]   NVARCHAR (50) NOT NULL,
    [Limit]        NVARCHAR(50)	NOT NULL,
    [PeriodInDays] NVARCHAR(50)	NOT NULL,
    [StartDate]    NVARCHAR(50) NOT NULL,
    [EndDate]      NVARCHAR(50) NOT NULL,
	[Author]       NVARCHAR (50) NOT NULL,
    [CreationTime] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Log] PRIMARY KEY ([Id])
);



GO

CREATE INDEX [IX_Log_CustomerId] ON [dbo].[Log] ([CustomerId])

GO

CREATE INDEX [IX_Log_Author] ON [dbo].[Log] ([Author])
