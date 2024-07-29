CREATE TABLE Universities (
    Id INT PRIMARY KEY AUTO_INCREMENTL,
    NameUniversity VARCHAR(100)
    );
    
CREATE TABLE Professors (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    NameProfessor VARCHAR(55),
    LastNameProfessor VARCHAR(45),
    PhoneProfessor VARCHAR(45),
    EmailProfessor VARCHAR(100)
    );

CREATE TABLE ProfessorsHasUniversities ( 
   ProfessorId int not null, 
   UniversityId int not null, 
   FOREIGN KEY (ProfessorId) REFERENCES Professors(Id), 
   FOREIGN KEY (UniversityId) REFERENCES Universities(Id)
);

CREATE TABLE UniversityDeans (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    NameDean VARCHAR(45),
    UniversityId int,
    FOREIGN KEY (UniversityId) REFERENCES Universities(Id)
  );

CREATE TABLE Careers (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    NameCareer VARCHAR(45) ,
  );

CREATE TABLE UniversitiesHasCareers ( 
   UniversityId int not null,
   CareerId int not null, 
   FOREIGN KEY (UniversityId) REFERENCES Universities(Id),
   FOREIGN KEY (CareerId) REFERENCES Careers(Id)
);

CREATE TABLE Subjets ( 
   Id INT PRIMARY KEY AUTO_INCREMENT, 
   NameSubjets varchar(70) 
);


CREATE TABLE CareersHasSubjets ( 
   SubjetId int not null,
   CareerId int not null, 
   FOREIGN KEY (SubjetId) REFERENCES Subjets(Id),
   FOREIGN KEY (CareerId) REFERENCES Careers(Id)
);

CREATE TABLE SubjetsHasProfessors ( 
   SubjetId int not null, 
   ProfessorId int not null, 
   FOREIGN KEY (SubjetId) REFERENCES Subjets(Id), 
   FOREIGN KEY (ProfessorId) REFERENCES Professors(Id) 
);

CREATE TABLE Semesters ( 
   Id INT PRIMARY KEY AUTO_INCREMENT, 
   NameSemester varchar(45)

);	

CREATE TABLE Inscriptions ( 
   Id INT PRIMARY KEY AUTO_INCREMENT, 
   Status varchar(45),
   SemesterId int,
   FOREIGN KEY (SemesterId) REFERENCES Semesters(Id)
);

CREATE TABLE Students ( 
   Id INT PRIMARY KEY AUTO_INCREMENT, 
   NameStudent varchar(45),
   lastNameStudent int,
   EmailStudent  varchar(45),
   PhoneStudent varchar(45),
   SemesterId int,
   FOREIGN KEY (SemesterId) REFERENCES Semesters(Id)
);

CREATE TABLE UniversitiesHasStudents ( 
   UniversityId int not null, 
   StudentId int not null, 
   FOREIGN KEY (UniversityId) REFERENCES Universities(Id), 
   FOREIGN KEY (StudentId) REFERENCES Students(Id) 
);

CREATE TABLE SubjetsHasInscriptions ( 
   SubjetId int not null, 
   InscriptionId int not null, 
   FOREIGN KEY (SubjetId) REFERENCES Subjets(Id), 
   FOREIGN KEY (InscriptionId) REFERENCES Inscriptions(Id) 
);