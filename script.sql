
USE [Scada]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 1/22/2017 11:18:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Meter]    Script Date: 1/22/2017 11:18:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meter](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Location_ID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MeterRead]    Script Date: 1/22/2017 11:18:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MeterRead](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Meter_ID] [int] NOT NULL,
	[Type] [int] NOT NULL,
	[Value] [float] NOT NULL,
	[Timestamp] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Meter]  WITH CHECK ADD FOREIGN KEY([Location_ID])
REFERENCES [dbo].[Location] ([id])
GO
ALTER TABLE [dbo].[MeterRead]  WITH CHECK ADD FOREIGN KEY([Meter_ID])
REFERENCES [dbo].[Meter] ([id])
GO
ALTER TABLE [dbo].[MeterRead]  WITH CHECK ADD FOREIGN KEY([Meter_ID])
REFERENCES [dbo].[Meter] ([id])
GO
INSERT [dbo].[Location] ([id], [Name]) VALUES (1, N'Liman')
INSERT [dbo].[Location] ([id], [Name]) VALUES (2, N'Grbavica')
INSERT [dbo].[Location] ([id], [Name]) VALUES (3, N'Klisa')
INSERT [dbo].[Location] ([id], [Name]) VALUES (5, N'Telep')
INSERT [dbo].[Location] ([id], [Name]) VALUES (6, N'Centar')

USE [master]
GO
ALTER DATABASE [Scada] SET  READ_WRITE 
GO


