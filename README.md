# Web Api

- MsSql veritabanını kullanıyor. ConnectionString e WebApi projesi içerisinde application.json dan ulaşabiliriz.

- LocalDB kullanıyor.

```json
  "ConnectionStrings": {
    "WebApiDBString": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WebApi;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
  },
```

- Swagger entegresi mevcut.

```json
/swagger/index.html <br>
/swagger/v1/swagger.json
```

# Api Dökümantasyonu
## Ogrenci EndPoint

## Get Request '/ogrenci' & '/ogrenci/{id}'

Tüm öğrencilerin ya da id si verilen öğrencinin verilerini döndürür.

Response

| Element | Açıklama | Tip | Notlar |
|---- | --- | --- | --- |
| _id | Benzersiz numara | integer |  |
| isim | Öğrenci ismi | string |  |
| soyIsım | Öğrenci soyismi | string | |
| kimlikNo | Öğrenci TC | string | |
| okullar | Okuduğu okullar | array | Array içerisinde string bir şekilde okulların id lerini barındırır |
| ogretmenler | Eğitim aldığı öğretmenler | array | Array içerisinde string bir şekilde öğretmenlerin id lerini barındırır | |

## Post Request /ogrenci/

Yeni bir öğrenci ekler.

Request

| Element | Açıklama | Tip | Zorunlu | Notlar |
|---- | --- | --- | --- | --- |
| isim | Öğrenci ismi | string | Zorunlu |  |
| soyIsım | Öğrenci soyismi | string | Zorunlu | |
| kimlikNo | Öğrenci TC | string | Zorunlu | |
| okullar | Okuduğu okullar | array | Zorunlu | Array içerisinde string bir şekilde okulların id lerini barındırır |
| ogretmenler | Eğitim aldığı öğretmenler | array | Zorunlu |  Array içerisinde string bir şekilde öğretmenlerin id lerini barındırır | |

Response

| Element | Açıklama | Tip | Notlar |
|---- | --- | --- | --- |
| _id | Benzersiz numara | integer |  |
| isim | Öğrenci ismi | string |  |
| soyIsım | Öğrenci soyismi | string | |
| kimlikNo | Öğrenci TC | string | |
| okullar | Okuduğu okullar | array | Array içerisinde string bir şekilde okulların id lerini barındırır |
| ogretmenler | Eğitim aldığı öğretmenler | array | Array içerisinde string bir şekilde öğretmenlerin id lerini barındırır | |

## Ogretmen EndPoint

## Get Request '/ogretmen' & '/ogretmen/{id}'

Tüm öğretmenlerin ya da id si verilen öğretmenin verilerini döndürür.

Response

| Element | Açıklama | Tip | Notlar |
|---- | --- | --- | --- |
| _id | Benzersiz numara | integer |  |
| isim | Öğretmen ismi | string |  |
| soyIsım | Öğretmen soyismi | string | |
| kimlikNo | Öğretmen TC | string | |
| okullar | Eğitim verdiği okullar | array | Array içerisinde string bir şekilde okulların id lerini barındırır |
| ogrenciler | Eğitim verdiği öğrenciler | array | Array içerisinde string bir şekilde öğrencilerin id lerini barındırır | |

## Get Request '/ogretmen/{id}/ogrenciler'

id si alınan öğretmenin eğitim verdiği öğrencilerinin verilerini döndürür.

Response

| Element | Açıklama | Tip | Notlar |
|---- | --- | --- | --- |
| _id | Benzersiz numara | integer |  |
| isim | Öğrenci ismi | string |  |
| soyIsım | Öğrenci soyismi | string | |
| kimlikNo | Öğrenci TC | string | |
| okullar | Okuduğu okullar | array | Array içerisinde string bir şekilde okulların id lerini barındırır |
| ogretmenler | Eğitim aldığı öğretmenler | array | Array içerisinde string bir şekilde öğretmenlerin id lerini barındırır | |

## Post Request /ogretmen/

Yeni bir öğretmen ekler.

Request

| Element | Açıklama | Tip | Zorunlu | Notlar |
|---- | --- | --- | --- | --- |
| isim | Öğretmen ismi | string | Zorunlu |  |
| soyIsım | Öğretmen soyismi | string | Zorunlu | |
| kimlikNo | Öğretmen TC | string | Zorunlu | |
| okullar | Eğitim verdiği okullar | array | Zorunlu | Array içerisinde string bir şekilde okulların id lerini barındırır |
| ogrenciler | Eğitim verdiği öğrenciler | array | Zorunlu |  Array içerisinde string bir şekilde öğretmenlerin id lerini barındırır | |

Response

| Element | Açıklama | Tip | Notlar |
|---- | --- | --- | --- |
| _id | Benzersiz numara | integer |  |
| isim | Öğretmen ismi | string |  |
| soyIsım | Öğretmen soyismi | string | |
| kimlikNo | Öğretmen TC | string | |
| okullar | Eğitim verdiği okullar | array | Array içerisinde string bir şekilde okulların id lerini barındırır |
| ogrenciler | Eğitim verdiği öğrenciler | array | Array içerisinde string bir şekilde öğrencilerin id lerini barındırır | |

## Okul EndPoint

## Get Request '/okul' & '/okul/{id}'

Tüm okulların ya da id si verilen okulun verilerini döndürür.

Response

| Element | Açıklama | Tip | Notlar |
|---- | --- | --- | --- |
| _id | Benzersiz numara | integer |  |
| isim | Öğretmen ismi | string |  |
| soyIsım | Öğretmen soyismi | string | |
| kimlikNo | Öğretmen TC | string | |
| okullar | Eğitim verdiği okullar | array | Array içerisinde string bir şekilde okulların id lerini barındırır |
| ogrenciler | Eğitim verdiği öğrenciler | array | Array içerisinde string bir şekilde öğrencilerin id lerini barındırır | |

## Get Request '/okul/{id}/ogrenciler'

id si alınan öğretmenin eğitim verdiği öğrencilerinin verilerini döndürür.

Response

| Element | Açıklama | Tip | Notlar |
|---- | --- | --- | --- |
| _id | Benzersiz numara | integer |  |
| isim | Öğrenci ismi | string |  |
| soyIsım | Öğrenci soyismi | string | |
| kimlikNo | Öğrenci TC | string | |
| okullar | Okuduğu okullar | array | Array içerisinde string bir şekilde okulların id lerini barındırır |
| ogretmenler | Eğitim aldığı öğretmenler | array | Array içerisinde string bir şekilde öğretmenlerin id lerini barındırır | |

## Post Request /okul/

Yeni bir okul ekler.

Request

| Element | Açıklama | Tip | Zorunlu | Notlar |
|---- | --- | --- | --- | --- |
| ad | Okulun adı | string | Zorunlu |  |
| adres | Okul adresi | string | Zorunlu | |
| sehir | Bulunduğu il | string | Zorunlu | |
| ilce | Bulunduğu ilçe | string | Zorunlu | |
| ogrenciler | Eğitim alan öğrenciler | array | Zorunlu |  Array içerisinde string bir şekilde öğrencilerin id lerini barındırır | |

Response

| Element | Açıklama | Tip | Notlar |
|---- | --- | --- | --- |
| _id | Benzersiz numara | integer |  |
| ad | Okulun adı | string |  |
| adres | Okul adresi | string | |
| sehir | Bulunduğu il | string | |
| ilce | Bulunduğu ilçe | string | |
| ogrenciler | Eğitim alan öğrenciler | array |  Array içerisinde string bir şekilde öğrencilerin id lerini barındırır | |

## Delete Request /okul/{id}

id si verilen okulu siler

Response : boolean

## Put Request /okul/{id}

id si ve yeni verileri verilen okulu günceller.

Request

| Element | Açıklama | Tip | Zorunlu | Notlar |
|---- | --- | --- | --- | --- |
| adres | Okul adresi | string | Zorunlu | |
| sehir | Bulunduğu il | string | Zorunlu | |
| ilce | Bulunduğu ilçe | string | Zorunlu | |
| ogrenciler | Eğitim alan öğrenciler | array | Zorunlu |  Array içerisinde string bir şekilde öğrencilerin id lerini barındırır | |

Response : boolean