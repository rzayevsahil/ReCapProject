CREATE TABLE CarImages(
	Id int Primary key identity,
	CarId int,
	ImagePath varchar(200),
	Dates DATETIME,
	FOREIGN KEY (CarId) REFERENCES Cars(Id),

)