USE M_Peoples;

SELECT * FROM Funcionarios;

SELECT IdFuncionario,Nome,Sobrenome,DataNascimento  FROM Funcionarios;

SELECT IdFuncionario,Nome,Sobrenome,DataNascimento FROM Funcionarios WHERE Nome = 'Tiago';

SELECT Nome  FROM Funcionarios ORDER BY Nome ASC;

SELECT Nome  FROM Funcionarios ORDER BY Nome DESC;

SELECT CONCAT(Nome,' ',Sobrenome) AS [Nome Completo] FROM Funcionarios;

SELECT * FROM TiposUsuarios;

SELECT * FROM Usuarios;

