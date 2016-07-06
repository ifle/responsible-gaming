CREATE TABLE [dbo].[Limit] (
    [CustomerId]   NVARCHAR (50) NOT NULL,
    [LimitTypeId]  INT           NOT NULL,
    [Limit]        DECIMAL(18, 2)           NOT NULL,
    [PeriodInDays] INT           NULL,
    [StartDate]    DATETIME2 (7) NOT NULL,
    [EndDate]      DATETIME2 (7) NULL,
	[Author]       NVARCHAR (50) NOT NULL,
    [CreationTime] DATETIME2 (7) NOT NULL, 
    CONSTRAINT [PK_Limit] PRIMARY KEY ([CustomerId], [LimitTypeId]) 
);

