using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace VetClinika.DBConnection
{
    internal class bdscript
    {
    }


//    USE[Clinika]
//GO
///****** Object:  Table [dbo].[Gender]    Script Date: 19.04.2025 13:15:54 ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//CREATE TABLE[dbo].[Gender]
//    (

//    [id][int] IDENTITY(1,1) NOT NULL,

//    [name] [nvarchar] (50) NULL,
// CONSTRAINT[PK_Gender] PRIMARY KEY CLUSTERED
//(
//    [id] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
//) ON[PRIMARY]
//GO
///****** Object:  Table [dbo].[Pet]    Script Date: 19.04.2025 13:15:54 ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//CREATE TABLE[dbo].[Pet]
//    (

//    [idPet][int] IDENTITY(1,1) NOT NULL,

//    [namePet] [nvarchar] (50) NULL,
//	[idGender][int] NULL,
//	[idType][int] NULL,
//	[Weight][int] NULL,
//	[Height][int] NULL,
// CONSTRAINT[PK_Pet] PRIMARY KEY CLUSTERED
//(
//    [idPet] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
//) ON[PRIMARY]
//GO
///****** Object:  Table [dbo].[Priem]    Script Date: 19.04.2025 13:15:54 ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//CREATE TABLE[dbo].[Priem]
//    (

//    [idPriem][int] IDENTITY(1,1) NOT NULL,

//    [idPet] [int] NULL,
//	[idVrach][int] NULL,
//	[DataPriem][date] NULL,
//	[Comment][nvarchar] (50) NULL,
//	[isDelete][bit] NULL,
// CONSTRAINT[PK_Priem] PRIMARY KEY CLUSTERED
//(
//    [idPriem] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
//) ON[PRIMARY]
//GO
///****** Object:  Table [dbo].[Type_Pet]    Script Date: 19.04.2025 13:15:54 ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//CREATE TABLE[dbo].[Type_Pet]
//    (

//    [id][int] IDENTITY(1,1) NOT NULL,

//    [name] [nvarchar] (50) NULL,
// CONSTRAINT[PK_Type_Pet] PRIMARY KEY CLUSTERED
//(
//    [id] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
//) ON[PRIMARY]
//GO
///****** Object:  Table [dbo].[Type_Vrach]    Script Date: 19.04.2025 13:15:54 ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//CREATE TABLE[dbo].[Type_Vrach]
//    (

//    [id][int] IDENTITY(1,1) NOT NULL,

//    [name] [nvarchar] (50) NULL,
// CONSTRAINT[PK_Type_Vrach] PRIMARY KEY CLUSTERED
//(
//    [id] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
//) ON[PRIMARY]
//GO
///****** Object:  Table [dbo].[Vrach]    Script Date: 19.04.2025 13:15:54 ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//CREATE TABLE[dbo].[Vrach]
//    (

//    [idVrach][int] IDENTITY(1,1) NOT NULL,

//    [famVrach] [nvarchar] (50) NULL,
//	[nameVrach][nvarchar] (50) NULL,
//	[patronymicVrach][nvarchar] (50) NULL,
//	[idType][int] NULL,
//	[login][nvarchar] (50) NULL,
//	[password][nvarchar] (50) NULL,
// CONSTRAINT[PK_Vrach] PRIMARY KEY CLUSTERED
//(
//    [idVrach] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
//) ON[PRIMARY]
//GO
//SET IDENTITY_INSERT[dbo].[Gender]
//    ON
//GO
//INSERT[dbo].[Gender]
//    ([id], [name]) VALUES(1, N'Мужской')
//GO
//INSERT[dbo].[Gender]
//    ([id], [name]) VALUES(2, N'Женский')
//GO
//SET IDENTITY_INSERT[dbo].[Gender]
//    OFF
//GO
//SET IDENTITY_INSERT[dbo].[Pet]
//    ON
//GO
//INSERT[dbo].[Pet]
//    ([idPet], [namePet], [idGender], [idType], [Weight], [Height]) VALUES(1, N'Мяукалка', 1, 1, 40, 15)
//GO
//INSERT[dbo].[Pet]
//    ([idPet], [namePet], [idGender], [idType], [Weight], [Height]) VALUES(2, N'Гавка', 2, 2, 40, 20)
//GO
//INSERT[dbo].[Pet]
//    ([idPet], [namePet], [idGender], [idType], [Weight], [Height]) VALUES(3, N'Мышка', 1, 3, 5, 10)
//GO
//INSERT[dbo].[Pet]
//    ([idPet], [namePet], [idGender], [idType], [Weight], [Height]) VALUES(4, N'Жучка', 2, 2, 50, 30)
//GO
//INSERT[dbo].[Pet]
//    ([idPet], [namePet], [idGender], [idType], [Weight], [Height]) VALUES(5, N'Мышка', 1, 3, 5, 10)
//GO
//INSERT[dbo].[Pet]
//    ([idPet], [namePet], [idGender], [idType], [Weight], [Height]) VALUES(6, N'Мяукалка', 1, 1, 30, 15)
//GO
//INSERT[dbo].[Pet]
//    ([idPet], [namePet], [idGender], [idType], [Weight], [Height]) VALUES(7, N'кеша', 2, 4, 34, 22)
//GO
//INSERT[dbo].[Pet]
//    ([idPet], [namePet], [idGender], [idType], [Weight], [Height]) VALUES(8, N'Бобик', 1, 2, 30, 40)
//GO
//INSERT[dbo].[Pet]
//    ([idPet], [namePet], [idGender], [idType], [Weight], [Height]) VALUES(9, N'жучка', 1, 1, 40, 40)
//GO
//INSERT[dbo].[Pet]
//    ([idPet], [namePet], [idGender], [idType], [Weight], [Height]) VALUES(10, N'ттт', 1, 2, 67, 77)
//GO
//INSERT[dbo].[Pet]
//    ([idPet], [namePet], [idGender], [idType], [Weight], [Height]) VALUES(11, N'Собака', 1, 2, 20, 100)
//GO
//INSERT[dbo].[Pet]
//    ([idPet], [namePet], [idGender], [idType], [Weight], [Height]) VALUES(12, N'Кошка', 2, 1, 30, 40)
//GO
//INSERT[dbo].[Pet]
//    ([idPet], [namePet], [idGender], [idType], [Weight], [Height]) VALUES(13, N'Пес', 2, 2, 40, 100)
//GO
//INSERT[dbo].[Pet]
//    ([idPet], [namePet], [idGender], [idType], [Weight], [Height]) VALUES(14, N'Кошка', 2, 4, 30, 130)
//GO
//SET IDENTITY_INSERT[dbo].[Pet]
//    OFF
//GO
//SET IDENTITY_INSERT[dbo].[Priem]
//    ON
//GO
//INSERT[dbo].[Priem] ([idPriem], [idPet], [idVrach], [DataPriem], [Comment], [isDelete]) VALUES(3, 3, 3, CAST(N'2025-04-17' AS Date), N'лысеют участки шерсти', 0)
//GO
//INSERT[dbo].[Priem] ([idPriem], [idPet], [idVrach], [DataPriem], [Comment], [isDelete]) VALUES(4, 4, 2, CAST(N'2025-04-17' AS Date), N'Аллергия на корм', 0)
//GO
//INSERT[dbo].[Priem] ([idPriem], [idPet], [idVrach], [DataPriem], [Comment], [isDelete]) VALUES(7, 3, 2, CAST(N'2025-04-17' AS Date), N'dssd', 0)
//GO
//INSERT[dbo].[Priem] ([idPriem], [idPet], [idVrach], [DataPriem], [Comment], [isDelete]) VALUES(16, 7, 3, CAST(N'2025-04-18' AS Date), N'уув', 0)
//GO
//INSERT[dbo].[Priem] ([idPriem], [idPet], [idVrach], [DataPriem], [Comment], [isDelete]) VALUES(18, 2, 1, CAST(N'2025-04-19' AS Date), N'Отказывается от еды', 1)
//GO
//INSERT[dbo].[Priem] ([idPriem], [idPet], [idVrach], [DataPriem], [Comment], [isDelete]) VALUES(20, 2, 1, CAST(N'2025-04-19' AS Date), N'', 1)
//GO
//INSERT[dbo].[Priem] ([idPriem], [idPet], [idVrach], [DataPriem], [Comment], [isDelete]) VALUES(21, 13, 1, CAST(N'2025-04-19' AS Date), N'Перенесли', 1)
//GO
//INSERT[dbo].[Priem] ([idPriem], [idPet], [idVrach], [DataPriem], [Comment], [isDelete]) VALUES(22, 14, 1, CAST(N'2025-04-23' AS Date), N'Попугай', 0)
//GO
//SET IDENTITY_INSERT[dbo].[Priem]
//    OFF
//GO
//SET IDENTITY_INSERT[dbo].[Type_Pet]
//    ON
//GO
//INSERT[dbo].[Type_Pet]
//    ([id], [name]) VALUES(1, N'Кошка')
//GO
//INSERT[dbo].[Type_Pet]
//    ([id], [name]) VALUES(2, N'Собака')
//GO
//INSERT[dbo].[Type_Pet]
//    ([id], [name]) VALUES(3, N'Крыса')
//GO
//INSERT[dbo].[Type_Pet]
//    ([id], [name]) VALUES(4, N'Попугай')
//GO
//SET IDENTITY_INSERT[dbo].[Type_Pet]
//    OFF
//GO
//SET IDENTITY_INSERT[dbo].[Type_Vrach]
//    ON
//GO
//INSERT[dbo].[Type_Vrach]
//    ([id], [name]) VALUES(1, N'Терапевт')
//GO
//INSERT[dbo].[Type_Vrach]
//    ([id], [name]) VALUES(2, N'Эндокринолог')
//GO
//INSERT[dbo].[Type_Vrach]
//    ([id], [name]) VALUES(3, N'Дерматолог')
//GO
//INSERT[dbo].[Type_Vrach]
//    ([id], [name]) VALUES(4, N'Диетолог')
//GO
//SET IDENTITY_INSERT[dbo].[Type_Vrach]
//    OFF
//GO
//SET IDENTITY_INSERT[dbo].[Vrach]
//    ON
//GO
//INSERT[dbo].[Vrach]
//    ([idVrach], [famVrach], [nameVrach], [patronymicVrach], [idType], [login], [password]) VALUES(1, N'Комарова', N'Татьяна', N'Геннадьевна', 1, N'1', N'1')
//GO
//INSERT[dbo].[Vrach]
//    ([idVrach], [famVrach], [nameVrach], [patronymicVrach], [idType], [login], [password]) VALUES(2, N'Ларина', N'Ольга', N'Юрьевна', 2, N'2', N'1')
//GO
//INSERT[dbo].[Vrach]
//    ([idVrach], [famVrach], [nameVrach], [patronymicVrach], [idType], [login], [password]) VALUES(3, N'Золотухина', N'Кристина', N'Вячеславовна', 3, N'3', N'1')
//GO
//INSERT[dbo].[Vrach]
//    ([idVrach], [famVrach], [nameVrach], [patronymicVrach], [idType], [login], [password]) VALUES(4, N'Хасанов', N'Ильназ', N'Ильдусович', 4, N'4', N'1')
//GO
//SET IDENTITY_INSERT[dbo].[Vrach]
//    OFF
//GO
//ALTER TABLE[dbo].[Pet] WITH CHECK ADD CONSTRAINT[FK_Pet_Gender] FOREIGN KEY([idGender])
//REFERENCES[dbo].[Gender]
//    ([id])
//GO
//ALTER TABLE[dbo].[Pet]
//    CHECK CONSTRAINT[FK_Pet_Gender]
//GO
//ALTER TABLE[dbo].[Pet] WITH CHECK ADD CONSTRAINT[FK_Pet_Type_Pet] FOREIGN KEY([idType])
//REFERENCES[dbo].[Type_Pet]
//    ([id])
//GO
//ALTER TABLE[dbo].[Pet]
//    CHECK CONSTRAINT[FK_Pet_Type_Pet]
//GO
//ALTER TABLE[dbo].[Priem] WITH CHECK ADD CONSTRAINT[FK_Priem_Pet] FOREIGN KEY([idPet])
//REFERENCES[dbo].[Pet]
//    ([idPet])
//GO
//ALTER TABLE[dbo].[Priem]
//    CHECK CONSTRAINT[FK_Priem_Pet]
//GO
//ALTER TABLE[dbo].[Priem] WITH CHECK ADD CONSTRAINT[FK_Priem_Vrach] FOREIGN KEY([idVrach])
//REFERENCES[dbo].[Vrach]
//    ([idVrach])
//GO
//ALTER TABLE[dbo].[Priem]
//    CHECK CONSTRAINT[FK_Priem_Vrach]
//GO
//ALTER TABLE[dbo].[Vrach] WITH CHECK ADD CONSTRAINT[FK_Vrach_Type_Vrach] FOREIGN KEY([idType])
//REFERENCES[dbo].[Type_Vrach]
//    ([id])
//GO
//ALTER TABLE[dbo].[Vrach]
//    CHECK CONSTRAINT[FK_Vrach_Type_Vrach]
//GO



}
