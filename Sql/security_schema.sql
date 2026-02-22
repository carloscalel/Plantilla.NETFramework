-- Seguridad por usuario de dominio y permisos por vista/acción
CREATE TABLE Seg_Rol (
    Id INT IDENTITY PRIMARY KEY,
    Codigo NVARCHAR(100) NOT NULL UNIQUE,
    Nombre NVARCHAR(200) NOT NULL,
    Activo BIT NOT NULL DEFAULT 1
);

CREATE TABLE Seg_Permiso (
    Id INT IDENTITY PRIMARY KEY,
    Codigo NVARCHAR(150) NOT NULL UNIQUE, -- CLIENTE_VER, CLIENTE_EDITAR, etc.
    Nombre NVARCHAR(200) NOT NULL,
    Controlador NVARCHAR(100) NOT NULL,
    Accion NVARCHAR(100) NOT NULL,
    Activo BIT NOT NULL DEFAULT 1
);

CREATE TABLE Seg_RolPermiso (
    RolId INT NOT NULL,
    PermisoId INT NOT NULL,
    PRIMARY KEY (RolId, PermisoId),
    CONSTRAINT FK_SegRolPermiso_Rol FOREIGN KEY (RolId) REFERENCES Seg_Rol(Id),
    CONSTRAINT FK_SegRolPermiso_Permiso FOREIGN KEY (PermisoId) REFERENCES Seg_Permiso(Id)
);

CREATE TABLE Seg_UsuarioDominio (
    Id INT IDENTITY PRIMARY KEY,
    UsuarioDominio NVARCHAR(150) NOT NULL, -- DOMINIO\\usuario
    NombreCompleto NVARCHAR(200) NULL,
    Correo NVARCHAR(200) NULL,
    Activo BIT NOT NULL DEFAULT 1,
    UNIQUE (UsuarioDominio)
);

CREATE TABLE Seg_UsuarioRol (
    UsuarioId INT NOT NULL,
    RolId INT NOT NULL,
    PRIMARY KEY (UsuarioId, RolId),
    CONSTRAINT FK_SegUsuarioRol_Usuario FOREIGN KEY (UsuarioId) REFERENCES Seg_UsuarioDominio(Id),
    CONSTRAINT FK_SegUsuarioRol_Rol FOREIGN KEY (RolId) REFERENCES Seg_Rol(Id)
);

CREATE TABLE Audit_Crud (
    Id BIGINT IDENTITY PRIMARY KEY,
    Entidad NVARCHAR(120) NOT NULL,
    Operacion NVARCHAR(50) NOT NULL,
    ClaveRegistro NVARCHAR(100) NULL,
    ValoresAnteriores NVARCHAR(MAX) NULL,
    ValoresNuevos NVARCHAR(MAX) NULL,
    UsuarioDominio NVARCHAR(150) NOT NULL,
    Fecha DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    Ip NVARCHAR(45) NULL
);

CREATE TABLE Log_Aplicacion (
    Id BIGINT IDENTITY PRIMARY KEY,
    Nivel NVARCHAR(20) NOT NULL,
    Mensaje NVARCHAR(1000) NOT NULL,
    Detalle NVARCHAR(MAX) NULL,
    UsuarioDominio NVARCHAR(150) NULL,
    Fecha DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);

-- permisos base para Clientes
INSERT INTO Seg_Permiso (Codigo, Nombre, Controlador, Accion)
VALUES
('CLIENTE_VER', 'Ver clientes', 'Clientes', 'Index'),
('CLIENTE_CREAR', 'Crear clientes', 'Clientes', 'Create'),
('CLIENTE_EDITAR', 'Editar clientes', 'Clientes', 'Edit'),
('CLIENTE_ELIMINAR', 'Eliminar clientes', 'Clientes', 'Delete');
