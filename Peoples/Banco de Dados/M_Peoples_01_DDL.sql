CREATE DATABASE	M_Peoples;

USE M_Peoples;

CREATE TABLE Funcionarios
(
	IdFuncionario INT PRIMARY KEY IDENTITY
	,Nome VARCHAR(50) NOT NULL
	,Sobrenome VARCHAR(50) NOT NULL
	,DataNascimento DATE NOT NULL
);