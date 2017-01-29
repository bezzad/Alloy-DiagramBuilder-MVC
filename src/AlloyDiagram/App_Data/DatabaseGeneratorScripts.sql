USE [AlloyDiagram]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertDiagramData]    Script Date: 29/01/2017 02:10:47 ب.ظ ******/
DROP PROCEDURE IF EXISTS [dbo].[sp_InsertDiagramData]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Diagrams]') AND type in (N'U'))
ALTER TABLE [dbo].[Diagrams] DROP CONSTRAINT IF EXISTS [DF_Diagram_ModifyDate]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Diagrams]') AND type in (N'U'))
ALTER TABLE [dbo].[Diagrams] DROP CONSTRAINT IF EXISTS [DF_Diagram_IsReadOnly]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Diagrams]') AND type in (N'U'))
ALTER TABLE [dbo].[Diagrams] DROP CONSTRAINT IF EXISTS [DF_Diagram_DiagramId]
GO
/****** Object:  Table [dbo].[Nodes]    Script Date: 29/01/2017 02:10:47 ب.ظ ******/
DROP TABLE IF EXISTS [dbo].[Nodes]
GO
/****** Object:  Table [dbo].[Diagrams]    Script Date: 29/01/2017 02:10:47 ب.ظ ******/
DROP TABLE IF EXISTS [dbo].[Diagrams]
GO
/****** Object:  Table [dbo].[Connectors]    Script Date: 29/01/2017 02:10:47 ب.ظ ******/
DROP TABLE IF EXISTS [dbo].[Connectors]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetAvailableFields]    Script Date: 29/01/2017 02:10:47 ب.ظ ******/
DROP FUNCTION IF EXISTS [dbo].[fn_GetAvailableFields]
GO
/****** Object:  Table [dbo].[Shapes]    Script Date: 29/01/2017 02:10:47 ب.ظ ******/
DROP TABLE IF EXISTS [dbo].[Shapes]
GO
/****** Object:  UserDefinedTableType [dbo].[Node]    Script Date: 29/01/2017 02:10:47 ب.ظ ******/
DROP TYPE IF EXISTS [dbo].[Node]
GO
/****** Object:  UserDefinedTableType [dbo].[Connector]    Script Date: 29/01/2017 02:10:47 ب.ظ ******/
DROP TYPE IF EXISTS [dbo].[Connector]
GO
/****** Object:  User [KHOSRAVIFAR\Administrator]    Script Date: 29/01/2017 02:10:47 ب.ظ ******/
DROP USER IF EXISTS [KHOSRAVIFAR\Administrator]
GO
/****** Object:  User [KHOSRAVIFAR\Behzad]    Script Date: 29/01/2017 02:10:47 ب.ظ ******/
DROP USER IF EXISTS [KHOSRAVIFAR\Behzad]
GO
/****** Object:  User [saleadmin]    Script Date: 29/01/2017 02:10:47 ب.ظ ******/
DROP USER IF EXISTS [saleadmin]
GO
USE [master]
GO
/****** Object:  Database [AlloyDiagram]    Script Date: 29/01/2017 02:10:47 ب.ظ ******/
DROP DATABASE IF EXISTS [AlloyDiagram]
GO
/****** Object:  Database [AlloyDiagram]    Script Date: 29/01/2017 02:10:47 ب.ظ ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'AlloyDiagram')
BEGIN
CREATE DATABASE [AlloyDiagram]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AlloyDiagram', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\AlloyDiagram.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AlloyDiagram_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\AlloyDiagram_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
END

GO
ALTER DATABASE [AlloyDiagram] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AlloyDiagram].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AlloyDiagram] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AlloyDiagram] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AlloyDiagram] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AlloyDiagram] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AlloyDiagram] SET ARITHABORT OFF 
GO
ALTER DATABASE [AlloyDiagram] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AlloyDiagram] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AlloyDiagram] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AlloyDiagram] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AlloyDiagram] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AlloyDiagram] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AlloyDiagram] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AlloyDiagram] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AlloyDiagram] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AlloyDiagram] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AlloyDiagram] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AlloyDiagram] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AlloyDiagram] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AlloyDiagram] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AlloyDiagram] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AlloyDiagram] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AlloyDiagram] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AlloyDiagram] SET RECOVERY FULL 
GO
ALTER DATABASE [AlloyDiagram] SET  MULTI_USER 
GO
ALTER DATABASE [AlloyDiagram] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AlloyDiagram] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AlloyDiagram] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AlloyDiagram] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [AlloyDiagram] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'AlloyDiagram', N'ON'
GO
ALTER DATABASE [AlloyDiagram] SET QUERY_STORE = OFF
GO
USE [AlloyDiagram]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [AlloyDiagram]
GO
/****** Object:  User [saleadmin]    Script Date: 29/01/2017 02:10:47 ب.ظ ******/
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'saleadmin')
CREATE USER [saleadmin] FOR LOGIN [saleadmin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [KHOSRAVIFAR\Behzad]    Script Date: 29/01/2017 02:10:47 ب.ظ ******/
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'KHOSRAVIFAR\Behzad')
CREATE USER [KHOSRAVIFAR\Behzad] FOR LOGIN [KHOSRAVIFAR\Behzad] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [KHOSRAVIFAR\Administrator]    Script Date: 29/01/2017 02:10:47 ب.ظ ******/
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'KHOSRAVIFAR\Administrator')
CREATE USER [KHOSRAVIFAR\Administrator] FOR LOGIN [KHOSRAVIFAR\Administrator] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [saleadmin]
GO
ALTER ROLE [db_owner] ADD MEMBER [KHOSRAVIFAR\Behzad]
GO
ALTER ROLE [db_owner] ADD MEMBER [KHOSRAVIFAR\Administrator]
GO
/****** Object:  UserDefinedTableType [dbo].[Connector]    Script Date: 29/01/2017 02:10:47 ب.ظ ******/
IF NOT EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'Connector' AND ss.name = N'dbo')
CREATE TYPE [dbo].[Connector] AS TABLE(
	[Name] [nvarchar](200) NOT NULL,
	[SourceId] [uniqueidentifier] NULL,
	[TargetId] [uniqueidentifier] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[Node]    Script Date: 29/01/2017 02:10:47 ب.ظ ******/
IF NOT EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'Node' AND ss.name = N'dbo')
CREATE TYPE [dbo].[Node] AS TABLE(
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[X] [numeric](10, 2) NOT NULL,
	[Y] [numeric](10, 2) NOT NULL,
	[Type] [int] NOT NULL,
	[Description] [nvarchar](500) NULL,
	[ZIndex] [int] NULL,
	[Width] [int] NULL,
	[Height] [int] NULL,
	PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[Shapes]    Script Date: 29/01/2017 02:10:47 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Shapes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Shapes](
	[ShapeId] [int] NOT NULL,
	[IconClass] [nvarchar](100) NULL,
	[Label] [nvarchar](50) NULL,
 CONSTRAINT [PK_FieldTypes] PRIMARY KEY CLUSTERED 
(
	[ShapeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetAvailableFields]    Script Date: 29/01/2017 02:10:47 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetAvailableFields]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Behzad
-- Create date: 1395/11/06
-- Description:	Get avaiable fields
-- =============================================
CREATE FUNCTION [dbo].[fn_GetAvailableFields] ( @UserId INT )
RETURNS TABLE
AS
RETURN
    ( SELECT    s.ShapeId AS [type],
                s.IconClass ,
                s.Label
      FROM      dbo.Shapes s
    );
' 
END

GO
/****** Object:  Table [dbo].[Connectors]    Script Date: 29/01/2017 02:10:47 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Connectors]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Connectors](
	[ConnectId] [int] IDENTITY(1,1) NOT NULL,
	[DiagramId] [uniqueidentifier] NOT NULL,
	[SourceId] [uniqueidentifier] NOT NULL,
	[TargetId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Connectors] PRIMARY KEY CLUSTERED 
(
	[ConnectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Diagrams]    Script Date: 29/01/2017 02:10:47 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Diagrams]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Diagrams](
	[DiagramId] [uniqueidentifier] NOT NULL,
	[DiagramName] [nvarchar](200) NULL,
	[IsReadOnly] [bit] NOT NULL,
	[ModifyDate] [datetime] NOT NULL,
	[CreatorUserId] [int] NULL,
 CONSTRAINT [PK_Diagram] PRIMARY KEY CLUSTERED 
(
	[DiagramId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Nodes]    Script Date: 29/01/2017 02:10:47 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Nodes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Nodes](
	[DiagramId] [uniqueidentifier] NOT NULL,
	[NodeId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[X] [numeric](10, 2) NOT NULL,
	[Y] [numeric](10, 2) NOT NULL,
	[Type] [int] NOT NULL,
	[Description] [nvarchar](500) NULL,
	[ZIndex] [int] NULL,
	[Width] [int] NULL,
	[Height] [int] NULL,
 CONSTRAINT [PK_Nodes] PRIMARY KEY CLUSTERED 
(
	[DiagramId] ASC,
	[NodeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Diagram_DiagramId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Diagrams] ADD  CONSTRAINT [DF_Diagram_DiagramId]  DEFAULT (newid()) FOR [DiagramId]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Diagram_IsReadOnly]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Diagrams] ADD  CONSTRAINT [DF_Diagram_IsReadOnly]  DEFAULT ((0)) FOR [IsReadOnly]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Diagram_ModifyDate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Diagrams] ADD  CONSTRAINT [DF_Diagram_ModifyDate]  DEFAULT (getdate()) FOR [ModifyDate]
END

GO
/****** Object:  StoredProcedure [dbo].[sp_InsertDiagramData]    Script Date: 29/01/2017 02:10:47 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_InsertDiagramData]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_InsertDiagramData] AS' 
END
GO
-- =============================================
-- Author:		Behzad
-- Create date: 1395/11/6
-- Description:	Fill Alloy tables by input data
-- =============================================
ALTER PROCEDURE [dbo].[sp_InsertDiagramData]
    @DiagramId UNIQUEIDENTIFIER = NULL ,
    @DiagramName NVARCHAR(200) ,
    @IsReadOnly BIT = 0 ,
    @CreatorUserId INT ,
    @Nodes Node READONLY ,
    @Transitions Connector READONLY
AS
    BEGIN TRY
        BEGIN TRANSACTION;

			-- Clear old data
        DELETE  FROM dbo.Connectors
        WHERE   DiagramId = @DiagramId;
        DELETE  FROM dbo.Nodes
        WHERE   DiagramId = @DiagramId;
        DELETE  FROM dbo.Diagrams
        WHERE   DiagramId = @DiagramId;

            

		/******************************* Make just diagram **************************/
        INSERT  INTO dbo.Diagrams
                ( DiagramId ,
                  DiagramName ,
                  IsReadOnly ,
                  ModifyDate ,
                  CreatorUserId
		        )
        VALUES  ( @DiagramId ,
                  @DiagramName , -- DiagramName - nvarchar(200)
                  @IsReadOnly , -- IsReadOnly - bit
                  GETDATE() , -- ModifyDate - datetime
                  @CreatorUserId  -- CreatorUserId - int
		        ); 

		/*****************************************************************************/





		/****************** Insert nodes by existing diagram id ****************/
        INSERT  INTO dbo.Nodes
                ( DiagramId ,
                  NodeId ,
                  [Name] ,
                  X ,
                  Y ,
                  [Type] ,
                  [Description] ,
                  ZIndex ,
                  Width ,
                  Height
		        )
                SELECT  @DiagramId ,
                        Id ,
                        [Name] ,
                        X ,
                        Y ,
                        [Type] ,
                        [Description] ,
                        ZIndex ,
                        Width ,
                        Height
                FROM    @Nodes n;
		/***********************************************************************/



		/****************** Insert nodes by existing diagram id ****************/
        INSERT  INTO dbo.Connectors
                ( DiagramId ,
                  SourceId ,
                  TargetId ,
                  [Name]
                )
                SELECT  @DiagramId ,
                        SourceId ,
                        TargetId ,
                        [Name]
                FROM    @Transitions;
		/***********************************************************************/

		SELECT * FROM dbo.Diagrams WHERE DiagramId = @DiagramId

        COMMIT TRANSACTION;       
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;

        THROW;
    END CATCH;

GO
USE [master]
GO
ALTER DATABASE [AlloyDiagram] SET  READ_WRITE 
GO
