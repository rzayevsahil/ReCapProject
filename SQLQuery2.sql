INSERT INTO Users(FirstName,LastName,Email,Password) VALUES 
	('Engin','Demiroğ','engindemirog@gmail.com','123456'),
	('Sahil','Rzayev','sahilrzayev@gmail.com','010203'),
	('Selim','Öztürk','selimozturk@gmail.com','selim123'),
	('Emre','Babacan','emrebabacan@gmail.com','babacan061'),
	('Fariz','Türkoğlu','farizturkoglu@gmail.com','fariz1988');


INSERT INTO Customers(UserId,CompanyName) VALUES 
	(1,'Audi Otomobil'),
	(2,'Hyundai Otomobil'),
	(3,'Bmw Otomobil'),
	(4,'Nissan Otomobil'),
	(5,'Cars otomobil');


INSERT INTO Rentals(CarId,CustomerId,RentDate,ReturnDate) VALUES 
(1,1,'2020-12-29 15:00:01','2021-01-05 16:16:05'),
(2,2,'2020-12-30 10:34:09',null),
(3,3,'2020-01-14 14:39:23','2020-01-20 12:02:48'),
(4,4,'2015-11-05 17:45:53',null),
(5,5,'2021-01-12 11:12:38','2021-01-16 18:01:41');
	