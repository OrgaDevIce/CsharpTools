# C# Tools

[![forthebadge](https://img.shields.io/nuget/v/ThomasBernard.CsharpTools)](https://www.nuget.org/packages/ThomasBernard.CsharpTools/)
[![forthebadge](https://img.shields.io/nuget/dt/ThomasBernard.CsharpTools)](https://www.nuget.org/packages/ThomasBernard.CsharpTools/)
[![forthebadge](https://img.shields.io/github/languages/code-size/DevIceCorp/CsharpTools)](https://www.nuget.org/packages/ThomasBernard.CsharpTools/)
[![CI/CD-Package-CsharpTools](https://github.com/DevIceCorp/CsharpTools/actions/workflows/dotnet.yml/badge.svg)](https://github.com/DevIceCorp/CsharpTools/actions/workflows/dotnet.yml)

## Pour commencer

Ce projet à été mis en place afin de créer des composants C# réutilisables sur plusieurs projets.

Voici une liste des différentes fonctionnalitées disponibles :
  - HttpService
  - LogService
  - DateTimeExtension
  - IntExtension
  - StringExtension



## HttpService

Ce service permet de réaliser des calls http sur une adresse donnée. On peut utiliser tous les verbes Http et utiliser un bearer token.
Vous pouvez utiliser la propriété `BaseUrl` pour définir un url qui sera appelé avant chaque call Http.

### Utilisation
```C#
IHttpService httpService = new HttpService();
HttpResult result = await httpService.SendHttpRequest(url, HttpMethod.Post, body); 

// Send get method and get the content of the request
HttpResult<ColorDTODown> result = await httpService.SendHttpRequest<ColorDTODown>(url, HttpMethod.Get); 
```

Cette méthode nous retourne un objet HttpResult contenant plusieurs propriétées. Si lors de l'exécution de la méthode, celle ci à crash, on pourra retrouver le message d'erreur dans ErrorMessage. On retrouve le HttpStatusCode dans Status et toutes les informations de notre requète dans RequestMessage. Finalement nous pourront lire la réponse de notre requète dans Content.

### Résultats

Il y a **deux type de résultats** pour cette méthode, `HttpResult` et `HttpResult<T>`. HttpResult est construit de la manière suivante :
  
```C#
    public class HttpResult
    {
        public string ErrorMessage { get; set; }
        public HttpStatusCode Status { get; set; }
        public HttpRequestMessage RequestMessage { get; set; }
    }
```

HttpResult<T> hérite de cette classe et possède uniquement une propriété en plus : `Content`
  
```C#
    public class HttpResult<T>
    {
        public string ErrorMessage { get; set; }
        public HttpStatusCode Status { get; set; }
        public HttpRequestMessage RequestMessage { get; set; }
        public T Content { get; set; }
    }
```

Dans ErrorMessage, on retrouvera le message de l'erreur qui aura été levée en cas de problème. Status contient le status http (404 NotFound...) et RequestMessage contiendra toutes les informations concerant notre requète. Si nous utilisons HttpResult<T> alors le résultat JSON de la requète sera stocké dans Content.

  
  
  
## LogService

LogService permet de créer un fichier de log quotidien à l'emplacement souhaité par l'utilisateur (ou par défaut à la racine du dossier de build). LogService contient deux méthodes et une propriété. La propriété DirectoryPath permet de choisir le chemin des logs. Par défaut ces logs sont créés à la racine de l'application. Ensuite pour écrire dans les fichiers de logs on utilise deux méthodes : 
  - Info 
  - Error
  - (Des méthodes pourront être ajoutées dans les futures versions)

Le fichier de log porte comme nom le schéma suivant : `Logs_{Day}-{Month}.log `

Info prend un seul paramètre, le message à afficher dans le fichier de log.

` 09:48:58 | Info | MainPage.xaml.cs\OnCounterClicked (line n°33) | Button clicked `

*Voici un exemple de ce qui est logué avec une Info.*

Error prend en paramètre une Exception.

` 13:08:29 | Error | MainPage.xaml.cs\OnCounterClicked (line n°16) | This is an error `

*Voici un exemple de ce qui est logué avec une Error.*

### Utilisation

```C#
ILogService logService = new LogService();

logService.Info("Button clicked");
logService.Error(new Exception("This is an error"));
```





