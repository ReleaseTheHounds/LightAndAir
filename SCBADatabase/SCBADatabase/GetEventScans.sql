USE [SCBA]
GO

/****** Object:  StoredProcedure [dbo].[GetEventScans]    Script Date: 3/18/2026 3:16:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Guy Cox
-- Create date: Feb 9, 2026
-- Description:	Gets Scans for an Incident
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[GetEventScans] 
	-- Add the parameters for the stored procedure here
	@EventID int = 0 
	
AS
BEGIN
	

SELECT dbo.Scans.SerialNumber, dbo.Scans.HydrostatDate, dbo.Scans.Pressure, dbo.Scans.Condition, dbo.Jurisdictions.Jurisdiction, dbo.Operators.OperatorName, dbo.Events.Name
FROM   dbo.Events INNER JOIN
         dbo.Scans ON dbo.Events.ID = dbo.Scans.Event INNER JOIN
         dbo.Operators ON dbo.Scans.Operator = dbo.Operators.ID INNER JOIN
         dbo.Jurisdictions ON dbo.Scans.Jurisdiction = dbo.Jurisdictions.ID Where dbo.Events.ID = @EventID
	SET NOCOUNT ON;
END
GO

