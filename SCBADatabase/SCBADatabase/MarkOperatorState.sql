USE [SCBA]
GO

/****** Object:  StoredProcedure [dbo].[MarkOperatorState]    Script Date: 3/18/2026 3:16:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Guy Cox
-- Create date: 3/18/2026
-- Description:	Marks an operator active 1 /inactive 0
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[MarkOperatorState] 
	-- Add the parameters for the stored procedure here
	@OperatorID int = 0, 
	@State bit = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE dbo.Operators
	Set Operators.isActive = @State where Operators.ID = @OperatorID

	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR('No Operator was found with that ID',16,1)
	END

END
GO

