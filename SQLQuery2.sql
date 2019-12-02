USE [UPSINextGenStaging]
GO

SET NOCOUNT ON

DECLARE	@return_value Int

EXEC	@return_value = [meta].[GetMetaSourceDataByTableAndField]
		@tablename = N'nameplat',
		@fieldname = N'manufactur'

--SELECT	@return_value as 'Return Value'

GO
