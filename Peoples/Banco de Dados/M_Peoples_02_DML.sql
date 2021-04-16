USE M_Peoples;

INSERT INTO Funcionarios(Nome,Sobrenome,DataNascimento)
VALUES ('Catarina','Strada','10/05/1975')
	  ,('Tadeu','Vitelli','25/08/1980')
	  ,('Carlos Augusto','Roque','22/01/1987')
	  ,('Saulo','Santos','03/04/1990')
	  ,('Caique','Zaneti','08/06/1992');

INSERT INTO TiposUsuarios(Descricao)
VALUES ('Comum'),('Administrador');

INSERT INTO Usuarios(IdTipoUsuario,Email,Senha)
VALUES (1,'comum@comum.com','1234'),(2,'adm@adm.com','1234');

