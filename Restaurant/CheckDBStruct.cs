using Aramis.DatabaseConnector;
using Aramis.Platform;
using Aramis.Platform.SystemSetup;
using Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatformTest
    {
    class CheckDBStruct : SQLDatabaseUpdating
        {

        private readonly List<string> afterTableCreatedSP = new List<string>
            {
             
                #region Report_GetAllUsersList
            @"CREATE PROCEDURE [dbo].[Report_GetAllUsersList]
(@StartDate as DateTime,
@FinishDate as DateTime)

AS
BEGIN
	SELECT [Id]
      ,[CreationDate]
      ,[LastModified]
      ,[Code]
      ,[DefaultInterface]
      ,[Description]
      ,[Email]
      ,[IsGroup]
      ,[IsPredefined]
      ,[Login]
      ,[MarkForDeleting]
      ,[MobilePhone]
      ,[Password]
      ,[Skin]
      ,[ContainChild]
      ,[Deleted]
      ,[ParentId]
  FROM [AramisPlatform].[dbo].[Users]
END"
            #endregion

            };


        public CheckDBStruct()
            {
            // Additional stored procedure and functions
            AfterTableCreateSP.AddRange(afterTableCreatedSP);
            }
        }
    }
