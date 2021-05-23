CREATE DATABASE SP_Medical_Group;

USE SP_Medical_Group;

CREATE TABLE TiposUsuarios
(
	IdTipoUsuario INT PRIMARY KEY IDENTITY
	,TituloTipoUsuario VARCHAR(100) UNIQUE NOT NULL
);
GO

CREATE TABLE Usuarios
(
	IdUsuario INT PRIMARY KEY IDENTITY
	,IdTipoUsuario INT FOREIGN KEY REFERENCES TiposUsuarios(IdTipoUsuario) 
	,Email VARCHAR(200) UNIQUE NOT NULL
	,Senha VARCHAR(200) NOT NULL
);
GO

CREATE TABLE Pacientes
(
	IdPaciente INT PRIMARY KEY IDENTITY
	,IdUsuario INT FOREIGN KEY REFERENCES Usuarios(IdUsuario)
	,NomePaciente VARCHAR(150) NOT NULL
	,RG CHAR(9) UNIQUE NOT NULL
	,CPF CHAR(11) UNIQUE NOT NULL
	,DataNascimento DATE NOT NULL
	,Telefone VARCHAR(50) UNIQUE NOT NULL
	,Endereco VARCHAR(200) NOT NULL
);
GO

CREATE TABLE Especialidades
(
	IdEspecialidade INT PRIMARY KEY IDENTITY
	,DescricaoEspecialidade VARCHAR(150) NOT NULL
);
GO

CREATE TABLE Clinicas
(
	IdClinica INT PRIMARY KEY IDENTITY
	,RazaoSocial VARCHAR(150) UNIQUE NOT NULL
	,NomeFantasia VARCHAR(150) NOT NULL
	,Endereco VARCHAR(250) UNIQUE NOT NULL
	,HorarioAbertura TIME NOT NULL
	,HorarioFechamento TIME NOT NULL
	,[Site] VARCHAR(150) UNIQUE NOT NULL
	,CNPJ CHAR(14) UNIQUE NOT NULL
);
GO

CREATE TABLE Medicos
(
	IdMedico INT PRIMARY KEY IDENTITY
	,IdUsuario INT FOREIGN KEY REFERENCES Usuarios(IdUsuario)
	,IdClinica INT FOREIGN KEY REFERENCES Clinicas(IdClinica)
	,IdEspecialidade INT FOREIGN KEY REFERENCES Especialidades(IdEspecialidade)
	,NomeMedico VARCHAR(150) NOT NULL
	,CRM VARCHAR(100) UNIQUE NOT NULL
);
GO

CREATE TABLE StatusConsultas
(
	IdStatusConsulta INT PRIMARY KEY IDENTITY
	,DescricaoStatusConsulta VARCHAR(50) NOT NULL
);
GO

CREATE TABLE Consultas
(
	IdConsulta INT PRIMARY KEY IDENTITY
	,IdPaciente INT FOREIGN KEY REFERENCES Pacientes(IdPaciente)
	,IdMedico INT FOREIGN KEY REFERENCES Medicos(IdMedico)
	,IdStatusConsulta INT FOREIGN KEY REFERENCES StatusConsultas(IdStatusConsulta)
	,DataConsulta DATE NOT NULL
	,HorarioConsulta TIME NOT NULL
	,DescricaoAtendimento VARCHAR(255) NOT NULL
);
GO

--criar função para retornar a quantidade de médicos de uma determinada especialidade
CREATE FUNCTION Q_Med_Esp (@especialidade VARCHAR(50))
RETURNS INT 
AS
	BEGIN
			DECLARE @Q_Med_Esp INT
			SELECT @Q_Med_Esp = COUNT(IdMedico)
			FROM Medicos
			INNER JOIN Especialidades
			ON Especialidades.IdEspecialidade = Medicos.IdEspecialidade AND DescricaoEspecialidade = @especialidade;
	RETURN @Q_Med_Esp
END
GO

--criar função para retornar a idade do usuário a partir de uma determinada procedure
CREATE PROCEDURE Idade(@nome VARCHAR (100))
AS
	DECLARE @Idade INT
	SELECT DATEDIFF(YEAR,DataNascimento, GETDATE()) AS Idade
	FROM Pacientes
	WHERE Pacientes.NomePaciente = @nome;
GO