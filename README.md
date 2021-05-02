# *Car Rental Backend* :oncoming_automobile: :key:
---
![a+l](https://user-images.githubusercontent.com/58303745/115148240-bf865d00-a06f-11eb-8b97-ef5cfe732973.png)
---
---
## Contact Me 📫
- [![Gmail Badge](https://img.shields.io/badge/Gmail-D14836?style=for-the-badge&logo=gmail&logoColor=white)](sahilrzayev200d@gmail.com) sahilrzayev200d@gmail.com
- [![Linkedin Badge](https://img.shields.io/badge/sahilrzayev-follow%20on%20linkedin-blue?style=for-the-badge&logo=linkedin)](https://www.linkedin.com/in/sahilrzayev)
---
---
---
**Bu proje _Araba Kiralama Sistemi_ ile ilgili bir projedir.Proje hem Çok katmanlı, hem Kurumsal Mimariler, hem de SOLID prensiplerine dayalı bir projedir.Önümüzdeki süreçlerde de projeye eklemeler yapılarak daha güzel bir proje haline getirilecektir.Kampda verilen adımlara uygun olarak gerçeklekleştirdiğim bu projeyi yakından inceleyelim.**
---
---
---

# Katmanlar
* ### Öncelikle Proje 6 katmandan oluşmaktadır: Business, DataAccess, Entities, ConcoleUI, Core, WebAPI
![katmanlar](https://user-images.githubusercontent.com/58303745/115146995-0bce9e80-a06a-11eb-9373-54860d150a44.jpg)
---
### 1.<a href="https://github.com/rzayevsahil/ReCapProject/tree/master/Business" target="blank">_Business Katmanı_</a>- Burada işle ilgili(iş kuralları) kodlar yer alır.Bu katman Abstract ve Concrete isimli klasörlerden oluşur.Abstract içinde soyut(yani interfaceler), Concrete içinde somut(yani class'lar) nesneler yer alır.

![business](https://user-images.githubusercontent.com/58303745/115147010-17ba6080-a06a-11eb-8fd3-8518254dfef7.png)
* Sarı kutucuk - *NuGet paketi* --> Başkalarının yazdığı kodları(paket diyoruz) kullanıyoruz.Bu kodların ortak tutulduğu ve yönetildiği ortamın adına denir.
* Kırmızı kutucuk - Business katmanının referans aldığı katmanlar
* Yeşil kutucuk - Abstract klasörü içinde yer alan _interface'ler_
* Mavi kutucuk - Abstract klasörü içindeki interface'lerin implemente edildiği yer
---
### 2.<a href="https://github.com/rzayevsahil/ReCapProject/tree/master/DataAccess" target="blank">_DataAccess Katmanı_</a>- Veriye erişmek için gerekli kodlar yazılan bu katman Abstract(soyut) ve Concrete(somut) isimli klasörlerden oluşur.

![dataaccess](https://user-images.githubusercontent.com/58303745/115146973-f8233800-a069-11eb-82f1-4752640737db.png)
* Kırmızı kutucuk - DataAccess katmanının referans aldığı katmanlar
* Yeşil kutucuk - Abstract klasörü içinde yer alan _interface'ler_
* Mavi kutucuk - Abstract klasörü içindeki interface'lerin implemente edildiği yer.Aynı zamanda burda _IEntityFramework_ isimli klasörde biz veri tabanı nesneleriyle(kısaca tablolarla) yazdığımız kodlar arasında bağ kuruyoruz. 
> _EntityFramework_ --> Veri tabanı tablolarıyla Nesne Yönelimli Programlama(OOP) arasında bir köprüdür.
* Sarı kutucuk - *NuGet paketi* --> Başkalarının yazdığı kodları(paket diyoruz) kullanıyoruz.Bu kodların ortak tutulduğu ve yönetildiği ortamın adına denir. 
---
### 3.<a href="https://github.com/rzayevsahil/ReCapProject/tree/master/Entities" target="blank">_Entities Katmanı_</a> - Veri tabanı nesneleri için oluşturulmuş olan bu katman Abstract(soyut) ve Concrete(somut) isimli klasörlerden oluşur.
![entities](https://user-images.githubusercontent.com/58303745/115147407-e04cb380-a06b-11eb-9a47-6df5a980714f.png)
* Sarı kutucuk - *NuGet paketi* --> Başkalarının yazdığı kodları(paket diyoruz) kullanıyoruz.Bu kodların ortak tutulduğu ve yönetildiği ortamın adına denir. 
* Mavi kutucuk - Abstract klasörü içindeki interface'lerin implemente edildiği yer
---
### 4.<a href="https://github.com/rzayevsahil/ReCapProject/tree/master/ConsoleUI" target="blank">_ConsoleUI Katmanı_</a> - Yaptığımız işlemlerin sonuçlarını göreceğimiz bir katman
![consoleui](https://user-images.githubusercontent.com/58303745/115147011-1852f700-a06a-11eb-988e-51fc72e20ef9.png)
* Kırmızı kutucuk - ConsoleUI katmanının referans aldığı katmanlar
* Turuncu kutucuk - Bura main kısmıdır.Yani en sonda uyguladığımız işlemlerin sonucunu buradan görüyoruz.
---
### 5.<a href="https://github.com/rzayevsahil/ReCapProject/tree/master/Core" target="blank">_Core Katmanı_</a> - Yaptığımız işlemlerin sonuçlarını göreceğimiz bir katman
![core](https://user-images.githubusercontent.com/58303745/115147012-18eb8d80-a06a-11eb-9c94-ccb7fe4f67bd.jpg)
---
### 6.<a href="https://github.com/rzayevsahil/ReCapProject/tree/master/WebAPI" target="blank">_WebAPI Katmanı_</a> - Yaptığımız işlemlerin sonuçlarını göreceğimiz bir katman
![webapi](https://user-images.githubusercontent.com/58303745/115147008-14bf7000-a06a-11eb-9adb-e7375dc23bc3.jpg)
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








