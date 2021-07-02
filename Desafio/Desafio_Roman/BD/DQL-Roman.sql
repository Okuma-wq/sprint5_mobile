USE Roman;

SELECT * FROM Usuario;

SELECT * FROM Professor;

SELECT * FROM Projeto;

SELECT * FROM Tema;

SELECT Professor.Nome, Equipe.Equipe, Projeto.Projeto, Tema.Tema FROM  Professor
INNER JOIN Equipe
ON Professor.idEquipe = Equipe.idEquipe
LEFT JOIN Projeto
ON Professor.idProfessor = Projeto.idProfessor
INNER JOIN ProjetoTema
ON Projeto.idProjeto = ProjetoTema.idProjeto
INNER JOIN Tema
ON Tema.idTema = ProjetoTema.idTema;