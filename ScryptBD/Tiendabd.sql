--Definicion de tablas--
CREATE DATABASE tiendaBd;
use TiendaBd;
go

CREATE TABLE Clientes (
    ClienteID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100),
    Apellidos VARCHAR(100),
    Dirección VARCHAR(255)
);

CREATE TABLE Tienda (
    TiendaID INT PRIMARY KEY IDENTITY(1,1),
    Sucursal VARCHAR(100),
    Dirección VARCHAR(255)
);

CREATE TABLE Artículos (
    ArtículoID INT PRIMARY KEY IDENTITY(1,1),
    Código VARCHAR(50),
    Descripción TEXT,
    Precio DECIMAL(10, 2),
    Imagen VARCHAR(255),
    Stock INT
);

GO

-- Relaciones --

CREATE TABLE Artículo_Tienda (
    ArtículoID INT,
    TiendaID INT,
    Fecha DATE,
    PRIMARY KEY (ArtículoID, TiendaID),
    FOREIGN KEY (ArtículoID) REFERENCES Artículos(ArtículoID),
    FOREIGN KEY (TiendaID) REFERENCES Tienda(TiendaID)
);

CREATE TABLE Cliente_Artículo (
    ClienteID INT,
    ArtículoID INT,
    Fecha DATE,
    PRIMARY KEY (ClienteID, ArtículoID),
    FOREIGN KEY (ClienteID) REFERENCES Clientes(ClienteID),
    FOREIGN KEY (ArtículoID) REFERENCES Artículos(ArtículoID)
);

GO

-- Ajustes --

ALTER TABLE Artículo_Tienda
ADD CONSTRAINT FK_Artículo_Tienda_Artículo FOREIGN KEY (ArtículoID) REFERENCES Artículos(ArtículoID) ON DELETE CASCADE ON UPDATE CASCADE,
ADD CONSTRAINT FK_Artículo_Tienda_Tienda FOREIGN KEY (TiendaID) REFERENCES Tienda(TiendaID) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE Cliente_Artículo
ADD CONSTRAINT FK_Cliente_Artículo_Cliente FOREIGN KEY (ClienteID) REFERENCES Clientes(ClienteID) ON DELETE CASCADE ON UPDATE CASCADE,
ADD CONSTRAINT FK_Cliente_Artículo_Artículo FOREIGN KEY (ArtículoID) REFERENCES Artículos(ArtículoID) ON DELETE CASCADE ON UPDATE CASCADE;
