CREATE TABLE [dbo].[Document] (
    [AggregateId]  NVARCHAR(50)           NOT NULL,
    [Json]   NVARCHAR (MAX) NOT NULL, 
    CONSTRAINT [PK_Document] PRIMARY KEY ([AggregateId])
);

