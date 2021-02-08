Create table Brands(
	BrandId	 int Primary key,
	BrandName varchar(50)
)


Create table Colors(
	ColorId	 int Primary key,
	ColorName varchar(20)
)



Create table Cars(
	Id int Primary key identity,
	BrandId int,
	ColorId int,
	ModelYear varchar(5),
	DailyPrice decimal,
	Descriptions varchar(200),
	Foreign key(ColorId) References Colors(ColorId),
	Foreign key(BrandId) References Brands(BrandId)
)