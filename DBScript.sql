USE PackagesRegistry;
GO


CREATE TABLE TransportCompanies(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Name vARCHAR(30)
);

CREATE TABLE Drivers(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	CompanyId INT,

	FOREIGN KEY (CompanyId) REFERENCES TransportCompanies(Id)
);

CREATE TABLE Clients(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Name VARCHAR(30),
	DocumentId INT,
	BirthDate VARCHAR(10)
);

CREATE TABLE PackagesInCustody(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	DriverId INT, 
	TrackingId VARCHAR(18), 
	Description VARCHAR(100),
	Weight FLOAT,
	Price FLOAT,
	ClientId INT,
	Date VARCHAR(10),
	
	FOREIGN KEY (DriverId) REFERENCES Drivers(Id),
	FOREIGN KEY (ClientId) REFERENCES Clients(Id)
);

CREATE TABLE PackagesRetired(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	DriverId INT, 
	TrackingId VARCHAR(18), 
	Description VARCHAR(100),
	ClientId INT,
	ReiredDate VARCHAR(10),

	FOREIGN KEY (DriverId) REFERENCES Drivers(Id),
	FOREIGN KEY (ClientId) REFERENCES Clients(Id)
);