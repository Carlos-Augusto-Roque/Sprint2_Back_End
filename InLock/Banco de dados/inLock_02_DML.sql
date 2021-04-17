USE inlock_games_manha;
GO

INSERT INTO Estudios(Nome)
VALUES ('Blizzard'),('Rockstar Studios'),('Square Enix');
GO

INSERT INTO Jogos(IdEstudio,Nome,Descricao,DataLancamento,Valor)
VALUES (1,'Diablo 3','É um jogo que contém bastante ação e é viciante, seja você um novato ou um fã.','15/05/2012','99')
	  ,(2,'Red Dead Redemption II','Jogo eletrônico de ação-aventura western.','26/10/2018','120');
GO

INSERT INTO TiposUsuarios(Titulo)
VALUES ('Comum'),('Administrador');
GO

INSERT INTO Usuarios(IdTipoUsuario,Email,Senha)
VALUES (1,'cliente@cliente.com','cliente')
      ,(2,'admin@admin.com','admin');
GO

