# Duende Identity Server

# Notes:

- **Authentication:** Authentication is needed when an application needs to know the identity of the current user. The most common authentication protocols are SAML2p, WS-Federation and OpenID Connect – SAML2p being the most popular and the most widely deployed. **OpenID Connect** is the newest of the three, but is considered to be the future because it has the most potential for modern applications. It was built for mobile application scenarios right from the start and is designed to be API friendly.

- **API Access:** Applications have **two** fundamental ways with which they communicate with APIs – <u>using the application identity</u>, or <u>delegating the user’s identity</u>. <u>Sometimes both</u> methods need to be combined.

  OAuth2 is a protocol that allows applications to request access tokens from a security token service and use them to communicate with APIs. This delegation reduces complexity in both the client applications as well as the APIs since authentication and authorization can be centralized.

- # Udemy

- Asp .net core IdentityServer4
- Authentication ve authorization ve merkezi bir üyelik sistemi inşa edebiliriz ve 3rd party üyelik sistemleri ile entegre olabiliriz.
- jwt ve identity(microsoftın api'si) API temellerine temel seviyede ihtiyaç vardır
- jwt client ve server arasında bir yetkilendirme yapmak istenildiğinde kullanılan bir Token tipi.
- Identity microsoft'ın bir uygulaması ve üyelik sistemi inşa etmek için kullanılır. 3rd party üyeliklerle de giriş sağlamak mümkün.
- IS Bir saas (Software as a service (or SaaS) is a way of delivering applications over the Internet—as a service) değil. Belki o bir Frameworktür.

## What is authorization?

- It is yetkilendirmek, it keeps the permissions after login. It keeps the info about account not user. Kimlik yetkilendirme yapıyor.

## What is authorization?

- It is related with user's info. Kimlik doğrulama yapıyor.

## What is Identity Server?

- Is a framework that applies *OAuth 2.0* for authorization (Yetkilendirme) and *OpenId Connect* for  authentication (Kimlik doğrulama)

## What is OAuth 2.0?

- Client ve server Arasında yetkilenmeyi sağlayan bir protokoldür. Yani kural setidir.
- What problem does it solve for us?
  - <img src=".\identity server 4 tutorial\image-20221006165949066.png" alt="image-20221006165949066" style="zoom: 50%;" />
  - bu yöntemi kullanarak artık kullanıcı ana siteden üye oldu ve bilgileri 3. bir site ile paylaşılmadı.
  - A Bankasında tanımlanan yetkilere erişimi olacak myFinansın. My finans da tokenla gelen bilgileri (örneğin yetkileri) cookie veya spa ise storage'da tutar
  - Kullanıcı yerine ilgili siteden veri çekmemize imkan sağlıyor.

## What is OpenId connect

- It is a layer on OAuth 2.0. It is for Authentication
- OpneId connect identifies the user and after that OAuth2.0 manages the permissions

## What Does Identity Server Solve?

- ### **The first problem that it solves:** 

  - with the help of IdentityServer we can design sites that others can do their authentication using our site (like google). It does all of this for us and simplifying the coding with ability for customization
  - We can use IdentityServer to accept facebook or google logins. Because they also use oAuth2.0.

- ### **The second problem that it solves:**

  - API'leri sadece kendi uygulamalarınız kullansın istiyorsanız bunu token ile sağlamalısınız,
  - Eğer Identity Server kullanılmazsa önce ilk istekle API kendisi token üretmeli ve daha sonra client bu token ile API'ye erişebilir. 
    - <img src=".\identity server 4 tutorial\image-20221006202023767.png" alt="image-20221006202023767" style="zoom:25%;" />
    - Bu durumda her şey manuel olarak API tarafından yönetilir,
    - API ona kim istek yapıyor bilmesi gerekiyor
    - bu durumda bu token üretme kodu tüm API'ler üzerinde ayrı ayrı yapılmalı ve bakımları da ayrı ayrı yapılmalıdır,
    - Hepsini aynı class library'e toplasam bile güvenlik ve kalite açısından IdentityServer kadar iyi olmayacak
    - <img src=".\identity server 4 tutorial\image-20221006202738169.png" alt="image-20221006203105996" style="zoom:25%;" />
    - Yada ayrı bir projede Identity Server kurabilirim ve burada clientlar'ın listesi ve hangi API'lara erişiminin olduğunu tutabilirim,
    - Token yayınlama işlemi sadece IdentityServer tarafından yapılıyor
    - birkaç API için aynı token kullanılabilir.
    - Identity Server **sadece Token dağıtıyor**

- ### **The third problem that it solves:**

  - Aynı şirketin kaç sitesi varsa, her birisi için yeni bir login ve logout tasarlamamız gerekiyor normalde. Bu durumda kullanıcının da işi zorlaşıyor çünkü hepsinde ayrı ayrı login logout yapıyor
  - <img src=".\identity server 4 tutorial\image-20221007121245772.png" alt="image-20221007121245772" style="zoom: 33%;" />
  - Ama eğer, identity server kullanılırsa:
  - <img src=".\identity server 4 tutorial\image-20221007121603449.png" alt="image-20221007121603449" style="zoom:33%;" />
  - sadece bir yerden login oluyor ve tüm sitelere girebiliyor. Senaryoya göre değişebilir. Örneğin, logout olurken bir siteden logout olunca diğerlerinde de ol diyebiliriz yada olma diyebiliriz. Veri tabanı da tek bir yerde tutulur.

## Uygulama

- Kaç tür yetkilendirme ve kimlik doğrulama var?
  - cookie-based auth (web app)
    - .net core
    - dış dünyayla token ile bağlantı kurar
  - token-based auth
    - SAP ve mobile app
  - <img src=".\identity server 4 tutorial\image-20221007194838332.png" alt="image-20221007194838332" style="zoom: 50%;" />
- Ne yapmak istiyoruz?
  - <img src=".\identity server 4 tutorial\image-20221007200051676.png" alt="image-20221007200622914" style="zoom:33%;" />

## Projeleri Oluşturma:

- Kestrel normal console olarak ayağa kaldıralım demektir. Kestrel is a cross-platform [web server for ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/servers/?view=aspnetcore-6.0). Kestrel is the web server that's included and enabled by default in ASP.NET Core project templates. Kestrel supports the following scenarios: HTTPS, HTTP/2 Burayı oku https://learn.microsoft.com/en-us/aspnet/core/fundamentals/servers/?view=aspnetcore-6.0&tabs=windows

  

## Client Credentials Grant nedir?

<img src=".\identity server 4 tutorial\image-20221010121444565.png" alt="image-20221010123618055" style="zoom:33%;" />

- Yemek tarifleri sitemizin herhangi bir login sayfası ve üyelik sistemi yok. Server ve API'ları koruma altına almak istiyoruz. Başkaları erişemesin.
- API'lardan data alabilmek için mutlaka bir Access Token (= token) göndermeliyiz. We also have refresh token that is sent to server after expiration for getting a new access token. Tokenların hepsi jwt. Refresh token ların ömrü access tokenlara göre daha uzundur.
- For this first I have to define all API's and also Clients inside AuthServer. Then we will define the access level for each client.
- Bir API token alınca önce headerdaki tokenı ayrıştıracak ve daha sonra gerçekten bu token AuthServer mi dağıtmış onu doğrulayacak ve geçerli ise Client'a response dönecek.
- OAuth 2.0 Grants (izin tipleri):
  - Authorization code grant (with login)
  - Implicit grant (with login)
  - Resource owner credentials grant (with login)
  - client credentials grant (without login)
    - Client kimliği ile izin alma işlemi
    - Machine to machine de deniliyor
    - Bu ayar yapılmalı: `AllowedGrantTypes = GrantTypes.ClientCredentials`
    - Eğer ClientId ve secret gönderilirse seçtiğimiz bu akışa uygun bir token döneceğiz.
    - ClientCredentials olduğunda refresh token üretemeyiz
  - Sunucu tarafında tanımlanan grants:
    - Api Scope
    - API resource:
      - API'ları tanımlıyoruz. Hangi API'lere erişimimiz var gibi.
      - Yetki alanını belirler. Yani Client hangi yetkilere sahiptir ve hangi metotlara erişimi vardır. Api1 A metoduna ve read yetkisine sahiptir 
- IdentityServer 4 nuget i kuracağız
- **AddDeveloperSigningCredential**:
  - There are two types of passwords:
    - <u>Symmetric passwords</u>: jwt **imzalarken** kullanmış olduğum <u>şifreyi aynı zamanda</u> jwt'yi **doğrulamak** için de kullanıyorsam bu simmetric bir şifredir.
    - <u>Asymmetric passwords</u>: Asymmetric şifrenin 2 key'i var **Private** ve **public**. Private kimse ile paylaşılmaz ama public şifreyi kim çözecekse onunla paylaşılır ve public key' sahip olan kişi Private Key'i doğrulayabilir. 
  - Identity Server jwt'ları imzalamak için Asymmetric şifre kullanır. AuthServer token dağıtmadan önce ilgii token'ı private key ile beraber şifreler. Auth Serverda 2 key bulunur private ve public key. Private key kendi içindedir ve kimse ile paylaşmaz ama public key API'lar la paylaşılabilir. Sunucu jwt'yi privatekey ile imzalar ve ilgili clientlara gönderir. API'ler ise clienttan gelen tokenı doğrulamalı ve bunu public key ile yapar. Public key almak için de AuthServer'a sorgu atar. Bunlar otomatik yapılıyor zaten.
  - API'lar public key almaları için Auth Server adresine ihtiyaçları var
  - **AddDeveloperSigningCredential** development esnasında kullanabileceğimiz public ve private key'ler oluşturur.
  - Ama production için de **AddSigningCredential** kullanacak. Bu credentials Azure tarafında (Host tarafında) tutulacak ve Azurdan çekip kullanmam gerekecek. Uygulamanın içinde olmamalı bu credentials. 
  - Ayrıca middleware olarak ekleyebilmemiz için `app.UseIdentityServer()` kodunu da startupa eklememiz lazım
- **IdentityServer Endpoints**:
  - These endpoints are generated automatically: [DOCS link](https://docs.identityserver.io/en/latest/endpoints/discovery.html) 
    - Discovery Endpoint: Projedeki var olan endpointleri döner, 
    - Authorize Endpoint: Authorize olmak için,
    - Token Endpoint: Token almak için,
    - UserInfo Endpoint: Kullanıcı bilgileri almak için,
    - Device Authorization Endpoint: TV gibi clientlar için tanımlanmış bir Endpoint. Kullanıcı bilgileri girmek zor olan senaryolar için farklı bir akış burası, 
    - Introspection Endpoint: jwt .io nun işini görüyor ve decode ediyor jwt'yi
    - Revocation Endpoint: Token'ı geçersiz yapabilmek için, Client datası çalınırsa mesela
    - End Session Endpoint: Kullanıcı ile ilgili var olan sessionu sonlandırmak için kullanılır
- **Jwt'nin parçaları:**
  - headerda kullanılan algoritma ve tipi belirlenir
  - payload da datalar yer alır. Aud bölümü hangi API'a istek yapabileceğimizi gösterir. Tokenın ömrü de exp'te gösteriliyor.
  - 3 . kısım da imza kısmı
- jwt'nin içeriğini diğerleri de görebiliyor bunun sakıncası yok mu?
  - Yok. Çünkü, privatekey ile imzalanmış bu token ve değiştirilse ortaya çıkar. public key API'larda ve Private key sadece IdentityServerda.
  - <img src=".\identity server 4 tutorial\image-20221102180841711.png" alt="image-20221102180841711" style="zoom:33%;" />

- **API Ayarları:**

  - Install `Microsoft.AspNetCore.Authentication.JwtBearer`

  - add to startup:
  
    ```c#
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opts =>
    {
        opts.Authority = "https://localhost:5001";//jwt token'ı Yayınlayanı kim
        opts.Audience = "resource_api1"; // Is the resource defined in auth service GetApiResources()
    });
    ```
  
    ​      

  - Schema also can be a string name. Schema holds the authentication instance. Örneğin 2 tür üyelik sisteminiz varsa schema ayırabiliriz.

  - AddJwtBearer : ~~Uygulamadaki schema ile AddJwtBearer daki schema ismi aynı ise uygulamadaki authentication mekanizması jwt'ye bağlanmış olur~~ 2 kod aynı olmalı yani JwtBearerDefaults.AuthenticationScheme veya herhangi bir string

  - add `app.UseAuthentication();` on top of `app.UseAuthorization();`

  - Add methods to controllers:

      - API methodlarımı dış dünyaya kapatmam için `[Authorize] ` methodun başına eklemem yeterli olacaktır'
      - `[Authorize] ` Ekledikten sonra methoda erişemeyeceğiz 401 alacağız. Erişmek için Kurduğumuz IS'dan bir token alacağız ve onu bizim postman requestinin Authentication bölümüne yapıştıracağız. Tabi böyle bir tanım yapıldıysa. Bu tabda da **OAuth2.0** seçiyoruz ve Header Prefix olarak da **Bearer** Ekliyoruz. Bu sefer sorgumuz hatasız çalışacaktır.

  - **Role bazlı yetkilendirme ve claim bazlı yetkilendirme var**, Role based Authorization login yapan kullanıcı bazlıdır o yüzden şimdilik claim bazlı yetkilendirmeden bahs edeceğiz.

  - Role Based yetkilendirme, kullanıcı gruplarına yetki vermek gibidir (örneğin, biletçiler) ama bu kullanıcının bir datası ile yetkilendirme yapamaz yani İstanbullular erişsin gibi. Buna göre kullanıcının yaşına göre yetkilendirmeyi Claim bazlı yapmalıyız

  - Her API'ın hem authentication hem de Authorizationu var. Authentication sadece kullanıcının login olması anlamına gelmiyor.

  - API'lere Authorization ekleme - Claim bazlı yetkilendirme:

      - Bu sefer **Policy** ekleyeceğiz. (Şartname)

        ```c#
        /*Add this code under Add Authentication inside API startup*/
        builder.Services.AddAuthorization(opts =>
        {
            opts.AddPolicy("ReadProduct", policy =>
            {
                policy.RequireClaim("scope", "api1.read");
            });
            opts.AddPolicy("UpdateOrCreate", policy =>
            {
                policy.RequireClaim("scope", new[] { "api1.update", "api1.create" });
            });
        });
        ```

        

      - Şimdi her methodun başına `[Authorize("UpdateOrCreate")]` gibi attribute eklersek sadece API'ye erişim yeterli olmayacaktır ve ayrıca her clientın scope tanımı da olacaktır ki bizde policy sağlasın ve API'lerimizi kullansın.

Discovery EndPoint:

- IdentityServer ile ilgili bilgileri bize veriyor. Bunun içinde tüm yukarıda bahs edilen endpointlara bir link ve supported scopes gibi datalara erişebiliyoruz.

Introspect EndPoint: [Help Link](https://docs.identityserver.io/en/latest/endpoints/introspection.html#example)

- It is used by API's and it can be used to validate reference tokens. It will tell the API if it is valid. It will need api secret and also a token that is generated by any of clients.
- jwt'ı deşifre(parse) ediyor. Yetkileri görebilirsiniz. 
- basicAuth yapılmalı bu API'yi çağırmak için
- Bunun için de IdentityServer projesinde Resource bölümünde API'a bir secret tanımlamalıyız

Client'lardan API istekleri yapma

- Ajax istekleri için cors tanımı yapılmalı. İstekler tarayıcıdan gelecekse API'lerin içinde cors özelliği açılmalı. Bu siteden gelen istekleri kabul et diyoruz aslında. Şimdilik biz server side istekler yaptığımız için CORS tanımı yapmıyoruz. Angular ve SPA'ler CORS ayarına ihtiyaçları var.

- IdentityModel nuget paketini projeye ekliyoruz. Bu paket HttpClient'ımıza extension methodlar ekliyor.

  ```c#
  public async Task<IActionResult> Index()
  {
      HttpClient httpClient = new HttpClient();
  
      var disco = await httpClient.GetDiscoveryDocumentAsync("https://localhost:5001");//I would prefer to add the addresses manually instead of an extra call
      if (disco.IsError) { return View("Error"); }
  
      ClientCredentialsTokenRequest clientCredentialsTokenRequest = new ClientCredentialsTokenRequest()
      {
          ClientId = _configuration["Client:ClientId"],
          ClientSecret = _configuration["Client:ClientSecret"],
          Address = disco.TokenEndpoint
      };
  
      var token = await httpClient.RequestClientCredentialsTokenAsync(clientCredentialsTokenRequest);
      if (token.IsError) { return View("Error"); }
  
      httpClient.SetBearerToken(token.AccessToken);
  
      var response = await httpClient.GetAsync("https://localhost:5016/api/Product/GetProducts");
      if(response.IsSuccessStatusCode)
      {
          var contest = await response.Content.ReadAsStringAsync();
      }
  
      return View();
  }
  
  ```

  

- i

