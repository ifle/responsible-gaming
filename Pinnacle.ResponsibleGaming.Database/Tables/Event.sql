CREATE TABLE [dbo].[Event] (
    [EventId] INT NOT NULL IDENTITY,
    [Name] NVARCHAR(50) NOT NULL,
    [Json] NVARCHAR (1000) NOT NULL,
    [Sent] BIT             NOT NULL, 
    CONSTRAINT [PK_Event] PRIMARY KEY ([EventId])
);

