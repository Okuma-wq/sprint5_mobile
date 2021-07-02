USE Roman;

INSERT INTO TipoUsuario		(Tipo)
VALUES						('Administrador')
							,('Professor');

INSERT INTO Usuario			(Email, Senha, idTipo)
VALUES						('saulo@email.com', 'saulo123', 2)
							,('caique@email.com', 'caique123', 2)
							,('tsuka@email.com', 'tsuka123', 2);

INSERT INTO Equipe			(Equipe)
VALUES						('Desenvolvimento')
							,('Redes de Computadores')
							,('Multimídia');

INSERT INTO Professor		(Nome, idUsuario, idEquipe)
VALUES						('Saulo', 1, 1)
							,('Caique', 2, 1)
							,('Tsuka', 3, 3);

INSERT INTO Projeto			(Projeto, idProfessor)
VALUES						('Controle de Estoque', 1)
							,('Listagem de Personagens', 2);

INSERT INTO Tema			(Tema)
VALUES						('Gestão')
							,('HQs');

INSERT INTO ProjetoTema		(idProjeto, idTema)
VALUES						(1, 1)
							,(2, 2);