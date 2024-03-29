USE [master]
GO
/****** Object:  Database [BDRestauCSHARP]    Script Date: 27/04/2023 10:39:05 a. m. ******/
CREATE DATABASE [BDRestauCSHARP]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BDRestauCSHARP', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BDRestauCSHARP.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BDRestauCSHARP_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BDRestauCSHARP_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BDRestauCSHARP] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BDRestauCSHARP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BDRestauCSHARP] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BDRestauCSHARP] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BDRestauCSHARP] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BDRestauCSHARP] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BDRestauCSHARP] SET ARITHABORT OFF 
GO
ALTER DATABASE [BDRestauCSHARP] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BDRestauCSHARP] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BDRestauCSHARP] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BDRestauCSHARP] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BDRestauCSHARP] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BDRestauCSHARP] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BDRestauCSHARP] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BDRestauCSHARP] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BDRestauCSHARP] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BDRestauCSHARP] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BDRestauCSHARP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BDRestauCSHARP] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BDRestauCSHARP] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BDRestauCSHARP] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BDRestauCSHARP] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BDRestauCSHARP] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BDRestauCSHARP] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BDRestauCSHARP] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BDRestauCSHARP] SET  MULTI_USER 
GO
ALTER DATABASE [BDRestauCSHARP] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BDRestauCSHARP] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BDRestauCSHARP] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BDRestauCSHARP] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BDRestauCSHARP] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BDRestauCSHARP] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BDRestauCSHARP] SET QUERY_STORE = OFF
GO
USE [BDRestauCSHARP]
GO
/****** Object:  Table [dbo].[Caja]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Caja](
	[IDcaja] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Tema] [varchar](50) NOT NULL,
	[Serial_PC] [nvarchar](max) NOT NULL,
	[Estado] [varchar](50) NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
	[Ruta_Backups] [nvarchar](max) NOT NULL,
	[Fecha_Ultimo_Backup] [varchar](50) NOT NULL,
	[Fecha_Ultimo_Backup_Date] [datetime] NOT NULL,
	[Frecuencia_Backups] [int] NOT NULL,
	[Estado_Backups] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Caja] PRIMARY KEY CLUSTERED 
(
	[IDcaja] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Direccion] [nvarchar](50) NULL,
	[RFC] [nvarchar](50) NOT NULL,
	[Celular] [varchar](50) NULL,
	[Estado] [varchar](50) NULL,
	[Saldo] [numeric](18, 2) NOT NULL,
	[CURP] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grupo_Productos]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grupo_Productos](
	[idGrupo] [int] IDENTITY(1,1) NOT NULL,
	[Grupo] [varchar](50) NULL,
	[PorDefecto] [varchar](50) NULL,
	[Icono] [image] NULL,
	[Estado] [varchar](50) NULL,
	[Estado_de_icono] [varchar](50) NULL,
 CONSTRAINT [pk_familias] PRIMARY KEY CLUSTERED 
(
	[idGrupo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mesas]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mesas](
	[Id_mesa] [int] IDENTITY(1,1) NOT NULL,
	[Mesa] [varchar](50) NULL,
	[Id_salon] [int] NULL,
	[Estado_vida] [varchar](50) NULL,
	[Estado_Disponibilidad] [varchar](50) NULL,
 CONSTRAINT [PK_Mesas] PRIMARY KEY CLUSTERED 
(
	[Id_mesa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Modulos]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modulos](
	[IdModulo] [int] IDENTITY(1,1) NOT NULL,
	[Modulo] [varchar](max) NULL,
 CONSTRAINT [PK_Modulos] PRIMARY KEY CLUSTERED 
(
	[IdModulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permisos_]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permisos_](
	[IDPermiso] [int] IDENTITY(1,1) NOT NULL,
	[Id_Modulo] [int] NULL,
	[Id_Usuario] [int] NULL,
 CONSTRAINT [PK_Permisos_] PRIMARY KEY CLUSTERED 
(
	[IDPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[idProducto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Imagen] [image] NULL,
	[id_Grupo] [int] NOT NULL,
	[Usa_Inventarios] [varchar](50) NULL,
	[Stock] [varchar](50) NULL,
	[PrecioVenta] [numeric](18, 2) NULL,
	[Stock_Minimo] [numeric](18, 2) NULL,
	[Precio_de_compra] [numeric](18, 2) NULL,
	[Estado_Imagen] [varchar](50) NULL,
 CONSTRAINT [pk_Productos] PRIMARY KEY CLUSTERED 
(
	[idProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Propiedades_de_mesas]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Propiedades_de_mesas](
	[Id_propiedades] [int] IDENTITY(1,1) NOT NULL,
	[x] [int] NULL,
	[y] [int] NULL,
	[Tamanio_letra] [int] NULL,
 CONSTRAINT [PK_Propìedades_de_mesas] PRIMARY KEY CLUSTERED 
(
	[Id_propiedades] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SALON]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SALON](
	[Id_salon] [int] IDENTITY(1,1) NOT NULL,
	[Salon] [varchar](50) NULL,
	[Estado] [varchar](50) NULL,
 CONSTRAINT [PK_SALON] PRIMARY KEY CLUSTERED 
(
	[Id_salon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](max) NULL,
	[Login] [varchar](max) NULL,
	[Password] [varchar](max) NULL,
	[Icono] [image] NULL,
	[Correo] [varchar](max) NULL,
	[Rol] [varchar](max) NULL,
	[Estado_Icono] [varchar](max) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ventas]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ventas](
	[idVenta] [int] IDENTITY(1,1) NOT NULL,
	[idClienteV] [int] NOT NULL,
	[fecha_venta] [datetime] NOT NULL,
	[Numero_Doc] [nvarchar](50) NOT NULL,
	[Monto_Total] [numeric](18, 2) NOT NULL,
	[TipoPago] [nvarchar](50) NOT NULL,
	[Estado] [varchar](50) NOT NULL,
	[IVA] [numeric](18, 2) NOT NULL,
	[Comprobante] [varchar](50) NOT NULL,
	[Id_Usuario] [int] NOT NULL,
	[Fecha_Pago] [varchar](50) NOT NULL,
	[Accion] [varchar](50) NOT NULL,
	[Saldo] [numeric](18, 2) NOT NULL,
	[PagoCon] [numeric](18, 2) NOT NULL,
	[Porcentaje_IVA] [numeric](18, 2) NOT NULL,
	[ID_caja] [int] NOT NULL,
	[Referencia_Tarjeta] [varchar](50) NOT NULL,
	[Vuelto] [numeric](18, 2) NULL,
	[Efectivo] [numeric](18, 2) NULL,
	[Credito] [numeric](18, 2) NULL,
	[Tarjeta] [numeric](18, 2) NULL,
	[Id_Mesa] [int] NOT NULL,
	[Numero_Personas] [int] NOT NULL,
	[Lugar_Consumo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Ventas] PRIMARY KEY CLUSTERED 
(
	[idVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Mesas]  WITH CHECK ADD  CONSTRAINT [FK_Mesas_SALON] FOREIGN KEY([Id_salon])
REFERENCES [dbo].[SALON] ([Id_salon])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Mesas] CHECK CONSTRAINT [FK_Mesas_SALON]
GO
ALTER TABLE [dbo].[Permisos_]  WITH CHECK ADD  CONSTRAINT [FK_Permisos__Modulos] FOREIGN KEY([Id_Modulo])
REFERENCES [dbo].[Modulos] ([IdModulo])
GO
ALTER TABLE [dbo].[Permisos_] CHECK CONSTRAINT [FK_Permisos__Modulos]
GO
ALTER TABLE [dbo].[Permisos_]  WITH CHECK ADD  CONSTRAINT [FK_Permisos__Usuario] FOREIGN KEY([Id_Usuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Permisos_] CHECK CONSTRAINT [FK_Permisos__Usuario]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos] FOREIGN KEY([id_Grupo])
REFERENCES [dbo].[Grupo_Productos] ([idGrupo])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos]
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD  CONSTRAINT [FK_Ventas_Caja] FOREIGN KEY([ID_caja])
REFERENCES [dbo].[Caja] ([IDcaja])
GO
ALTER TABLE [dbo].[Ventas] CHECK CONSTRAINT [FK_Ventas_Caja]
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD  CONSTRAINT [FK_Ventas_Cliente] FOREIGN KEY([idClienteV])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Ventas] CHECK CONSTRAINT [FK_Ventas_Cliente]
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD  CONSTRAINT [FK_Ventas_Mesas] FOREIGN KEY([Id_Mesa])
REFERENCES [dbo].[Mesas] ([Id_mesa])
GO
ALTER TABLE [dbo].[Ventas] CHECK CONSTRAINT [FK_Ventas_Mesas]
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD  CONSTRAINT [FK_Ventas_Usuario] FOREIGN KEY([Id_Usuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Ventas] CHECK CONSTRAINT [FK_Ventas_Usuario]
GO
/****** Object:  StoredProcedure [dbo].[aumentar_tamanio_Letra]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[aumentar_tamanio_Letra]
as
update Propiedades_de_mesas set Tamanio_letra = Tamanio_letra+2
GO
/****** Object:  StoredProcedure [dbo].[aumentar_Tamanio_mesa]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[aumentar_Tamanio_mesa]
as
UPDATE Propiedades_de_mesas set x=x+10, y=y+10
GO
/****** Object:  StoredProcedure [dbo].[Buscar_Usuarios]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Buscar_Usuarios]
@buscador nvarchar(50)
as
SELECT * FROM Usuario
where Login+Nombre+Correo Like '%' + @buscador + '%'
GO
/****** Object:  StoredProcedure [dbo].[contar_Productos_Por_grupo]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   proc [dbo].[contar_Productos_Por_grupo]
@idgrupo int
as
select count (idProducto) from Productos
where id_Grupo = @idgrupo
GO
/****** Object:  StoredProcedure [dbo].[disminuir_tamanio_Letra]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[disminuir_tamanio_Letra]
as

if exists(select x,y from Propiedades_de_mesas where Tamanio_letra<=9)
RAISERROR ('Tamaño de fuente mínimo.',16,1)
else
UPDATE Propiedades_de_mesas set Tamanio_letra = Tamanio_letra-2
GO
/****** Object:  StoredProcedure [dbo].[disminuir_Tamanio_mesa]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[disminuir_Tamanio_mesa]
as

if exists(select x,y from Propiedades_de_mesas where x<92 and y<77)
RAISERROR ('Excede el límite de tamaño',16,1)
else
UPDATE Propiedades_de_mesas set x=x-10, y=y-10
GO
/****** Object:  StoredProcedure [dbo].[EDITAR_MESA]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[EDITAR_MESA]

@mesa as varchar(50),
@id_mesa as int
as
if exists (SELECT Mesa from Mesas where (Mesa = @mesa and Id_mesa <> @id_mesa))

RAISERROR ('Ya existe una mesa con este nombre, POR FAVOR INGRESE DE NUEVO', 16,1)

UPDATE Mesas set Mesa = @mesa
where Id_mesa = @id_mesa
GO
/****** Object:  StoredProcedure [dbo].[editar_Modulos]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROC [dbo].[editar_Modulos]
@idModulo As int,
@Modulo As varchar(MAX)
As
UPDATE Modulos Set

Modulo=@Modulo
Where idModulo=@idModulo

GO
/****** Object:  StoredProcedure [dbo].[editar_Permisos]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROC [dbo].[editar_Permisos]
@IdPermiso As int,
@ID_modulo As int,
@Id_usuario As int
As
UPDATE Permisos Set

ID_modulo=@ID_modulo,
Id_usuario=@Id_usuario
Where IdPermiso=@IdPermiso

GO
/****** Object:  StoredProcedure [dbo].[editar_Permisos_]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROC [dbo].[editar_Permisos_]
@IDPermiso As int,
@Id_Modulo As int,
@Id_Usuario As int
As
UPDATE Permisos_ Set

Id_Modulo=@Id_Modulo,
Id_Usuario=@Id_Usuario
Where IDPermiso=@IDPermiso

GO
/****** Object:  StoredProcedure [dbo].[editar_Usuario]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROC [dbo].[editar_Usuario]
@IdUsuario As int,
@Nombre As varchar(MAX),
@Login As varchar(MAX),
@Password As varchar(MAX),
@Icono As image,
@Correo As varchar(MAX),
@Rol As varchar(MAX)
As

if exists (SELECT Login, IdUsuario from Usuario where Login = @Login and IdUsuario <> @IdUsuario)
	raiserror('Usuario ya en uso, ingresa otro nombre de Usuario',16,1)
else
UPDATE Usuario Set
Nombre=@Nombre,
Login=@Login,
Password=@Password,
Icono=@Icono,
Correo=@Correo,
Rol=@Rol
Where IdUsuario=@IdUsuario

GO
/****** Object:  StoredProcedure [dbo].[eliminar_Modulos]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROC [dbo].[eliminar_Modulos]
@idModulo As int

As
DELETE FROM Modulos
WHERE idModulo=@idModulo
GO
/****** Object:  StoredProcedure [dbo].[eliminar_Permisos_]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[eliminar_Permisos_]
@IdUsuario As int

As
DELETE FROM Permisos_
WHERE Id_Usuario=@IdUsuario
GO
/****** Object:  StoredProcedure [dbo].[eliminar_Usuario]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROC [dbo].[eliminar_Usuario]
@IdUsuario As int

As
update Usuario set Estado_Icono = 'Eliminado'
WHERE IdUsuario=@IdUsuario
GO
/****** Object:  StoredProcedure [dbo].[insertar_Grupo_Productos]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROC [dbo].[insertar_Grupo_Productos]
@Grupo As varchar(50),
@PorDefecto As varchar(50),
@Icono As image,
@Estado As varchar(50),
@Estado_de_icono As varchar(50)
As

if EXISTS (SELECT * FROM Grupo_Productos Where Grupo=@Grupo)
RAISERROR ('YA EXISTE UN GRUPO CON ESTE NOMBRE, Ingrese de nuevo', 16,1)
Else
INSERT INTO Grupo_Productos
Values (
@Grupo,
@PorDefecto,
@Icono,
@Estado,
@Estado_de_icono)
GO
/****** Object:  StoredProcedure [dbo].[insertar_mesa]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[insertar_mesa]
@mesa varchar(50),
@idsalon int
AS
declare @EstadoVida varchar(50)
declare @EstadoDisponibilidad varchar(50)
set @EstadoVida = 'ACTIVO'
set @EstadoDisponibilidad = 'LIBRE'

if EXISTS(select Mesa from Mesas where Mesa = @mesa and Mesa <> 'NULO')
RAISERROR('YA EXISTE UNA MESA CON ESE NOMBRE, ingrese otro nombre.',16,1)
else
insert into Mesas values (@mesa, @idsalon, @EstadoVida,@EstadoDisponibilidad)
GO
/****** Object:  StoredProcedure [dbo].[insertar_Modulos]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROC [dbo].[insertar_Modulos]
@Modulo As varchar(MAX)
As
INSERT INTO Modulos
Values (
@Modulo)

GO
/****** Object:  StoredProcedure [dbo].[insertar_Permisos]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROC [dbo].[insertar_Permisos]
@ID_modulo As int,
@Id_usuario As int
As
INSERT INTO Permisos_
Values (
@ID_modulo,
@Id_usuario)

GO
/****** Object:  StoredProcedure [dbo].[insertar_Permisos_]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROC [dbo].[insertar_Permisos_]
@Id_Modulo As int,
@Id_Usuario As int
As
INSERT INTO Permisos_
Values (
@Id_Modulo,
@Id_Usuario)

GO
/****** Object:  StoredProcedure [dbo].[insertar_Productos]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[insertar_Productos]
@Nombre As varchar(50),
@Imagen As image,
@id_Grupo As int,
@PrecioVenta As numeric(18,2),
@Estado_Imagen As varchar(50)
As
declare @Precio_de_compra As numeric(18,2)
declare @Stock As varchar(50)
declare @Usa_Inventarios As varchar(50)
declare @Stock_Minimo numeric(18,2)

set @Precio_de_compra = 0
set @Stock = 0
set @Usa_Inventarios = 'NULO'
set @Stock_Minimo = 0

if EXISTS (SELECT Nombre FROM Productos Where Nombre =@Nombre)
RAISERROR ('YA EXISTE UN PRODUCTO CON ESTE NOMBRE, intente de nuevo.', 16,1)
Else
INSERT INTO Productos
Values (
@Nombre,
@Imagen,
@id_Grupo,
@Usa_Inventarios,
@Stock,
@PrecioVenta,
@Stock_Minimo,
@Precio_de_compra,
@Estado_Imagen)
GO
/****** Object:  StoredProcedure [dbo].[insertar_Salon]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[insertar_Salon]
@Salon varchar(50)
as
declare @Estado varchar(50)
set @Estado ='ACTIVO'
if EXISTS(select Salon  from SALON  where Salon = @Salon )
RAISERROR('YA EXISTE UN SALON CON ESTE NOMBRE, ingrese de nuevo', 16,1)
else
insert into SALON values(@Salon , @Estado )
GO
/****** Object:  StoredProcedure [dbo].[insertar_Usuario]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROC [dbo].[insertar_Usuario]
@Nombre As varchar(MAX),
@Login As varchar(MAX),
@Password As varchar(MAX),
@Icono As image,
@Correo As varchar(MAX),
@Rol As varchar(MAX),
@Estado_Icono As varchar(MAX)
As
if exists (SELECT login from Usuario where Login = @Login )
	raiserror('YA EXISTE UN REGISTRO CON ESTE USUARIO, POR FAVOR INGRESE DE NUEVO',16,1)
else
INSERT INTO Usuario
Values (
@Nombre,
@Login,
@Password,
@Icono,
@Correo,
@Rol,
@Estado_Icono)

GO
/****** Object:  StoredProcedure [dbo].[insertar_Ventas]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROC [dbo].[insertar_Ventas]
@idClienteV As int,
@fecha_venta As datetime,
@Id_Usuario As int,
@Accion As varchar(50),
@ID_caja As int,
@Id_Mesa As int,
@Numero_Personas As int,
@Lugar_Consumo As varchar(50)
As
DECLARE @Numero_Doc As nvarchar(50) set @Numero_Doc=0
declare @Monto_Total As numeric(18,2) set @Monto_Total=0
declare @TipoPago As nvarchar(50) set @TipoPago=0
declare @Estado As varchar(50) set @Estado=0
declare @IVA As numeric(18,2) set @IVA=0
declare @Comprobante As varchar(50) set @Comprobante=0
declare @Fecha_Pago As varchar(50) set @Fecha_Pago=0
declare @Saldo As numeric(18,2) set @Saldo=0
declare @PagoCon As numeric(18,2) set @PagoCon=0
declare @Porcentaje_IVA As numeric(18,2) set @Porcentaje_IVA=0
declare @Referencia_Tarjeta As varchar(50) set @Referencia_Tarjeta=0
declare @Vuelto As numeric(18,2) set @Vuelto=0
declare @Efectivo As numeric(18,2) set @Efectivo=0
declare @Credito As numeric(18,2) set @Credito=0
declare @Tarjeta As numeric(18,2) set @Tarjeta=0

INSERT INTO Ventas
Values (
@idClienteV,
@fecha_venta,
@Numero_Doc,
@Monto_Total,
@TipoPago,
@Estado,
@IVA,
@Comprobante,
@Id_Usuario,
@Fecha_Pago,
@Accion,
@Saldo,
@PagoCon,
@Porcentaje_IVA,
@ID_caja,
@Referencia_Tarjeta,
@Vuelto,
@Efectivo,
@Credito,
@Tarjeta,
@Id_Mesa,
@Numero_Personas,
@Lugar_Consumo)
GO
/****** Object:  StoredProcedure [dbo].[mostraer_productos_por_grupo]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[mostraer_productos_por_grupo]
@id_grupo int
as
SELECT * FROM PRODUCTOS INNER JOIN Grupo_productos on
Grupo_Productos.IdGrupo = PRODUCTOS.Id_Grupo
where Productos.Id_Grupo = @id_grupo
GO
/****** Object:  StoredProcedure [dbo].[mostrar_mesas]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[mostrar_mesas]
AS
SELECT * from Mesas
GO
/****** Object:  StoredProcedure [dbo].[mostrar_Mesas_PorSalon]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[mostrar_Mesas_PorSalon]
@id_salon int
as
select Mesas.*, Propiedades_de_mesas.* from Mesas inner join SALON on Salon.Id_salon = Mesas.Id_Salon
cross join Propiedades_de_mesas
where Mesas.id_salon =  @id_salon
GO
/****** Object:  StoredProcedure [dbo].[mostrar_Mesas_PorSalon_Ventas]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[mostrar_Mesas_PorSalon_Ventas]
@id_salon int
as
select Mesas.*, Propiedades_de_mesas.* from Mesas inner join SALON on Salon.Id_salon = Mesas.Id_Salon
cross join Propiedades_de_mesas
where Mesas.id_salon =  @id_salon and Mesas.Mesa<>'NULO'
GO
/****** Object:  StoredProcedure [dbo].[mostrar_Modulos]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROC [dbo].[mostrar_Modulos]
As
Select * FROM Modulos


GO
/****** Object:  StoredProcedure [dbo].[mostrar_Permisos_]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[mostrar_Permisos_]
@idusuario int
As
Select Id_Modulo FROM Permisos_
where Id_Usuario = @idusuario 

GO
/****** Object:  StoredProcedure [dbo].[mostrar_SALON]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[mostrar_SALON]
@buscar varchar(50)
as
select*from SALON where Salon LIKE '%' + @buscar + '%'
GO
/****** Object:  StoredProcedure [dbo].[mostrar_Usuario]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROC [dbo].[mostrar_Usuario]
As
Select * FROM Usuario


GO
/****** Object:  StoredProcedure [dbo].[mostrar_UsuariosActivos]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[mostrar_UsuariosActivos]
As
Select * FROM Usuario where Estado_Icono = 'ACTIVO'
GO
/****** Object:  StoredProcedure [dbo].[MostrarIDSalonRI]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[MostrarIDSalonRI]
@Salon as varchar(50)
AS
select Id_salon from SALON
where Salon = @Salon
GO
/****** Object:  StoredProcedure [dbo].[ObtenerIDUsuario]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ObtenerIDUsuario]
@Login nvarchar(max)
as
Select IdUsuario from Usuario 
where Login = @Login
GO
/****** Object:  StoredProcedure [dbo].[Paginar_Grupos]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Paginar_Grupos]
@Desde int,
@Hasta int
as
BEGIN
	SET NOCOUNT ON
	SELECT
	idGrupo,
	Grupo,
	Icono,
	Estado_de_Icono
	from
	(select
	idgrupo,
	grupo,
	icono,
	estado_de_icono,
	ROW_NUMBER() Over (order by IdGrupo) 'Numero_de_fila'
	From Grupo_Productos) as Paginado
	Where (Paginado.Numero_de_fila >=@Desde) and (Paginado.Numero_de_fila <=@Hasta)
END
GO
/****** Object:  StoredProcedure [dbo].[paginar_Productos_por_Grupo]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[paginar_Productos_por_Grupo]
@Desde int,
@Hasta int,
@id_grupo int
AS
BEGIN
	SET NOCOUNT ON
	SELECT
	idProducto,
	Nombre,
	Imagen,
	PrecioVenta,
	Estado_Imagen,
	id_Grupo
	from
	(select
	idProducto,
	Nombre,
	Imagen,
	PrecioVenta,
	Estado_Imagen,
	Productos.id_Grupo,
	ROW_NUMBER() Over (order by idGrupo) 'Numero_de_fila'
	From 
	Productos Inner join Grupo_Productos on 
	Grupo_Productos.idGrupo = Productos.id_Grupo
	)  AS Paginado
	Where (Paginado.Numero_de_fila >=@Desde) and (Paginado.Numero_de_fila <=@Hasta) and Paginado.id_Grupo = @id_grupo
END
GO
/****** Object:  StoredProcedure [dbo].[Restaurar_Usuario]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[Restaurar_Usuario]
@IdUsuario As int
As
update Usuario set Estado_Icono = 'ACTIVO'
WHERE IdUsuario=@IdUsuario
GO
/****** Object:  StoredProcedure [dbo].[validarUsuario]    Script Date: 27/04/2023 10:39:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[validarUsuario]
@password varchar(max),
@login varchar(max)
as
SELECT IdUsuario
from Usuario where Password = @password and Login = @login
GO
USE [master]
GO
ALTER DATABASE [BDRestauCSHARP] SET  READ_WRITE 
GO
