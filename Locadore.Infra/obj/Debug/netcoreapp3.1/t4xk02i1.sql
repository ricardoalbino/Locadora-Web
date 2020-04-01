CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

CREATE TABLE "Usuario" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Usuario" PRIMARY KEY,
    "Nome" varchar(100) NOT NULL,
    "Telefone" TEXT NOT NULL,
    "email" TEXT NOT NULL
);

CREATE TABLE "Filme" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Filme" PRIMARY KEY,
    "Nome" varchar(100) NOT NULL,
    "Genero" varchar(100) NOT NULL,
    "DataLançamento" DateTime NOT NULL,
    "ValorLocacao" TEXT NOT NULL,
    "UsuarioID" TEXT NOT NULL,
    CONSTRAINT "FK_Filme_Usuario_UsuarioID" FOREIGN KEY ("UsuarioID") REFERENCES "Usuario" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_Filme_UsuarioID" ON "Filme" ("UsuarioID");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20200326194108_Initial', '3.1.3');

