USE SP_Medical_Group;

INSERT INTO TiposUsuarios(TituloTipoUsuario)
VALUES ('Administrador')
	  ,('Paciente')
	  ,('Médico');

INSERT INTO Usuarios(IdTipoUsuario,Email,Senha)
VALUES (3,'ricardo.lemos@spmedicalgroup.com.br','1234')
      ,(3,'roberto.possarle@spmedicalgroup.com.br','3214')
	  ,(3,'helena.souza@spmedicalgroup.com.br','1235')
	  ,(2,'ligia@gmail.com','1478')
	  ,(2,'alexandre@gmail.com','2145')
	  ,(2,'fernando@gmail.com','6548')
	  ,(2,'henrique@gmail.com','5528')
	  ,(2,'joao@hotmail.com','3256')
	  ,(2,'bruno@gmail.com','2254')
	  ,(2,'mariana@outlook.com','1425');

INSERT INTO Pacientes(IdUsuario,NomePaciente,RG,CPF,DataNascimento,Telefone,Endereco)
VALUES (4,'Ligia','435225435','94839859000','13/10/1983','1134567654','Rua Estado de Israel 240, São Paulo, Estado de São Paulo, 04022-000')
      ,(5,'Alexandre','326543457','73556944057','23/07/2001','11987656543','Av. Paulista, 1578 - Bela Vista, São Paulo - SP, 01310-200')
	  ,(6,'Fernado','546365253','16839338002','10/10/1978','11972084453','Av. Ibirapuera - Indianópolis, 2927,  São Paulo - SP, 04029-200')
	  ,(7,'Henrique','543663625','14332654765','13/10/1985','1134566543','R. Vitória, 120 - Vila Sao Jorge, Barueri - SP, 06402-030')
	  ,(8,'João','325444441','91305348010','27/08/1975','1176566377','R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeirão Pires - SP, 09405-380')
	  ,(9,'Bruno','545662667','79799299004','21/03/1972','11954368769','Alameda dos Arapanés, 945 - Indianópolis, São Paulo - SP, 04524-001')
	  ,(10,'Mariana','545662668','13771913039','05/03/2018','','R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140');

INSERT INTO Especialidades(DescricaoEspecialidade)
VALUES ('Acupuntura')
      ,('Anestesiologia')
	  ,('Angiologia')
	  ,('Cardiologia')
	  ,('Cirurgia Cardiovascular')
	  ,('Cirurgia da Mão')
	  ,('Cirurgia do Aparelho Digestivo')
	  ,('Cirurgia Geral')
	  ,('Cirurgia Pediátrica')
	  ,('Cirurgia Plástica')
	  ,('Cirurgia Torácica')
	  ,('Cirurgia Vascular')
	  ,('Dermatologia')
	  ,('Radioterapia')
	  ,('Urologia')
	  ,('Pediatria')
	  ,('Psiquiatria');

INSERT INTO Clinicas(RazaoSocial,NomeFantasia,Endereco,HorarioAbertura,HorarioFechamento,[Site],CNPJ)
VALUES ('SP Medical Group','Clinica Possarle','Av. Barão Limeira, 532, São Paulo, SP','08:00','18:00','possarle.com.br','86400902000130');

INSERT INTO Medicos(IdUsuario,IdClinica,IdEspecialidade,NomeMedico,CRM)
VALUES (1,1,2,'Ricardo Lemos','54356-SP')
      ,(2,1,17,'Roberto Possarle','53452-SP')
	  ,(3,1,16,'Helena Strada','65463-SP');

INSERT INTO StatusConsultas(DescricaoStatusConsulta)
VALUES ('Agendada')
      ,('Cancelada')
	  ,('Realizada');

INSERT INTO Consultas(IdPaciente,IdMedico,IdStatusConsulta,DataConsulta,HorarioConsulta,DescricaoAtendimento)
VALUES (1,3,3,'20/01/2020','15:00','')
      ,(1,2,2,'06/01/2020','10:00','')
	  ,(3,2,3,'07/02/2020','11:00','')
	  ,(3,2,3,'06/02/2018','10:00','')
	  ,(5,1,2,'07/02/2019','11:00','')
	  ,(6,3,1,'08/03/2020','15:00','')
	  ,(7,1,1,'09/03/2020','11:00','');