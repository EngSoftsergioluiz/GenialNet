USE [master]
GO
/****** Object:  Database [GenialDB]    Script Date: 13/02/2025 01:23:25 ******/
CREATE DATABASE [GenialDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GenialDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\GenialDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GenialDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\GenialDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [GenialDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GenialDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GenialDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GenialDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GenialDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GenialDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GenialDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [GenialDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GenialDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GenialDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GenialDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GenialDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GenialDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GenialDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GenialDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GenialDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GenialDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [GenialDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GenialDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GenialDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GenialDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GenialDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GenialDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [GenialDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GenialDB] SET RECOVERY FULL 
GO
ALTER DATABASE [GenialDB] SET  MULTI_USER 
GO
ALTER DATABASE [GenialDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GenialDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GenialDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GenialDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GenialDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GenialDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'GenialDB', N'ON'
GO
ALTER DATABASE [GenialDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [GenialDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [GenialDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 13/02/2025 01:23:26 ******/
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
/****** Object:  Table [dbo].[Fornecedores]    Script Date: 13/02/2025 01:23:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fornecedores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NOT NULL,
	[CNPJ] [nvarchar](450) NOT NULL,
	[Endereco] [nvarchar](max) NOT NULL,
	[Telefone] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Fornecedores] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produtos]    Script Date: 13/02/2025 01:23:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produtos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [nvarchar](450) NOT NULL,
	[Marca] [nvarchar](max) NOT NULL,
	[UnidadeMedida] [nvarchar](max) NOT NULL,
	[FornecedorId] [int] NULL,
 CONSTRAINT [PK_Produtos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250212025558_InitialCreate', N'9.0.2')
GO
SET IDENTITY_INSERT [dbo].[Fornecedores] ON 

INSERT [dbo].[Fornecedores] ([Id], [Nome], [CNPJ], [Endereco], [Telefone]) VALUES (1, N'Mercado Paulista', N'26.177.087/0001-60', N'Praça da Sé, Sé, São Paulo - SP', N'11987654321')
INSERT [dbo].[Fornecedores] ([Id], [Nome], [CNPJ], [Endereco], [Telefone]) VALUES (2, N'Mercado Curitiba', N'77.804.902/0001-05', N'Rua Darci Vargas, Cidade Industrial, Curitiba - PR', N'11987654321')
INSERT [dbo].[Fornecedores] ([Id], [Nome], [CNPJ], [Endereco], [Telefone]) VALUES (3, N'Nome teste', N'25.341.135/0001-41', N'Rua Engenheiro Pedro Bonk, Guatupê, São José dos Pinhais - PR', N'11923334321')
INSERT [dbo].[Fornecedores] ([Id], [Nome], [CNPJ], [Endereco], [Telefone]) VALUES (4, N'Fornecedor Alpha', N'12.345.678/0001-95', N'Praça da Sé, Sé, São Paulo - SP', N'(11) 98765-4321')
INSERT [dbo].[Fornecedores] ([Id], [Nome], [CNPJ], [Endereco], [Telefone]) VALUES (5, N'Fornecedor Gama', N'30.488.356/0001-87', N'Avenida Afonso Pena, Centro, Belo Horizonte - MG', N'(31) 98877-6655')
INSERT [dbo].[Fornecedores] ([Id], [Nome], [CNPJ], [Endereco], [Telefone]) VALUES (6, N'Sergio Luiz da Silva', N'13.818.330/0001-30', N'Travessa Fresia, Eucaliptos, Fazenda Rio Grande - PR', N'(41) 99966-1736')
INSERT [dbo].[Fornecedores] ([Id], [Nome], [CNPJ], [Endereco], [Telefone]) VALUES (7, N'Kellen', N'81.627.230/0001-87', N'Rua Salto do Itararé, Cidade Industrial, Curitiba - PR', N'41997869763')
INSERT [dbo].[Fornecedores] ([Id], [Nome], [CNPJ], [Endereco], [Telefone]) VALUES (8, N'Fornecedor Delta', N'60.254.108/0001-32', N'Rua Engenheiro Pedro Bonk, Guatupê, São José dos Pinhais - PR', N'(71) 97766-5544')
INSERT [dbo].[Fornecedores] ([Id], [Nome], [CNPJ], [Endereco], [Telefone]) VALUES (9, N'Fornecedor lua', N'16.184.414/0001-58', N'Praça da Sé, Sé, São Paulo - SP', N'(11) 98765-4321')
INSERT [dbo].[Fornecedores] ([Id], [Nome], [CNPJ], [Endereco], [Telefone]) VALUES (10, N'Fornecedor sol', N'41.256.387/0001-29', N'Praça da Sé, Sé, São Paulo - SP', N'(11) 98765-4321')
INSERT [dbo].[Fornecedores] ([Id], [Nome], [CNPJ], [Endereco], [Telefone]) VALUES (11, N'ForneSon', N'63.261.038/0001-38', N'Praça da Sé, Sé, São Paulo - SP', N'(11) 98765-4321')
SET IDENTITY_INSERT [dbo].[Fornecedores] OFF
GO
SET IDENTITY_INSERT [dbo].[Produtos] ON 

INSERT [dbo].[Produtos] ([Id], [Descricao], [Marca], [UnidadeMedida], [FornecedorId]) VALUES (1, N'bala', N'fini', N'pacote', 11)
INSERT [dbo].[Produtos] ([Id], [Descricao], [Marca], [UnidadeMedida], [FornecedorId]) VALUES (2, N'chocolate', N'nestle', N'barra', 11)
INSERT [dbo].[Produtos] ([Id], [Descricao], [Marca], [UnidadeMedida], [FornecedorId]) VALUES (3, N'garrafa', N'stanley', N'unidade', 10)
INSERT [dbo].[Produtos] ([Id], [Descricao], [Marca], [UnidadeMedida], [FornecedorId]) VALUES (4, N'', N'stanley', N'unidade', NULL)
INSERT [dbo].[Produtos] ([Id], [Descricao], [Marca], [UnidadeMedida], [FornecedorId]) VALUES (5, N'Chiclete', N'fini', N'unidade', 10)
INSERT [dbo].[Produtos] ([Id], [Descricao], [Marca], [UnidadeMedida], [FornecedorId]) VALUES (6, N'Desenvolvedor de software', N'C#', N'unidade', 6)
INSERT [dbo].[Produtos] ([Id], [Descricao], [Marca], [UnidadeMedida], [FornecedorId]) VALUES (7, N'Copo', N'Stanley', N'unidade', 10)
SET IDENTITY_INSERT [dbo].[Produtos] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Fornecedores_CNPJ]    Script Date: 13/02/2025 01:23:26 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Fornecedores_CNPJ] ON [dbo].[Fornecedores]
(
	[CNPJ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Produtos_Descricao]    Script Date: 13/02/2025 01:23:26 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Produtos_Descricao] ON [dbo].[Produtos]
(
	[Descricao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Produtos_FornecedorId]    Script Date: 13/02/2025 01:23:26 ******/
CREATE NONCLUSTERED INDEX [IX_Produtos_FornecedorId] ON [dbo].[Produtos]
(
	[FornecedorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Produtos]  WITH CHECK ADD  CONSTRAINT [FK_Produtos_Fornecedores_FornecedorId] FOREIGN KEY([FornecedorId])
REFERENCES [dbo].[Fornecedores] ([Id])
GO
ALTER TABLE [dbo].[Produtos] CHECK CONSTRAINT [FK_Produtos_Fornecedores_FornecedorId]
GO
/****** Object:  StoredProcedure [dbo].[GetProdutos]    Script Date: 13/02/2025 01:23:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProdutos]
AS
BEGIN
    SELECT * FROM Produtos
END
GO
USE [master]
GO
ALTER DATABASE [GenialDB] SET  READ_WRITE 
GO
