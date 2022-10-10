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
  - **Kullanıcı yerine ilgili siteden veri çekmemize imkan sağlıyor.**

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
  - <img src=".\identity server 4 tutorial\image-20221007194838332.png" alt="image-20221007194838332" style="zoom:33%;" />
- Ne yapmak istiyoruz?
  - <img src=".\identity server 4 tutorial\image-20221007200051676.png" alt="image-20221007200622914" style="zoom:33%;" />

## Projeleri Oluşturma:

- Kestrel normal console olarak ayağa kaldıralım demektir. Kestrel is a cross-platform [web server for ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/servers/?view=aspnetcore-6.0). Kestrel is the web server that's included and enabled by default in ASP.NET Core project templates. Kestrel supports the following scenarios: HTTPS, HTTP/2 Burayı oku https://learn.microsoft.com/en-us/aspnet/core/fundamentals/servers/?view=aspnetcore-6.0&tabs=windows

  

## Client Credentials Grant nedir?

<img src=".\identity server 4 tutorial\image-20221010121444565.png" alt="image-20221010121444565" style="zoom:33%;" />

