CREATE TABLE [dbo].[messenger_user_groups] (
    [messenger_user_group_id] INT IDENTITY (1, 1) NOT NULL,
    [user_id]                 INT NOT NULL,
    [messenger_id]            INT NOT NULL,
    PRIMARY KEY CLUSTERED ([messenger_user_group_id] ASC)
);


GO

