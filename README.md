# Final_Case

TEMP - Rollere ait önceden tanımlı hesaplardan JWT almaya yarar.
{Get} https://localhost:7134/api/Temp/{RoleName}
Örnek : https://localhost:7134/api/Temp/Admin
Cevap : eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJjYTcwMTIwNi1lMDc1LTQxOTEtYTRkMy1iYmYyODE0NzgzODMiLCJyb2xlIjoiQWRtaW4iLCJuYmYiOjE3MDQ4NDQ1ODMsImV4cCI6MTcwNDg0NTQ4MywiaWF0IjoxNzA0ODQ0NTgzLCJpc3MiOiJmYTQ4OTdlN2I2ODFmNjkwNTRmYjI3ODljMzMxMjkyYWM4Yzc2Nzg2IiwiYXVkIjoiMTFlOTU4MGM4YjIzZjEyNmQ0OGZkNzcwZGVjYWQzZTVmYzZhNWEyNyJ9.Jjb1X6ycCm3Bs3A48MyLkHjGNEt3L3mXe8kN6L98Gn0

SignUp - Kayıt işlemlerini yönetir. Sistem ön kayıt ile çalışır. İçeride kayıtlı bir yetkili onayladıktan sonra hesap aktif olur.
{Get} https://localhost:7134/api/tosunbank/v1/SignUps - Tüm kayıt isteklerini gösterir. Yetkili kişiler erişebilir.
{Post} https://localhost:7134/api/tosunbank/v1/SignUps - Gövdeden veriyi alır. Kayıt isteği oluşturur. Herkese açıktır. FluentValidation ile veri kontrolü yapılır. Veri yapısı:
{
  "email": "mail@mail.com",
  "firstName": "Müşteri",
  "lastName": "Bir",
  "password": "Abcd1234*",
  "address": "İstanbul, Turkey",
  "phoneNumber": "05012345678",
  "nationalityNumber": "12345678900",
  "birthDay": "01.01.2000"
}
{Get} https://localhost:7134/api/tosunbank/v1/SignUps/{id} - Kayıt talebini detaylı gösterir. Yetkili kişiler erişebilir.
{Put} https://localhost:7134/api/tosunbank/v1/SignUps/{id} - Kayıt talebini onaylar, gerçek müşteriler tablosuna verileri aktarır. İstek tablosundan verileri siler. Yetkili kişiler erişebilir.

Login - Giriş yapılan endpoint'tir. JWT döndürür. Herkese açıktır.
{Post}  https://localhost:7134/api/tosunbank/v1/Login  - Gövdeden veriyi alır. Herkese açıktır. Veri yapısı:
{
  "userName": "string",
  "password": "string"
}

Authorisation - Yetkilendirme, yetki alma, yetki oluşturma işlevlerini yönetir. Sadece admin tarafından erişilebilir.
{Post} https://localhost:7134/api/tosunbank/v1/Authorisations/CreateAuthorisation?roleName={roleName} - Gelen sorgudaki rol ismine göre yetki oluşturur. Sadece admin erişebilir.
{Get}	https://localhost:7134/api/tosunbank/v1/Authorisations/AuthoriseUser - Veriyi gövdeden alır. Verilen id'deki kayda verilen isimdeki yetkiyi verir. Sadece admin erişebilir.
{
  "authorisedId": "string",
  "recordId": "string",
  "roleName": "string"
}
{Get}	https://localhost:7134/api/tosunbank/v1/Authorisations/UnauthoriseUser - Veriyi gövdeden alır. Verilen id'deki kayda verilen isimdeki yetkiyi alır. Sadece admin erişebilir.
{
  "authorisedId": "string",
  "recordId": "string",
  "roleName": "string"
}

Account - Hesap işlemlerini yönetir. Hesap açma talep sistemi ile çalışır. Yetkili onay vermeden açılmaz.
{Get}	https://localhost:7134/api/tosunbank/v1/Accounts/GetAccounts/{CustomerId} - Girilen kullanıcıya ait hesapları basitleştirilmiş şekilde gösterir. Sadece müşteri erişebilir. 
{Get}	https://localhost:7134/api/tosunbank/v1/Accounts/GetAccountDetail/{AccountId} - Girilen banka hesabına ait detaylı bilgileri gösterir. Sadece müşteri erişebilir.
{Put}	https://localhost:7134/api/tosunbank/v1/Accounts/ConfirmNewAccount/{requestId}?ApprovalId={OnaylayanId} - Girilen id'ye ait talebi onaylar. Kaydı ana hesaplar tablosuna aktarır.
{Get}	https://localhost:7134/api/tosunbank/v1/Accounts/NewAccount					- Var olan hesap açma taleplerini gösterir. Yetkili kişiler erişebilir.
{Post}	https://localhost:7134/api/tosunbank/v1/Accounts/NewAccount					- Yeni hesap açma talebi oluşturur. Müşteri erişebilir. Veriyi gövdeden alır. Yapı:
{
  "customerId": "string",
  "accountTypeId": 0
}
{Get}	https://localhost:7134/api/tosunbank/v1/Accounts/NewAccount/{id}			- Girilen id'ye ait hesap açma talebini gösterir. Yetkili kişiler erişebilir.

Transaction - Hesap hareketleri işlerini yönetir.	Müşteriler erişebilir.
{Post}	https://localhost:7134/api/tosunbank/v1/Transactions/Withdrawal			- Veriyi gövdeden alır. Belirtilen hesaptan belirtilen tutarda para çeker. Veri yapısı:
{
  "atmId": "string",
  "customerId": "string",
  "accountId": 0,
  "cardNo": "string",
  "amountToBeWithDrawn": 0
}
{Post}	https://localhost:7134/api/tosunbank/v1/Transactions/Deposit			- Veriyi gövdeden alır. Belirtilen hesaba belirtilen tutarda para yatırır. Veri yapısı:
{
  "atmId": "string",
  "customerId": "string",
  "accountId": 0,
  "cardNo": "string",
  "amountToBeWithDrawn": 0
}
{Post}	https://localhost:7134/api/tosunbank/v1/Transactions/TransferMoney		- Veriyi gövdeden alır. Belirtilen hesaplar arasında para transferi yapar. Veri yapısı:
{
  "customerId": "string",
  "accountId": 0,
  "targetAccountId": 0,
  "balance": 0
}