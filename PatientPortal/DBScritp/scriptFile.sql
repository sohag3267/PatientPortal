USE [PatientPortalDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/23/2024 6:22:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Allergies]    Script Date: 5/23/2024 6:22:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Allergies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Allergy_Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Allergies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Allergy_Details]    Script Date: 5/23/2024 6:22:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Allergy_Details](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PatientId] [int] NOT NULL,
	[AllergyId] [int] NOT NULL,
 CONSTRAINT [PK_Allergy_Details] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DiseaseInformations]    Script Date: 5/23/2024 6:22:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiseaseInformations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DiseaseName] [nvarchar](max) NULL,
 CONSTRAINT [PK_DiseaseInformations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NCD_Details]    Script Date: 5/23/2024 6:22:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NCD_Details](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PatientId] [int] NOT NULL,
	[NCDId] [int] NOT NULL,
 CONSTRAINT [PK_NCD_Details] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NCDs]    Script Date: 5/23/2024 6:22:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NCDs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NCD_Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_NCDs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patients]    Script Date: 5/23/2024 6:22:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PatientName] [nvarchar](max) NOT NULL,
	[DiseaseId] [int] NOT NULL,
	[EpilepsyType] [int] NOT NULL,
 CONSTRAINT [PK_Patients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240519065318_May_19_2024', N'6.0.30')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240519084652_May_19_2024_2', N'6.0.30')
GO
SET IDENTITY_INSERT [dbo].[Allergies] ON 

INSERT [dbo].[Allergies] ([Id], [Allergy_Name]) VALUES (1, N'Al-1')
INSERT [dbo].[Allergies] ([Id], [Allergy_Name]) VALUES (2, N'Al-2')
INSERT [dbo].[Allergies] ([Id], [Allergy_Name]) VALUES (3, N'Al-3')
INSERT [dbo].[Allergies] ([Id], [Allergy_Name]) VALUES (4, N'Al-4')
INSERT [dbo].[Allergies] ([Id], [Allergy_Name]) VALUES (5, N'Al-5')
SET IDENTITY_INSERT [dbo].[Allergies] OFF
GO
SET IDENTITY_INSERT [dbo].[Allergy_Details] ON 

INSERT [dbo].[Allergy_Details] ([Id], [PatientId], [AllergyId]) VALUES (3, 14, 1)
INSERT [dbo].[Allergy_Details] ([Id], [PatientId], [AllergyId]) VALUES (4, 14, 3)
INSERT [dbo].[Allergy_Details] ([Id], [PatientId], [AllergyId]) VALUES (10, 16, 2)
INSERT [dbo].[Allergy_Details] ([Id], [PatientId], [AllergyId]) VALUES (12, 17, 3)
INSERT [dbo].[Allergy_Details] ([Id], [PatientId], [AllergyId]) VALUES (13, 17, 2)
INSERT [dbo].[Allergy_Details] ([Id], [PatientId], [AllergyId]) VALUES (15, 18, 2)
SET IDENTITY_INSERT [dbo].[Allergy_Details] OFF
GO
SET IDENTITY_INSERT [dbo].[DiseaseInformations] ON 

INSERT [dbo].[DiseaseInformations] ([Id], [DiseaseName]) VALUES (1, N'Dis-1')
INSERT [dbo].[DiseaseInformations] ([Id], [DiseaseName]) VALUES (2, N'Dis-2')
INSERT [dbo].[DiseaseInformations] ([Id], [DiseaseName]) VALUES (3, N'Dis-3')
INSERT [dbo].[DiseaseInformations] ([Id], [DiseaseName]) VALUES (4, N'Dis-4')
INSERT [dbo].[DiseaseInformations] ([Id], [DiseaseName]) VALUES (5, N'Dis-5')
INSERT [dbo].[DiseaseInformations] ([Id], [DiseaseName]) VALUES (6, N'Dis-6')
SET IDENTITY_INSERT [dbo].[DiseaseInformations] OFF
GO
SET IDENTITY_INSERT [dbo].[NCD_Details] ON 

INSERT [dbo].[NCD_Details] ([Id], [PatientId], [NCDId]) VALUES (29, 8, 4)
INSERT [dbo].[NCD_Details] ([Id], [PatientId], [NCDId]) VALUES (30, 8, 6)
INSERT [dbo].[NCD_Details] ([Id], [PatientId], [NCDId]) VALUES (31, 9, 1)
INSERT [dbo].[NCD_Details] ([Id], [PatientId], [NCDId]) VALUES (32, 9, 5)
INSERT [dbo].[NCD_Details] ([Id], [PatientId], [NCDId]) VALUES (36, 11, 4)
INSERT [dbo].[NCD_Details] ([Id], [PatientId], [NCDId]) VALUES (37, 11, 5)
INSERT [dbo].[NCD_Details] ([Id], [PatientId], [NCDId]) VALUES (46, 14, 1)
INSERT [dbo].[NCD_Details] ([Id], [PatientId], [NCDId]) VALUES (47, 14, 2)
INSERT [dbo].[NCD_Details] ([Id], [PatientId], [NCDId]) VALUES (54, 16, 2)
INSERT [dbo].[NCD_Details] ([Id], [PatientId], [NCDId]) VALUES (55, 16, 4)
INSERT [dbo].[NCD_Details] ([Id], [PatientId], [NCDId]) VALUES (58, 17, 1)
INSERT [dbo].[NCD_Details] ([Id], [PatientId], [NCDId]) VALUES (59, 17, 4)
INSERT [dbo].[NCD_Details] ([Id], [PatientId], [NCDId]) VALUES (62, 18, 1)
INSERT [dbo].[NCD_Details] ([Id], [PatientId], [NCDId]) VALUES (63, 18, 5)
INSERT [dbo].[NCD_Details] ([Id], [PatientId], [NCDId]) VALUES (64, 19, 2)
INSERT [dbo].[NCD_Details] ([Id], [PatientId], [NCDId]) VALUES (65, 19, 5)
INSERT [dbo].[NCD_Details] ([Id], [PatientId], [NCDId]) VALUES (66, 20, 1)
INSERT [dbo].[NCD_Details] ([Id], [PatientId], [NCDId]) VALUES (67, 22, 2)
SET IDENTITY_INSERT [dbo].[NCD_Details] OFF
GO
SET IDENTITY_INSERT [dbo].[NCDs] ON 

INSERT [dbo].[NCDs] ([Id], [NCD_Name]) VALUES (1, N'NCD-1')
INSERT [dbo].[NCDs] ([Id], [NCD_Name]) VALUES (2, N'NCD-2')
INSERT [dbo].[NCDs] ([Id], [NCD_Name]) VALUES (3, N'NCD-3')
INSERT [dbo].[NCDs] ([Id], [NCD_Name]) VALUES (4, N'NCD-4')
INSERT [dbo].[NCDs] ([Id], [NCD_Name]) VALUES (5, N'NCD-5')
INSERT [dbo].[NCDs] ([Id], [NCD_Name]) VALUES (6, N'NCD-6')
SET IDENTITY_INSERT [dbo].[NCDs] OFF
GO
SET IDENTITY_INSERT [dbo].[Patients] ON 

INSERT [dbo].[Patients] ([Id], [PatientName], [DiseaseId], [EpilepsyType]) VALUES (8, N'Ashraful', 5, 1)
INSERT [dbo].[Patients] ([Id], [PatientName], [DiseaseId], [EpilepsyType]) VALUES (9, N'Kasem', 5, 1)
INSERT [dbo].[Patients] ([Id], [PatientName], [DiseaseId], [EpilepsyType]) VALUES (11, N'Saurov Dash', 2, 1)
INSERT [dbo].[Patients] ([Id], [PatientName], [DiseaseId], [EpilepsyType]) VALUES (13, N'DDDD', 3, 1)
INSERT [dbo].[Patients] ([Id], [PatientName], [DiseaseId], [EpilepsyType]) VALUES (14, N'Test 111', 2, 0)
INSERT [dbo].[Patients] ([Id], [PatientName], [DiseaseId], [EpilepsyType]) VALUES (16, N'Paduka 1111', 4, 1)
INSERT [dbo].[Patients] ([Id], [PatientName], [DiseaseId], [EpilepsyType]) VALUES (17, N'FFFFF vvvv', 4, 1)
INSERT [dbo].[Patients] ([Id], [PatientName], [DiseaseId], [EpilepsyType]) VALUES (18, N'FFFFFF1111', 3, 1)
INSERT [dbo].[Patients] ([Id], [PatientName], [DiseaseId], [EpilepsyType]) VALUES (19, N'TTTTT1111', 1, 0)
INSERT [dbo].[Patients] ([Id], [PatientName], [DiseaseId], [EpilepsyType]) VALUES (20, N'FFFFFF1111', 1, 0)
INSERT [dbo].[Patients] ([Id], [PatientName], [DiseaseId], [EpilepsyType]) VALUES (21, N'DDDDD', 3, 1)
INSERT [dbo].[Patients] ([Id], [PatientName], [DiseaseId], [EpilepsyType]) VALUES (22, N'FFFFFF1111', 1, 0)
SET IDENTITY_INSERT [dbo].[Patients] OFF
GO
ALTER TABLE [dbo].[Patients] ADD  DEFAULT ((0)) FOR [DiseaseId]
GO
ALTER TABLE [dbo].[Patients] ADD  DEFAULT ((0)) FOR [EpilepsyType]
GO
ALTER TABLE [dbo].[Allergy_Details]  WITH CHECK ADD  CONSTRAINT [FK_Allergy_Details_Allergies_AllergyId] FOREIGN KEY([AllergyId])
REFERENCES [dbo].[Allergies] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Allergy_Details] CHECK CONSTRAINT [FK_Allergy_Details_Allergies_AllergyId]
GO
ALTER TABLE [dbo].[Allergy_Details]  WITH CHECK ADD  CONSTRAINT [FK_Allergy_Details_Patients_PatientId] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patients] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Allergy_Details] CHECK CONSTRAINT [FK_Allergy_Details_Patients_PatientId]
GO
ALTER TABLE [dbo].[NCD_Details]  WITH CHECK ADD  CONSTRAINT [FK_NCD_Details_NCDs_NCDId] FOREIGN KEY([NCDId])
REFERENCES [dbo].[NCDs] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NCD_Details] CHECK CONSTRAINT [FK_NCD_Details_NCDs_NCDId]
GO
ALTER TABLE [dbo].[NCD_Details]  WITH CHECK ADD  CONSTRAINT [FK_NCD_Details_Patients_PatientId] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patients] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NCD_Details] CHECK CONSTRAINT [FK_NCD_Details_Patients_PatientId]
GO
