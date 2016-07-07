CREATE TABLE [dbo].[Log] (
    [LogId]  INT           NOT NULL IDENTITY,
	[LimitId] INT NOT NULL, 
	[CustomerId]   NVARCHAR (50) NOT NULL,
    [LimitTypeId]  INT           NOT NULL,
    [Limit]        DECIMAL(18, 2)           NOT NULL,
    [PeriodInDays] INT           NULL,
    [StartDate]    DATETIME2 (7) NOT NULL,
    [EndDate]      DATETIME2 (7) NULL,
	[Author]       NVARCHAR (50) NOT NULL,
    [ModificationTime] DATETIME2 (7) NOT NULL, 
    CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED ([LogId] ASC)
);

