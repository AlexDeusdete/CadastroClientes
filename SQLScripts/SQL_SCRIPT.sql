USE master ;  
GO  
CREATE DATABASE TesteWF
ON   
( NAME = TesteWF_dat,  
    FILENAME = 'C:\Users\alexd\testewfdat.mdf',  
    SIZE = 10,  
    MAXSIZE = 50,  
    FILEGROWTH = 5 )  
LOG ON  
( NAME = TesteWF_log,  
    FILENAME = 'C:\Users\alexd\testewflog.ldf',  
    SIZE = 5MB,  
    MAXSIZE = 25MB,  
    FILEGROWTH = 5MB ) ;  
GO  

USE TesteWF;  
GO  

--Tabela Cliente
CREATE TABLE [dbo].[Cliente](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NomeCompleto] [varchar](250) NOT NULL,
	[CPF_CNPJ] [varchar](14) NOT NULL,
	[Email] [varchar](250) NULL,
	[Observacao] [varchar](500) NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Cliente] UNIQUE NONCLUSTERED 
(
	[CPF_CNPJ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


--Tabela TipoTelefone
CREATE TABLE [dbo].[TipoTelefone](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipoTelefone] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

--Tabela ClienteEndereco
CREATE TABLE [dbo].[ClienteEndereco](
	[ID] [int] IDENTITY(1,1)  NOT NULL,
	[ClienteID] [int] NOT NULL,
	[Endereco] [varchar](250) NOT NULL,
	[Numero] [varchar](20) NOT NULL,
	[Bairro] [varchar](50) NULL,
	[Cidade] [varchar](70) NOT NULL,
	[UF] [varchar](2) NOT NULL,
	[CEP] [varchar](9) NOT NULL,
	[Pais] [varchar](50) NULL,
	[Complemento] [varchar](50) NULL,
 CONSTRAINT [PK_ClienteEndereco] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ClienteEndereco]  WITH CHECK ADD  CONSTRAINT [FK_ClienteEndereco_Cliente] FOREIGN KEY([ClienteID])
REFERENCES [dbo].[Cliente] ([ID])
GO

ALTER TABLE [dbo].[ClienteEndereco] CHECK CONSTRAINT [FK_ClienteEndereco_Cliente]
GO

--Tabela ClienteTelefone
CREATE TABLE [dbo].[ClienteTelefone](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ClienteID] [int] NULL,
	[DDD] [varchar](3) NULL,
	[Telefone] [varchar](20) NULL,
	[TipoTelefoneID] [int] NULL,
 CONSTRAINT [PK_ClienteTelefone] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ClienteTelefone]  WITH CHECK ADD  CONSTRAINT [FK_ClienteTelefone_Cliente] FOREIGN KEY([ClienteID])
REFERENCES [dbo].[Cliente] ([ID])
GO

ALTER TABLE [dbo].[ClienteTelefone] CHECK CONSTRAINT [FK_ClienteTelefone_Cliente]
GO

ALTER TABLE [dbo].[ClienteTelefone]  WITH CHECK ADD  CONSTRAINT [FK_ClienteTelefone_TipoTelefone] FOREIGN KEY([TipoTelefoneID])
REFERENCES [dbo].[TipoTelefone] ([ID])
GO

ALTER TABLE [dbo].[ClienteTelefone] CHECK CONSTRAINT [FK_ClienteTelefone_TipoTelefone]
GO

--Valores padroes do tipo de telefone
INSERT INTO TipoTelefone
Values('Celular'),
	  ('Telefone Fixo')

