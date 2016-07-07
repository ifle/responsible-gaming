CREATE TABLE [dbo].[Limit] (
    [LimitId] INT NOT NULL IDENTITY, 
    [CustomerId]   NVARCHAR (50) NOT NULL,
    [LimitTypeId]  INT           NOT NULL,
    [Limit]        DECIMAL(18, 2)           NOT NULL,
    [PeriodInDays] INT           NULL,
    [StartDate]    DATETIME2 (7) NOT NULL,
    [EndDate]      DATETIME2 (7) NULL,
	[Author]       NVARCHAR (50) NOT NULL,
    [ModificationTime] DATETIME2 (7) NOT NULL, 
    CONSTRAINT [PK_Limit] PRIMARY KEY CLUSTERED ([LimitId]) 
);


GO


CREATE INDEX [IX_Limit_CustomerId_LimitTypeId] ON [dbo].[Limit] ([CustomerId] ASC, [LimitTypeId] ASC)
