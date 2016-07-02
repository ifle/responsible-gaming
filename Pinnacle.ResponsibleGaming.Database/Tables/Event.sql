CREATE TABLE [dbo].[Event] (
    [EventId] UNIQUEIDENTIFIER NOT NULL,
    [Name] NVARCHAR(50) NOT NULL,
    [Json] NVARCHAR (1000) NOT NULL,
    [Sent] BIT             NOT NULL
);

