--Definicion de tablas--
CREATE DATABASE tiendaBd;
use TiendaBd;
go

CREATE TABLE Clientes (
    ClienteID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100),
    Apellidos VARCHAR(100),
    Direcci�n VARCHAR(255)
);

CREATE TABLE Tienda (
    TiendaID INT PRIMARY KEY IDENTITY(1,1),
    Sucursal VARCHAR(100),
    Direcci�n VARCHAR(255)
);

CREATE TABLE Art�culos (
    Art�culoID INT PRIMARY KEY IDENTITY(1,1),
    C�digo VARCHAR(50),
    Descripci�n TEXT,
    Precio DECIMAL(10, 2),
    Imagen VARCHAR(255),
    Stock INT
);

GO

-- Relaciones --

CREATE TABLE Art�culo_Tienda (
    Art�culoID INT,
    TiendaID INT,
    Fecha DATE,
    PRIMARY KEY (Art�culoID, TiendaID),
    FOREIGN KEY (Art�culoID) REFERENCES Art�culos(Art�culoID),
    FOREIGN KEY (TiendaID) REFERENCES Tienda(TiendaID)
);

CREATE TABLE Cliente_Art�culo (
    ClienteID INT,
    Art�culoID INT,
    Fecha DATE,
    PRIMARY KEY (ClienteID, Art�culoID),
    FOREIGN KEY (ClienteID) REFERENCES Clientes(ClienteID),
    FOREIGN KEY (Art�culoID) REFERENCES Art�culos(Art�culoID)
);

GO

-- Ajustes --

ALTER TABLE Art�culo_Tienda
ADD CONSTRAINT FK_Art�culo_Tienda_Art�culo FOREIGN KEY (Art�culoID) REFERENCES Art�culos(Art�culoID) ON DELETE CASCADE ON UPDATE CASCADE,
ADD CONSTRAINT FK_Art�culo_Tienda_Tienda FOREIGN KEY (TiendaID) REFERENCES Tienda(TiendaID) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE Cliente_Art�culo
ADD CONSTRAINT FK_Cliente_Art�culo_Cliente FOREIGN KEY (ClienteID) REFERENCES Clientes(ClienteID) ON DELETE CASCADE ON UPDATE CASCADE,
ADD CONSTRAINT FK_Cliente_Art�culo_Art�culo FOREIGN KEY (Art�culoID) REFERENCES Art�culos(Art�culoID) ON DELETE CASCADE ON UPDATE CASCADE;
