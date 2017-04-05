/*
Navicat SQL Server Data Transfer

Source Server         : vmmssql
Source Server Version : 100000
Source Host           : 192.168.56.131:1433
Source Database       : yizhan
Source Schema         : dbo

Target Server Type    : SQL Server
Target Server Version : 100000
File Encoding         : 65001

Date: 2017-04-05 23:53:15
*/


-- ----------------------------
-- Table structure for Act
-- ----------------------------
DROP TABLE [dbo].[Act]
GO
CREATE TABLE [dbo].[Act] (
[Id] int NOT NULL IDENTITY(1,1) ,
[Name] nvarchar(50) NOT NULL ,
[OrderIndex] int NOT NULL ,
[PhotoUrl] varchar(200) NOT NULL ,
[Enable] bit NOT NULL ,
[Depth] int NOT NULL ,
[ParentFid] int NOT NULL ,
[RootFid] int NOT NULL 
)


GO

-- ----------------------------
-- Records of Act
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Act] ON
GO
INSERT INTO [dbo].[Act] ([Id], [Name], [OrderIndex], [PhotoUrl], [Enable], [Depth], [ParentFid], [RootFid]) VALUES (N'1', N'测试活动', N'1', N'dd', N'1', N'1', N'0', N'1')
GO
GO
SET IDENTITY_INSERT [dbo].[Act] OFF
GO

-- ----------------------------
-- Indexes structure for table Act
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Act
-- ----------------------------
ALTER TABLE [dbo].[Act] ADD PRIMARY KEY ([Id])
GO
