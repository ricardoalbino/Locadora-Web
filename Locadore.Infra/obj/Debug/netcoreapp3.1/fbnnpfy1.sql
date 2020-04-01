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

CREATE TABLE "Locacao" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Locacao" PRIMARY KEY,
    "DataLocacao" DateTime NOT NULL,
    "DataDevolucao" DateTime NOT NULL,
    "UsuarioID" UsuarioID NOT NULL,
    "UsuarioId" TEXT NULL,
    "FilmeID" FilmeID NOT NULL,
    CONSTRAINT "FK_Locacao_Usuario_UsuarioId" FOREIGN KEY ("UsuarioId") REFERENCES "Usuario" ("Id") ON DELETE RESTRICT
);

CREATE TABLE "Filme" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Filme" PRIMARY KEY,
    "Nome" varchar(100) NOT NULL,
    "Genero" varchar(100) NOT NULL,
    "DataLançamento" DateTime NOT NULL,
    "ValorLocacao" TEXT NOT NULL,
    "LocacaoId" TEXT NULL,
    CONSTRAINT "FK_Filme_Locacao_LocacaoId" FOREIGN KEY ("LocacaoId") REFERENCES "Locacao" ("Id") ON DELETE RESTRICT
);

CREATE INDEX "IX_Filme_LocacaoId" ON "Filme" ("LocacaoId");

CREATE INDEX "IX_Locacao_UsuarioId" ON "Locacao" ("UsuarioId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20200329164854_Initial', '3.1.3');

