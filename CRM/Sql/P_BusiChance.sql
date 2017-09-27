USE [test]
GO

/****** Object:  StoredProcedure [dbo].[P_BusiChance]    Script Date: 2017/9/27 14:26:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[P_BusiChance] 
    @bcType nvarchar(50)='insert',
	@bcId int =null,
	@bcfkspId int =null,
	@bcName nvarchar(50)=null
    
AS
BEGIN
     if @bcType='insert'
	 begin
     insert into BusiChance values(@bcfkspId,null)
	 end
END

GO


