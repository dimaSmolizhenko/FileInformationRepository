CREATE TYPE FileInfoIndexStartAnaLength AS TABLE
    ( 
        IndexBegin NVARCHAR(100),
		IndexLength INT
    )
GO

/* Create Stored Procedure */
CREATE PROCEDURE dbo.GetFilesByDirectories
  @List AS dbo.FileInfoIndexStartAnaLength READONLY
AS
BEGIN
  SET NOCOUNT ON;
 
  SELECT DISTINCT [Index] FROM dbo.FileInfo as f 
  INNER JOIN @List as l 
  ON f.[Index] like l.IndexBegin + '%' AND LEN(f.[Index]) = l.IndexLength
END
GO