USE [FileInfoDb]
GO

CREATE TYPE [dbo].[InpuFileInfo] AS TABLE(
	[Id] [uniqueidentifier] NULL,
	[Name] [nvarchar](max) NULL,
	[Index] [nvarchar](400) NULL,
	[Size] [int] NULL,
	[Category] [nvarchar](max) NULL
)
GO

CREATE PROCEDURE [dbo].[SetFileInfoData]
  @List AS dbo.InpuFileInfo READONLY
AS
BEGIN
  SET NOCOUNT ON;

  INSERT INTO dbo.FileInfo SELECT * FROM @List 

  SELECT * FROM dbo.FileInfo
END

/**

	DECLARE @files as dbo.InpuFileInfo

	INSERT @files
		VALUES (NEWID(), '1', '1', 1, '1'),
			(NEWID(), '2', '1.1', 1, '1'),
			(NEWID(), '3', '1.1.1', 1, '1'),
			(NEWID(), '4', '1.2', 1, '1')

	DECLARE	@return_value int

	EXEC	@return_value = [dbo].[SetFileInfoData]
			@List = NULL

	SELECT	'Return Value' = @return_value
**/
GO


