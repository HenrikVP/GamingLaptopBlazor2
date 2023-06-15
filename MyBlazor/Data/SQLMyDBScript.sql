USE MyDB
GO
DROP TABLE GamingLaptop
GO
CREATE TABLE GamingLaptop (
Id INT IDENTITY(1,1) PRIMARY KEY,
[Name] NVARCHAR(MAX),
Brand NVARCHAR(MAX),
RAM INT,
GPU NVARCHAR(MAX),
CPU NVARCHAR(MAX),
Price FLOAT
)

INSERT INTO GamingLaptop VALUES('Raider GE78 HX', 'MSI', 32, '4090',' Intel® Core™ i9-13980HX', 39995)
/*
        public string Name { get; set; }
        public string Brand { get; set; }
        public int RAM { get; set; }
        public string GPU { get; set; }
        public string CPU { get; set; }
        public double Price { get; set; }
        */