USE [SCBA]
GO

/****** Object:  StoredProcedure [dbo].[GetUnprocessedEvents]    Script Date: 3/18/2026 3:17:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Guy Cox
-- Create date: 11 Feb 2026
-- Description:	Gets unprocessed events
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[GetUnprocessedEvents] 
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT dbo.Events.ID, dbo.Events.Name, dbo.Events.EventDate from dbo.Events where dbo.Events.ExcelFileName is null order by dbo.Events.EventDate asc

END
GO

