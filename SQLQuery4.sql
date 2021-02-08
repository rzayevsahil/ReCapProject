Create table Cars(
	Id int Primary key identity,
	BrandId int,
	ColorId int,
	ModelYear varchar(5),
	DailyPrice decimal,
	Description text,
	Foreign key(ColorId) References Colors(ColorId),
	Foreign key(BrandId) References Brands(BrandId)
)