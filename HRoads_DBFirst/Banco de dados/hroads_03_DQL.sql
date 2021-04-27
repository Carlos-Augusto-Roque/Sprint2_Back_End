USE SENAI_HROADS_MANHA;

SELECT * FROM Classes;
SELECT * FROM Personagens;
SELECT * FROM TiposDeHabilidades;
SELECT * FROM Habilidades;
SELECT * FROM Classes_Habilidades;

--Selecionar todos os personagens
SELECT * FROM Personagens;

--Selecionar todos as classes
SELECT * FROM Classes

--Selecionar somente o nome das classes
SELECT Classes.Nome AS NomeDasClasses FROM Classes;

--Selecionar todas as habilidades
SELECT * FROM Habilidades;

--Realizar a contagem de quantas habilidades estão cadastradas
SELECT COUNT(IdHabilidade) AS QuantidadeDeHabilidades FROM Habilidades;

--Selecionar somente os id’s das habilidades classificando-os por ordem crescente
SELECT Habilidades.IdHabilidade FROM Habilidades 
ORDER BY IdHabilidade;

--Selecionar todos os tipos de habilidades
SELECT * FROM TiposDeHabilidades;

--Selecionar todas as habilidades e a quais tipos de habilidades elas fazem parte
SELECT Habilidades.IdHabilidade,Habilidades.IdTipoHabilidade, Habilidades.Nome AS Habilidade,TiposDeHabilidades.Nome AS TipoHabilidade FROM Habilidades
INNER JOIN TiposDeHabilidades
ON Habilidades.IdTipoHabilidade = TiposDeHabilidades.IdTipoHabilidade;

--Selecionar todos os personagens e suas respectivas classes;
SELECT Personagens.Nome AS Personagem,Classes.Nome AS Classe FROM Personagens
INNER JOIN Classes
ON Personagens.IdClasse = Classes.IdClasse;

--Selecionar todos os personagens e as classes (mesmo que elas não tenham correspondência em personagens)
SELECT * FROM Personagens
RIGHT JOIN Classes
ON Personagens.IdClasse = Classes.IdClasse;

--Selecionar todas as classes e suas respectivas habilidades
SELECT Classes.Nome AS NomeClasse, Habilidades.Nome AS Habilidade FROM Classes
INNER JOIN Classes_Habilidades
ON Classes.IdClasse = Classes_Habilidades.IdClasse
INNER JOIN Habilidades
ON Habilidades.IdTipoHabilidade = Classes_Habilidades.IdHabilidade;

--Selecionar todas as habilidades e suas classes (somente as que possuem correspondência)
SELECT Habilidades.Nome AS Habilidade,Classes.Nome AS Classe FROM Habilidades
INNER JOIN Classes_Habilidades
ON Habilidades.IdHabilidade = Classes_Habilidades.IdHabilidade
INNER JOIN Classes
ON Classes_Habilidades.IdClasse = Classes.IdClasse;

--Selecionar todas as habilidades e suas classes (mesmo que elas não tenham correspondência)
SELECT Habilidades.Nome AS Habilidade, Classes.Nome AS Classe FROM Habilidades
LEFT JOIN Classes_Habilidades
ON Habilidades.IdHabilidade = Classes_Habilidades.IdHabilidade
RIGHT JOIN Classes
ON Classes_Habilidades.IdClasse = Classes.IdClasse;

SELECT * FROM TiposUsuarios;

SELECT * FROM Usuarios;

