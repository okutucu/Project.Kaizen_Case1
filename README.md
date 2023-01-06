# Project.Kaizen_Case1_v1

Proje Adımları: 

• Kodlar 8 hane uzunluğunda ve unique olmalıdır. <br /> 
• Kodlar ACDEFGHKLMNPRTXYZ234579 karakter kümesini içermelidir. <br /> 
• Kolayca tahmin edilememesi için ardışık sıralı üretim yapılmamalıdır. <br /> 

Kısaltmalarını tanımlamadan önce ileride bu isteklerin değişebilme durumunu göz önünde bulunarak bu değerleri yöneticilerin girdiği değerler ile yürütmeyi amaçladım.
Projeye ilk olarak "MSSQL" serverde stored prosedür yazarak sql tarafında kodun çalışıp çalışmadığını kontrol ettim.

İlk olarak sp_Generate_Code prosedürünü yazdım.

![sp_Generate_Codes](https://user-images.githubusercontent.com/58344612/210895988-4ac93918-a26b-4670-8511-8b8b39197ce8.png)

Yukarıdaki prosedür kullanıcının girdiği değerleri alacak ve alınan değerlere göre code üretecektir. 


Projenin ikinci adamında ise kodların geçeri olup olmadığını kontrol edecek olan bir prosedür yazılmalıdır. Bu prosedür ilk prosedür ile aynı değerleri alıp
geriye "isValid" değişkeni döndüren bir prosedürdür.

![sp_Check_Codes](https://user-images.githubusercontent.com/58344612/210896578-1c3a3f21-c11f-43cf-b762-0074ccd3dcb8.png)

Bu prosedürü yazdıktan sonra bu prosedürün testini sql üzerinden static veri yollayarak testelerini yaptım.
Aşağıdaki görselin açıklamaları;

1-) üretilen kodun uzunluğu kullanıcının değerle eşit olmama durumu. <br /> 
2-) Dbdde üretilen kod ile aynı bir değer olması (üretilen kod uniqe değil) <br />
3-) Kullanıcın girdiği karakter kümesinde olmayan bir karakter üretildi. <br /> 
4-) Üretilen kod tüm testlerden geçerse "True" döner. <br />
5-) Üretilen kod tüm herhangi bir testten geçmezse  "False" döner. <br />


![sp_Check_Codes_Results](https://user-images.githubusercontent.com/58344612/210897022-10fee215-397f-4fa8-ba12-6b565dfd60b4.png)


sp_Check_Codes testlerden başarılı bir şekilde geçmesinden sonra bu prosedürü  sp_Generate_Code prosedüründe kullanmamız gerekmektedir.

![sqllast](https://user-images.githubusercontent.com/58344612/210897281-90aa512f-e934-4692-a302-bd63f722c4d3.png)

Stored procedurumüzü güncelledikten sonra .Net Core 6 Web API projemizde "Code First" yöntemi ile çalışmaya başladım.

Gerekli sqlconnection ve migrations işlemlerini yaptıktan sonra "GenerateCode" POST işlemini yaptım. Post işlemi sonucunda kullanıcıların belirlediği
değerlerle kısıtlanmış olan cod'lar veri tabanına eklendi.


![GeneratCodesActionResult](https://user-images.githubusercontent.com/58344612/210897911-313705de-73c5-4d0e-b0d4-3176c7a1e954.png)


Projeye ANDROID/IOS UYGULAMA, SMS, WEB, IVR gibi çeşitli kanallar üzerinden son kullanıcıların ellerindeki kodları kullanarak kampanyalara katılımı
sağlanacağı için dışarı açtığımız apileri "JWT" kullanırak doğrulama sağladım. 

Kod oluşturmak için veya oluşturulan kodları görüntülemek için Login işlemi yapılması gerekmektedir.
"Seeds Data" olarak eklediğimiz kullanıcı UserName Şifrelerine göre yöneticiler sisteme giriş yapabileceklerdir.

Olası bir yanlış girilmesi durumunda geriye hata döndürülecektir.

![Login_Fail](https://user-images.githubusercontent.com/58344612/210898451-330cc1e0-3424-4e5f-b016-66f40be9fa5e.png)
![code_access_denied](https://user-images.githubusercontent.com/58344612/210898614-b09befce-74f5-4151-9566-b89adcbb9c09.png)



Girişin başarılı olması durumunda sistem bir Token üretecektir ve kullanıcı bu token ile kısıtlanmış sayfalara erişim sağlayabilecektir.

![Login_Success](https://user-images.githubusercontent.com/58344612/210898543-dc60b1cd-56b1-4e1c-97ae-42ded5ea0ecf.png)
![token](https://user-images.githubusercontent.com/58344612/210898656-e21bf610-36c3-442b-8847-c36909bf1423.png)

Yöneticinin erişim sağlayabildiği Code ekleme sayfasında olası bir kullanıcı hatasını önlemek için "Validasyon" kullanmıştır.
![Validator_Result](https://user-images.githubusercontent.com/58344612/210898805-12dffea9-1190-46bb-b1c5-3af75a47fde1.png)

Yönetici tüm kodları listeyebilecektir.

![get_all_code](https://user-images.githubusercontent.com/58344612/210898844-76013440-2f56-48f2-a5f7-cbba986ab929.png)


Son olarak üretilen kodlara sahip müşteriler kodlarını sorgulayabilecektir. Kod sabihi müşteriler üretilen kodun amacına göre geri dönüş alacaklardır.

![Gecerli_urun](https://user-images.githubusercontent.com/58344612/210898956-b9b37716-f462-4e0b-97fe-6857770ff35b.png)
![gecersiz_urun](https://user-images.githubusercontent.com/58344612/210898958-2bcbf42f-cc33-43e5-b91e-173d1c415273.png)





PROJEDE KULLANILAN KÜTÜPHANELER : 

Entityleri, Dto larla maplemek için => AutoMapper(12.0.0) <br />
Validasyon işlemeri için => FluentValidation (11.2.2) <br />
Jwt doğrulaması için => Authentication.JwtBearer (6.0.12) <br />
Veri tabanlı işlemleri için => EntityFrameworkCore (6.0.12) <br />
Veri tabanı ve Visual Studio Code arasındaki ilişkiler için => EntityFrameworkCore.Design (6.0.12) , EntityFrameworkCore.Tools (6.0.12), EntityFrameworkCore.SqlServer (6.0.12)

