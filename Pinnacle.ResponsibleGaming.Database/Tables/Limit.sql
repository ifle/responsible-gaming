CREATE TABLE [dbo].[Limit] (
    [LimitTypeId]  INT           NOT NULL,
    [CustomerId]   NVARCHAR (10) NOT NULL,
    [Limit]        DECIMAL(18, 2)           NOT NULL,
    [PeriodInDays] INT           NULL,
    [StartDate]    DATETIME2 (7) NOT NULL,
    [EndDate]      DATETIME2 (7) NULL,
	[Author]       NVARCHAR (10) NOT NULL,
    [CreationTime] DATETIME2 (7) NOT NULL,
    CONSTRAINT [PK_Limit] PRIMARY KEY CLUSTERED ([LimitTypeId] ASC, [CustomerId] ASC),
    CONSTRAINT [FK_Limit_LimitType] FOREIGN KEY ([LimitTypeId]) REFERENCES [dbo].[LimitType] ([LimitTypeId])
);

