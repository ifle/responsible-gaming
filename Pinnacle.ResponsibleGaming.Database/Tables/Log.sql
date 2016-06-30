CREATE TABLE [dbo].[Log] (
    [Action]	   NVARCHAR (50) NOT NULL,
    [CustomerId]   NVARCHAR (10) NOT NULL,
    [Limit]        DECIMAL(18, 2)           NOT NULL,
    [PeriodInDays] INT           NULL,
    [StartDate]    DATETIME2 (7) NOT NULL,
    [EndDate]      DATETIME2 (7) NULL,
    [Author]       NVARCHAR (10) NOT NULL,
    [CreationTime] DATETIME2 (7) NOT NULL,
);

GO

CREATE INDEX [IX_Log_CustomerId] ON [dbo].[Log] ([CustomerId])

GO

CREATE INDEX [IX_Log_Author] ON [dbo].[Log] ([Author])
