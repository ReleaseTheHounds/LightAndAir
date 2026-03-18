USE [SCBA]
GO

/****** Object:  StoredProcedure [dbo].[MarkCompressorState]    Script Date: 3/18/2026 3:19:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Guy Cox
-- Create date: 3/18/2026
-- Description:	Marks an operator active 1 /inactive 0
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[MarkCompressorState] 
	-- Add the parameters for the stored procedure here
	@CompressorID int = 0, 
	@State bit = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE dbo.Compressor
	Set Compressor.isActive = @State where Compressor.ID = @CompressorID

	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR('No Compressor was found with that ID',16,1)
	END

END
GO

