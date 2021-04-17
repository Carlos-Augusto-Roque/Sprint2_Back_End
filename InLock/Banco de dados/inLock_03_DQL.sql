USE inlock_games_manha;

SELECT * FROM TiposUsuarios;

SELECT * FROM Usuarios;

SELECT * FROM Estudios;

SELECT * FROM Jogos;

SELECT Jogos.Nome AS Jogos,Estudios.Nome AS Estudio From Jogos
INNER JOIN Estudios
ON Jogos.IdEstudio = Estudios.IdEstudio;

SELECT Estudios.Nome AS Estudio,Jogos.Nome AS Jogos FROM Estudios
LEFT JOIN Jogos
ON Estudios.IdEstudio = Jogos.IdEstudio;

SELECT * FROM Usuarios WHERE Email = 'cliente@cliente.com' AND Senha = 'cliente';

SELECT * FROM Jogos WHERE IdJogo = 4;

SELECT * FROM Estudios WHERE IdEstudio = 2;

--Extra

