CREATE TABLE [dbo].[Log] (
    [Action]       NVARCHAR (20) NULL,
    [CustomerId]   NVARCHAR (10) NOT NULL,
    [Limit]        INT           NULL,
    [PeriodInDays] INT           NULL,
    [StartDate]    DATETIME2 (7) NULL,
    [EndDate]      DATETIME2 (7) NULL,
    [Author]       NVARCHAR (10) NOT NULL,
    [CreationTime] DATETIME2 (7) NOT NULL
);

