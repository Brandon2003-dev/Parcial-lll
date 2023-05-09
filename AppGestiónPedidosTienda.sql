Create database AppGestiónPedidosTienda

use AppGestiónPedidosTienda

CREATE TABLE Clientes
(
ID_Clientes INT IDENTITY(1,1) PRIMARY KEY not null,  
Nombre VARCHAR(50),
Dirección VARCHAR(50),  
Telefono INT not null,
NombreUs varchar(20)not null,  
Contraseña varchar (12)
);

CREATE TABLE Productos 
(
ID_Productos INT IDENTITY(1,1) PRIMARY KEY not null,  
Nombre VARCHAR(50),
Precio FLOAT,  
Descripción VARCHAR(50)
);

CREATE TABLE Pedidos 
(  
ID_Pedidos INT IDENTITY(1,1) PRIMARY KEY not null,
Fecha_de_Pedidos DATETIME ,  
ID_Clientes INT not null,
ID_Productos INT not null,
Cantidad FLOAT,
Total DECIMAL(10,2),

FOREIGN KEY (ID_Clientes) REFERENCES Clientes(ID_Clientes),
FOREIGN KEY (ID_Productos) REFERENCES Productos(ID_Productos));

CREATE TABLE Detalle_de_Pedidos
(  
ID_Detalle_de_Pedidos INT IDENTITY(1,1) PRIMARY KEY not null,
ID_Pedidos INT not null,  
ID_Productos INT not null,

Cantidad INT,  FOREIGN KEY (ID_Pedidos) REFERENCES Pedidos(ID_Pedidos),
FOREIGN KEY (ID_Productos) REFERENCES Productos(ID_Productos));