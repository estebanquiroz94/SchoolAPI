INSERT INTO Grade (Code, Name) 
VALUES (5, 'Quinto'),
	   (6, 'Sexto'),
	   (7, 'Septimo'),
	   (8, 'Octavo'),
	   (9, 'Noveno'),
	   (10, 'Decimo'),
	   (11, 'Once');

INSERT INTO Student(IdGrade, Name, Phone, Adress, Document)
VALUES (1,'Juan Quiroz','3127565522','Calle 50#28-85','1035431807'),
	   (1,'Melissa Agudelo','3135935241','Cra 57 # 38-220','1037631525'),
	   (3,'Mateo Diaz Restrepo','3185692541','Cra 57 # 38-222','2558789101'),
	   (4,'Mariluz Henao','3185691452','Calle 48 # 28-151','1001654120');

--Insert sin dirección, guarda dirección por defecto
INSERT INTO Student(IdGrade, Name, Document, Phone)
VALUES (4, 'Joel Quiroz','42668841','3127564271'),
	   (3, 'Julieta Diaz','1035432158','3152236985');

INSERT INTO Class(Name, Description)
VALUES ('Matemáticas','Fraccionarios, Numeros Romanos y destrucción de paréntesis'),
	   ('Ed. Fisica','Deporte a elección entre Futbol, Voley y Tenis'),
	   ('Ciencias Naturales','Fotosíntesis');

--Insert sin descripción de clase, guarda descripción por defecto
INSERT INTO Class(Name)
VALUES ('Ética y Valores'),
       ('Filosofía');

INSERT INTO Schedule(ScheduleDate, IdStudent, IdClass, Credits)
VALUES ('2024-04-19 12:00',1,1,'50'),
	   ('2024-04-19 14:30',1,5,'35'),
	   ('2024-04-19 12:00',1,2,'25'),
	   ('2024-04-19 12:00',3,1,'40'),
       ('2024-04-19 14:30',2,3,'15'),
	   ('2024-04-19 14:30',6,4,'30');

INSERT INTO Schedule(ScheduleDate, IdStudent, IdClass, Credits, Observations)
VALUES ('2024-04-20 16:00',1,3,'10','Llego 15 minutos de clase, por practicas'),
	   ('2024-04-20 12:00',3,2,'45','Llevar Uniforme y Guayos'),
	   ('2024-04-20 14:30',6,1,'45','Llevar libro Baldor');

SELECT * FROM Grade;
SELECT * FROM Student;
SELECT * FROM Class;
SELECT * FROM Schedule order by Credits;

SELECT * FROM Grade WHERE Name = 'Quinto';
SELECT * FROM Grade WHERE Code = 10;

SELECT * FROM Student WHERE Id = 6;
SELECT * FROM Student WHERE Name = 'Melissa Agudelo';

SELECT * FROM Class WHERE Id = 1;
SELECT * FROM Class WHERE Name = 'Ed. Fisica';


SELECT * FROM Schedule WHERE Credits between 15 and 30;
SELECT * FROM Schedule WHERE IdClass = 3;

UPDATE Grade SET Code = 4, Name = 'Cuarto' WHERE id = 1;
UPDATE Student SET Adress = 'Cra 57 # 50-123' WHERE Id = 1;
UPDATE Class SET Description = 'Ver película Cadena de Favores' WHERE Id = 2;
UPDATE Schedule SET Observations = 'Leer requerimientos previos' WHERE IdStudent = 1 and IdClass = 5;

DELETE FROM Grade WHERE Id = 5;
DELETE FROM Student WHERE Id = 4;
DELETE FROM Class WHERE Id = 1; /*Error integridad referencial*/
DELETE FROM Schedule WHERE IdStudent = 6; /*Elimina dos registros agendados*/

/*Inner, left Join*/
SELECT CONCAT(st.Name, ' con documento: ',st.Document, ' cursa grado: ',gr.Name )  FROM Student as st
INNER JOIN Grade as gr
ON st.IdGrade = gr.Id

SELECT *
FROM Grade as gr
LEFT OUTER JOIN Student st ON gr.Id = st.IdGrade;

/*UNION*/
SELECT Id FROM Class
UNION
SELECT IdClass FROM Schedule

/*CASE*/
SELECT *,
CASE
WHEN Credits >='45' THEN 'Tiene 20% descuento'
WHEN Credits < '45' AND Credits >= '30' THEN 'Tiene 10% descuento'
WHEN Credits <'30' THEN 'No tiene descuento'
ELSE 'N/A'
END AS Descuento
FROM Schedule