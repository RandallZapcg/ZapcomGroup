CREATE TABLE [dbo].[message_recipients] (
    [message_recipients_id]   INT           IDENTITY (1, 1) NOT NULL,
    [recipient_id]            NVARCHAR (50) NOT NULL,
    [messenger_user_group_id] NVARCHAR (50) NOT NULL,
    [message_id]              NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([message_recipients_id] ASC)
);


GO

