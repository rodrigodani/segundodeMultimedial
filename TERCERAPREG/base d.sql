USE [MapasyTex]
GO
/****** Object:  Table [dbo].[capa]    Script Date: 05/12/2021 18:07:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[capa](
	[cod] [int] IDENTITY(1,1) NOT NULL,
	[color] [nvarchar](max) NOT NULL,
	[codfoto] [int] NOT NULL,
	[nombre] [nvarchar](300) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fotos]    Script Date: 05/12/2021 18:07:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fotos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[url] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_fotos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[puntos]    Script Date: 05/12/2021 18:07:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[puntos](
	[codPun] [int] IDENTITY(1,1) NOT NULL,
	[punts] [nvarchar](max) NOT NULL,
	[codCapa] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[codPun] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[capa]  WITH CHECK ADD FOREIGN KEY([codfoto])
REFERENCES [dbo].[fotos] ([id])
GO
ALTER TABLE [dbo].[puntos]  WITH CHECK ADD  CONSTRAINT [FK__puntos__codCapa__1B0907CE] FOREIGN KEY([codCapa])
REFERENCES [dbo].[capa] ([cod])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[puntos] CHECK CONSTRAINT [FK__puntos__codCapa__1B0907CE]
GO
