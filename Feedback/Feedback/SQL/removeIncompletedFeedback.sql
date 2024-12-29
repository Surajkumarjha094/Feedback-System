USE Feedback
IF EXISTS (SELECT name FROM sysobjects
        WHERE name = 'removeIncompletedFeedback' AND type = 'TR')
    DROP TRIGGER removeIncompletedFeedback
GO
CREATE TRIGGER removeIncompletedFeedback 
ON IncompletedFeedback
FOR delete AS
DECLARE
	@i1 int;
BEGIN
	
	SELECT    @i1=del.Incompleted_ID FROM deleted del;
	--delete from FeedbackStatus where Incompleted_ID = @i1;
	
END

