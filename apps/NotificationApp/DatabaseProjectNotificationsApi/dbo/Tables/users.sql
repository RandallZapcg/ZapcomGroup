CREATE TABLE [dbo].[users] (
    [user_id]    INT           IDENTITY (1, 1) NOT NULL,
    [first_name] NVARCHAR (50) NOT NULL,
    [last_name]  NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([user_id] ASC)
);


GO

