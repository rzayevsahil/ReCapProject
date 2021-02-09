![ReCapProject](https://user-images.githubusercontent.com/58303745/107164213-7b1f7680-69c7-11eb-898d-aba8f0b66757.jpg)
---
---
---
**Bu proje _Araba Kiralama Sistemi_ ile ilgili bir projedir.Proje hem Çok katmanlı, hem Kurumsal Mimariler, hem de SOLID prensiplerine dayalı bir projedir.Önümüzdeki süreçlerde de projeye eklemeler yapılarak daha güzel bir proje haline getirilecektir.Kampda verilen adımlara uygun olarak gerçeklekleştirdiğim bu projeyi yakından inceleyelim.**
---
---
---

# Katmanlar
* ### Öncelikler Proje 4 katmandan oluşmaktadır: Business, DataAccess, Entities ve ConcoleUI
![katmanlar](https://user-images.githubusercontent.com/58303745/107296848-9ce23180-6a8b-11eb-9824-6b5cf5891a63.jpg)
---
### 1._Business Katmanı_ - Burada işle ilgili(iş kuralları) kodlar yer alır.Bu katman Abstract ve Concrete isimli klasörlerden oluşur.Abstract içinde soyut(yani interfaceler), Concrete içinde somut(yani class'lar) nesneler yer alır.
![düzenle](https://user-images.githubusercontent.com/58303745/107298645-2a735080-6a8f-11eb-9e16-550b0dffbbb3.jpg)
* Kırmızı kutucuk - Business katmanının referans aldığı katmanlar
* Yeşil kutucuk - Abstract klasörü içinde yer alan _interface'ler_
* Mavi kutucuk - Abstract klasörü içindeki interface'lerin implemente edildiği yer
---
### 2._DataAccess Katmanı_ - Veriye erişmek için gerekli kodlar yazılan bu katman Abstract(soyut) ve Concrete(somut) isimli klasörlerden oluşur.
![düzenle1](https://user-images.githubusercontent.com/58303745/107299552-1fb9bb00-6a91-11eb-935b-28a678df82d5.jpg)
* Kırmızı kutucuk - DataAccess katmanının referans aldığı katmanlar
* Yeşil kutucuk - Abstract klasörü içinde yer alan _interface'ler_
* Mavi kutucuk - Abstract klasörü içindeki interface'lerin implemente edildiği yer.Aynı zamanda burda _IEntityFramework_ isimli klasörde biz veri tabanı nesneleriyle(kısaca tablolarla) yazdığımız kodlar arasında bağ kuruyoruz. 
> _EntityFramework_ --> Veri tabanı tablolarıyla Nesne Yönelimli Programlama(OOP) arasında bir köprüdür.
* Sarı kutucuk - NuGet paketi --> Başkalarının yazdığı kodları(paket diyoruz) kullanıyoruz.Bu kodların ortak tutulduğu ve yönetildiği ortamın adına denir. 
---
### 3._Entities Katmanı_ - Veri tabanı nesneleri için oluşturulmuş olan bu katman Abstract(soyut) ve Concrete(somut) isimli klasörlerden oluşur.
![düzenle2](https://user-images.githubusercontent.com/58303745/107300410-e8e4a480-6a92-11eb-9a40-a716eb17ea92.jpg)
* Yeşil kutucuk - Abstract klasörü içinde yer alan _interface'ler_
* Mavi kutucuk - Abstract klasörü içindeki interface'lerin implemente edildiği yer
### 4._ConsoleUI Katmanı_ - Yaptığımız işlemlerin sonuçlarını göreceğimiz bir katman
![düzenle3](https://user-images.githubusercontent.com/58303745/107300886-c7d08380-6a93-11eb-9cd5-cf1a82d12cef.jpg)
* Kırmızı kutucuk - ConsoleUI katmanının referans aldığı katmanlar
* Turuncu kutucuk - Bura main kısmıdır.Yani en sonda uyguladığımız işlemlerin sonucunu buradan görüyoruz.
---
---
---
# Database and Tables
* Bir database(veri tabanı) oluşturmak için:
```
CREATE DATABASE ReCapDb
```
![1 2](https://user-images.githubusercontent.com/58303745/107301788-9a84d500-6a95-11eb-9104-823c84c307bb.jpg)
---
---

* Tabloları oluşturmak için: 
_ReCapDb --> Sağ CLick --> New Query_
```
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
	ModelYear int,
	DailyPrice decimal,
	Descriptions varchar(200),
	Foreign key(ColorId) References Colors(ColorId),
	Foreign key(BrandId) References Brands(BrandId)
)
```

_DİKKAT!!! **nvarcahr** yerine **varchar** kullanmak daha performanslı.Çünkü **varchar** kullanmadığımız karakter alanlarını boş bıraktığı halde, **nvarchar** onu boşluklarla doldurarak ekstradan bellek kaplamasına sebep oluyor_

![d1](https://user-images.githubusercontent.com/58303745/107303009-aec9d180-6a97-11eb-844d-0654e9d87005.jpg)
---
--- 
* Tabloya veri eklemek için: 
_ReCapDb --> Sağ CLick --> New Query_
```
Insert into Brands(BrandId,BrandName) values (1,'Audi'),(2,'BMW'),(3,'Hyundai'),(4,'Mitsubishi'),(5,'Nissan'),(6,'Mazda'),(7,'Porsche');

Insert into Colors(ColorId,ColorName) values (1,'Black'),(2,'White'),(3,'Silver'),(4,'Blue'),(5,'Red'),(6,'Brown'),(7,'Green');

Insert into Cars(BrandId,ColorId,ModelYear,DailyPrice,Description) values
(1,5,'2020',450,'AUDI Q8 - Red'),
(2,2,'2018',370,'BMW 2 Gran Coupé - White'),
(3,4,'2015',250,'HYUNDAI i10 - Blue'),
(4,7,'2016',290,'Mitsubishi Outlander - Green'),
(5,6,'2017',350,'NISSAN QASHQAI - Brown'),
(6,3,'2019',630,'MAZDA CX-5 - Silver'),
(7,1,'2021',720,'PORSCHE P911 Turbo S - Black');
```








