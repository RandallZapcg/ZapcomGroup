CREATE TABLE [dbo].[messengers] (
    [messenger_id] INT           IDENTITY (1, 1) NOT NULL,
    [name]         NVARCHAR (50) NOT NULL,
    [created_date] DATE          NULL,
    PRIMARY KEY CLUSTERED ([messenger_id] ASC)
);


GO

