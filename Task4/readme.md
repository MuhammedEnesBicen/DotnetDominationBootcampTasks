## Task 4 29.12.2023

Bu derste
- EF Core join işlemleri anlatıldı
- one - many ve many - many ilişkileri işlendi.

- "A possible object cycle was detected" hatası sonrası olası çözümler anlatıldı


A possible object cycle was detected. Hatası çözümü için startup.cs dosyasına aşağıdaki kodu ekleyin.

``` csharp
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
```

Ders görevi olarak WebUsers tablosu ile Orders tablosu many-many ilişkisi ile joinlenmesi istendi.
İşlem gerçekleştirildikten sonra sonuç aşağıdaki gibi oldu:
``` csharp
``` JSON
[
  {
    "email": "test",
    "adress": "adres",
    "phone": "123",
    "orders": [
      {
        "orderNumber": 1,
        "totalPrice": 12,
        "webUsers": [
          null
        ],
        "id": 1,
        "dateAdded": "2023-11-11T00:00:00",
        "dateModified": "2023-12-12T00:00:00"
      },
      {
        "orderNumber": 2,
        "totalPrice": 123,
        "webUsers": [
          null
        ],
        "id": 2,
        "dateAdded": "2023-11-12T00:00:00",
        "dateModified": "2023-11-12T00:00:00"
      }
    ],
    "id": 2,
    "dateAdded": "2023-11-11T00:00:00",
    "dateModified": "2023-12-23T00:00:00"
  }
]
```