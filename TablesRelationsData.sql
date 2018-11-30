USE [DB_TestTekus]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 30/11/2018 11:42:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nit] [varchar](20) NULL,
	[Nombre] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paises]    Script Date: 30/11/2018 11:42:25 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paises](
	[Nombre] [varchar](255) NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaisesPorServicio]    Script Date: 30/11/2018 11:42:25 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaisesPorServicio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPais] [int] NULL,
	[IdServicio] [int] NULL,
 CONSTRAINT [PK_Paises] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servicios]    Script Date: 30/11/2018 11:42:25 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](255) NULL,
	[ValorHora] [decimal](18, 2) NULL,
	[IdCliente] [int] NULL,
 CONSTRAINT [PK_Servicios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 
GO
INSERT [dbo].[Clientes] ([Id], [Nit], [Nombre], [Email]) VALUES (1, N'852369741', N'Arus', N'tramite@arus.com.co')
GO
INSERT [dbo].[Clientes] ([Id], [Nit], [Nombre], [Email]) VALUES (2, N'741254786', N'EO', N'clienteservicio@eo.com.co')
GO
INSERT [dbo].[Clientes] ([Id], [Nit], [Nombre], [Email]) VALUES (3, N'800424718', N'Compuredes S.A', N'clientservice@compuredes.com.co')
GO
INSERT [dbo].[Clientes] ([Id], [Nit], [Nombre], [Email]) VALUES (4, N'800254698', N'PSL', N'client@psl.com.co')
GO
INSERT [dbo].[Clientes] ([Id], [Nit], [Nombre], [Email]) VALUES (5, N'87954213613', N'Copelia S.A', N'serviciocopelia@copelia.com')
GO
INSERT [dbo].[Clientes] ([Id], [Nit], [Nombre], [Email]) VALUES (6, N'8002564712', N'Globant SAS', N'servicecglobant@globant.com.co')
GO
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[Paises] ON 
GO
INSERT [dbo].[Paises] ([Nombre], [Id]) VALUES (N'Colombia', 1)
GO
INSERT [dbo].[Paises] ([Nombre], [Id]) VALUES (N'Ecuador', 2)
GO
INSERT [dbo].[Paises] ([Nombre], [Id]) VALUES (N'Perú', 3)
GO
INSERT [dbo].[Paises] ([Nombre], [Id]) VALUES (N'Chile', 4)
GO
INSERT [dbo].[Paises] ([Nombre], [Id]) VALUES (N'Brasil', 5)
GO
SET IDENTITY_INSERT [dbo].[Paises] OFF
GO
SET IDENTITY_INSERT [dbo].[PaisesPorServicio] ON 
GO
INSERT [dbo].[PaisesPorServicio] ([Id], [IdPais], [IdServicio]) VALUES (1, 1, 1)
GO
INSERT [dbo].[PaisesPorServicio] ([Id], [IdPais], [IdServicio]) VALUES (2, 2, 1)
GO
INSERT [dbo].[PaisesPorServicio] ([Id], [IdPais], [IdServicio]) VALUES (3, 1, 2)
GO
INSERT [dbo].[PaisesPorServicio] ([Id], [IdPais], [IdServicio]) VALUES (4, 2, 2)
GO
INSERT [dbo].[PaisesPorServicio] ([Id], [IdPais], [IdServicio]) VALUES (5, 3, 2)
GO
INSERT [dbo].[PaisesPorServicio] ([Id], [IdPais], [IdServicio]) VALUES (6, 1, 3)
GO
INSERT [dbo].[PaisesPorServicio] ([Id], [IdPais], [IdServicio]) VALUES (7, 2, 3)
GO
INSERT [dbo].[PaisesPorServicio] ([Id], [IdPais], [IdServicio]) VALUES (8, 3, 3)
GO
INSERT [dbo].[PaisesPorServicio] ([Id], [IdPais], [IdServicio]) VALUES (9, 1, 4)
GO
INSERT [dbo].[PaisesPorServicio] ([Id], [IdPais], [IdServicio]) VALUES (10, 1, 5)
GO
INSERT [dbo].[PaisesPorServicio] ([Id], [IdPais], [IdServicio]) VALUES (11, 1, 6)
GO
INSERT [dbo].[PaisesPorServicio] ([Id], [IdPais], [IdServicio]) VALUES (13, 5, 7)
GO
SET IDENTITY_INSERT [dbo].[PaisesPorServicio] OFF
GO
SET IDENTITY_INSERT [dbo].[Servicios] ON 
GO
INSERT [dbo].[Servicios] ([Id], [Nombre], [ValorHora], [IdCliente]) VALUES (1, N'Impresión', CAST(4.00 AS Decimal(18, 2)), 1)
GO
INSERT [dbo].[Servicios] ([Id], [Nombre], [ValorHora], [IdCliente]) VALUES (2, N'Telefonía', CAST(5.00 AS Decimal(18, 2)), 1)
GO
INSERT [dbo].[Servicios] ([Id], [Nombre], [ValorHora], [IdCliente]) VALUES (3, N'Impresión', CAST(3.50 AS Decimal(18, 2)), 2)
GO
INSERT [dbo].[Servicios] ([Id], [Nombre], [ValorHora], [IdCliente]) VALUES (4, N'Telefonía', CAST(4.50 AS Decimal(18, 2)), 2)
GO
INSERT [dbo].[Servicios] ([Id], [Nombre], [ValorHora], [IdCliente]) VALUES (5, N'BPO', CAST(4.60 AS Decimal(18, 2)), 2)
GO
INSERT [dbo].[Servicios] ([Id], [Nombre], [ValorHora], [IdCliente]) VALUES (6, N'ITO', CAST(6.50 AS Decimal(18, 2)), 2)
GO
INSERT [dbo].[Servicios] ([Id], [Nombre], [ValorHora], [IdCliente]) VALUES (7, N'Leasing PC', CAST(1.50 AS Decimal(18, 2)), 1)
GO
INSERT [dbo].[Servicios] ([Id], [Nombre], [ValorHora], [IdCliente]) VALUES (8, N'Digitalización', CAST(1.30 AS Decimal(18, 2)), 6)
GO
SET IDENTITY_INSERT [dbo].[Servicios] OFF
GO
ALTER TABLE [dbo].[PaisesPorServicio]  WITH CHECK ADD FOREIGN KEY([IdPais])
REFERENCES [dbo].[Paises] ([Id])
GO
ALTER TABLE [dbo].[PaisesPorServicio]  WITH CHECK ADD FOREIGN KEY([IdServicio])
REFERENCES [dbo].[Servicios] ([Id])
GO
ALTER TABLE [dbo].[Servicios]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([Id])
GO
