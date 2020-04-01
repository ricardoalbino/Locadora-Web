CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

CREATE TABLE "Filme" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Filme" PRIMARY KEY,
    "Nome" varchar(100) NOT NULL,
    "Genero" varchar(100) NOT NULL,
    "DataLançamento" DateTime NOT NULL,
    "ValorLocacao" TEXT NOT NULL
);

CREATE TABLE "Usuario" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Usuario" PRIMARY KEY,
    "Nome" varchar(100) NOT NULL,
    "Telefone" TEXT NOT NULL,
    "email" TEXT NOT NULL
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20200329170544_Initial', '3.1.3');

