CREATE TABLE [dbo].[messages] (
    [message_id]        INT            IDENTITY (1, 1) NOT NULL,
    [body]              NVARCHAR (255) NOT NULL,
    [is_active]         NVARCHAR (50)  NOT NULL,
    [parent_message_id] NVARCHAR (50)  NOT NULL,
    [user_id]           NVARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([message_id] ASC)
);


GO

