CREATE PROCEDURE dbo.GetMessengerMessages
    @messenger_id int
AS
    SELECT 
    message_recipients_id,
    recipient_id,
    mug.messenger_user_group_id AS group_id,
    message_id,
    u.first_name,
    u.last_name,
    msgr.messenger_id AS channel_id,
    msgr.name AS channel
FROM message_recipients mr
JOIN messenger_user_groups mug
    ON (mr.messenger_user_group_id = mug.messenger_user_group_id)
JOIN users u
    ON (mr.recipient_id = u.user_id)
JOIN messengers msgr
    ON (mug.messenger_id = msgr.messenger_id)
    WHERE (mug.messenger_id = @messenger_id)

GO

