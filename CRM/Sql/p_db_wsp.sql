USE [test]
GO

/****** Object:  StoredProcedure [dbo].[p_db_wsp]    Script Date: 2017/9/27 14:27:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

   
CREATE PROC [dbo].[p_db_wsp]
    @dbname VARCHAR(50) ,   --���ݿ���  
    @path VARCHAR(100) ,    --ʵ��������Ŀ¼������D:/My/Models  
    @namespace VARCHAR(50) --ʵ���������ռ�,Ĭ��ֵΪModels  
AS --�ж����ݿ��Ƿ����  
    IF ( DB_ID(@dbname) IS NOT NULL )
        BEGIN  
            IF ( ISNULL(@namespace, '') = '' )
                SET @namespace = 'Models';  
-- �������ø߼�ѡ��  
            EXEC sp_configure 'show advanced options', 1;  
-- ��������  
            RECONFIGURE;  
-- ����Ole Automation Procedures   
            EXEC sp_configure 'Ole Automation Procedures', 1;  
-- ����xp_cmdshell,�����������д���ļ�  
            EXEC sp_configure 'xp_cmdshell', 1;  
-- ��������  
            RECONFIGURE;  
            DECLARE @dbsql VARCHAR(1000) ,
                @tablename VARCHAR(100);  
            SET @dbsql = 'declare wsp cursor for select name from ' + @dbname
                + '..sysobjects where xtype=''u''  and name <>''sysdiagrams''';  
            EXEC(@dbsql);  
            OPEN wsp;  
            FETCH wsp INTO @tablename;--ʹ���α�ѭ���������ݿ���ÿ����  
            WHILE ( @@fetch_status = 0 )
                BEGIN  
--���ݱ����ֶ����ʵ�����е��ֶκ�����  
                    DECLARE @nsql NVARCHAR(4000) ,
                        @sql VARCHAR(8000);  
                    SET @nsql = 'select @s=isnull(@s+char(9),''using System;'
                        + CHAR(13) + 'using System.Collections.Generic;'
                        + CHAR(13) + 'using System.Text;' + CHAR(13)
                        + 'namespace ' + @namespace + CHAR(13) + '{' + CHAR(13)
                        + CHAR(9) + 'public class ' + @tablename + CHAR(13)
                        + '{''+char(13)+char(9))+  char(13)+char(9)+''public ''+  
case when a.name in(''image'',''uniqueidentifier'',''ntext'',''varchar'',''ntext'',''nchar'',''nvarchar'',''text'',''char'') then ''string''  
when a.name in(''tinyint'',''smallint'',''int'') then ''int?''  
when a.name=''bigint'' then ''long''  
when a.name in(''datetime'',''smalldatetime'') then ''DateTime?''  
when a.name in(''float'',''decimal'',''numeric'',''money'',''real'',''smallmoney'') then ''decimal''  
when a.name =''bit'' then ''bool''  
else a.name end  
+'' ''+b.name+'' ''+''{get;set;}''+char(13)  
from ' + @dbname + '..syscolumns b,  
(select distinct name,xtype from ' + @dbname + '..systypes where status=0) a  
where a.xtype=b.xtype and b.id=object_id(''' + @dbname + '..' + @tablename
                        + ''')';  
                    EXEC sp_executesql @nsql, N'@s varchar(8000) output',
                        @sql OUTPUT;  
                    SET @sql = @sql + CHAR(9) + '}' + CHAR(13) + '}';  
--print @sql  
                    DECLARE @err INT ,
                        @fso INT ,
                        @fleExists BIT ,
                        @file VARCHAR(100);  
                    SET @file = @path + '/' + @tablename + '.cs';  
                    EXEC @err= sp_OACreate 'Scripting.FileSystemObject',
                        @fso OUTPUT;  
                    EXEC @err= sp_OAMethod @fso, 'FileExists',
                        @fleExists OUTPUT, @file;  
                    EXEC @err = sp_OADestroy @fso;  
   
                    IF @fleExists != 0
                        EXEC('exec xp_cmdshell ''del '+@file+''''); --������ɾ��  
                    EXEC('exec xp_cmdshell ''echo '+@sql+' > '+@file+''''); --���ı�д���ļ���  
                    SET @sql = NULL;  
                    FETCH wsp INTO @tablename;  
                END;  
            CLOSE wsp;  
            DEALLOCATE wsp;  
            PRINT '���ɳɹ���';  
        END;  
    ELSE
        PRINT '���ݿⲻ���ڣ�';
GO


