
# Basarsoft Stajyerlik Projesi 

**08/2024 - 09/2024 tarihleri arasında Başarsoft Bilgi Teknolojileri (www.basarsoft.com.tr) şirketinde tamamlamış olduğum stajımın api kodlarının bulunduğu yerdesiniz.**

Bu api sayesinde önyüzde kullandığımız openlayers kütüphanesi sayesinde veritabanında kayıtlı halde bulunan WKT(Well Known Text) formatında bulunan stringi haritamızda nokta(point), çizgi(line) ve alan(polygon) şekilinde gösterebilmemiz için gerekli backend kodlarını içermektedir.

Projede Asp.Net v8.0 Web API, Entity Framework, PostgreSQL teknolojileri kullanılmıştır.

Projemizde .NET Core-Generic Repository & Unit Of Work Patternleri uygulanmıştır.

Projemizin ihtiyacı doğrultusunda Modül bazlı veya ufak çaplı projelerde ve CRUD (Create, Read, Update, Delete) operasyonlarının gerçekleştirilmesi amacıyla kullanılmıştır. Geliştirme yaparken CRUD işlemlerini her bir repository için ayrı ayrı tasarlamak maliyet açısından ve yönetilebilirlik açısından bir noktadan sonra yoracağından tek bir yapı sayesinde her bir varlık için tek bir yapı geliştirmemizi kolaylaştırmıştır.

Unit of Work ise projemizde veritabanı ile yapılacak bütün işlemleri tek bir yerden yönetmemizi ve entegre etmemizi sağladı. Bize sağladığı bir diğer avantaj dependency Injection aşamalarında Unit Of Work üzerinden tek bir inject ile istediğimiz repoya erişimi sağlayıp ve yönetmesidir.
![App Screenshot](https://miro.medium.com/v2/resize:fit:700/1*7lgfF9RbjbfN1jiQG5jQ6w.png)

Projemize dönecek olursak sadece noktalarla başladığımız API kodlarını son 2 hafta boyunca WKT formatına çevirdik. Önce PointController ve PointService kodlarını yazıp gerekli testleri gerçekleştirdim. Ardından Generic Repository ve Unit of Work kullanımı için gerekli serviceleri yazdım. Bunların gerekli testlerini yaptıktan sonra WKT formatı için gerekli WktController kodlarını yazdım. Swagger UI kullanarak yaptığım testler sonucunda PostgreSQL ve API arasında bağlantımın ve gereken tüm işlerin sorunsuz çalıştığı test edilmiştir. 

Ayrıca projemde bir status code ve messagelar için bir response modeli oluşturdum bu model herhangi bir mesaj için gerekli modeldir. Kullanım örneği aşağıdaki gibidir.

```
  var response = new Response<Wkt>(201, "Wkt created successfully", createdWkt);
```
WKT, bir koordinat sisteminin gerekli tüm parametrelerini tanımlayan bir dizedir. Aşağıda örnek wkt stringler bulunmaktadır.
```
POINT (0 0)
POINT EMPTY
LINESTRING (0 0, 0 1, 1 2)
LINESTRING EMPTY
POLYGON ((0 0, 1 0, 1 1, 0 1, 0 0))
POLYGON ((0 0, 4 0, 4 4, 0 4, 0 0), (1 1, 1 2, 2 2, 2 1, 1 1))
POLYGON EMPTY
```

Aşağıda da kullanıma hazır API Reference'larını detaylı bir şekilde gösterebilirsiniz.



## API Reference

#### Get all items

```http
  GET /api/Wkt
```

| Parameter | Type     | Description                          |
| :-------- | :------- | :----------------------------------- |
| `id`      | `int`    | **Required**.                        |
|`wktString`| `string` | **nullable**. For WKT format         |
| `name`    | `string` | **nullable**. For each feature names |
#### Get item

```http
  GET /api/Wkt/${id}
```
| Parameter | Type     | Description                          |
| :-------- | :------- | :----------------------------------- |
| `id`      | `int`    | **Required**.                        |
|`wktString`| `string` | **nullable**. For WKT format         |
| `name`    | `string` | **nullable**. For each feature names |

```http
  PUT /api/Wkt/${id}
```
| Parameter | Type     | Description                          |
| :-------- | :------- | :----------------------------------- |
| `id`      | `int`    | **Required**.                        |
|`wktString`| `string` | **nullable**. For WKT format         |
| `name`    | `string` | **nullable**. For each feature names |

```http
  DELETE /api/Wkt/${id}
```
| Parameter | Type     | Description                          |
| :-------- | :------- | :----------------------------------- |
| `id`      | `int`    | **Required**.                        |
|`wktString`| `string` | **nullable**. For WKT format         |
| `name`    | `string` | **nullable**. For each feature names |




