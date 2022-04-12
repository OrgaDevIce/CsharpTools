# C# Components

[![forthebadge](https://img.shields.io/nuget/v/ThomasBernard.CsharpTools)](https://www.nuget.org/packages/ThomasBernard.CsharpTools/)
[![forthebadge](https://img.shields.io/nuget/dt/ThomasBernard.CsharpTools)](https://www.nuget.org/packages/ThomasBernard.CsharpTools/)
[![forthebadge](https://img.shields.io/github/languages/code-size/DevIceCorp/CsharpTools)](https://www.nuget.org/packages/ThomasBernard.CsharpTools/)


[![forthebadge](https://forthebadge.com/images/badges/built-with-love.svg)](https://forthebadge.com)
[![forthebadge](https://forthebadge.com/images/badges/made-with-c-sharp.svg)](https://forthebadge.com)

## Pour commencer

Ce projet à été mis en place afin de créer des composants C# réutilisables sur plusieurs projets.

Voici une liste des différents services disponibles :
  - HttpService
  - CsvService


## HttpService

Dans la plupart de nos projets nous avons besoin de réaliser différents call Http, généralement pour communiquer avec des API. Ce service permet de réaliser facilement cette tâche. HttpService ne contient qu'une seule méthode SendHttpRequest. Cette méthode prend plusieurs paramètres :
  - T (classe) => classe avec laquelle nous allons déserialiser le contenu de la réponse de la requète.
  - url (string) => Une chaîne de charactères sur laquelle nous allons réaliser notre call Http.
  - httpMethod (HttpMethod) => Un HttpMethod (Verbe Http (Get, Post, Delete, Put, Patch)), c'est le verbe Http que nous allons utiliser pour notre requète.
  - body (object) => body est un object que nous allons serialiser puis ajouter dans le corps de notre méthode.
  - bearer (string) => Une chaine de charactères contenant notre bearer token.

Cette méthode nous retourne donc un objet HttpResult contenant plusieurs propriétés. Si lors de l'exécution de la méthode, celle ci à crash, on pourra retrouver le message d'erreur dans ErrorMessage. On retrouve le HttpStatusCode dans Status et toutes les informations de notre requète dans RequestMessage. Finalement nous pourront lire la réponse de notre requète dans Content.

### Utilisation
```C#
IHttpService httpService = new HttpService(); // New instance of HttpService

HttpResult result = await httpService.SendHttpRequest(url, HttpMethod.Post, body); // Send post method without body recuperation
HttpResult<ColorDTODown> result = await httpService.SendHttpRequest<ColorDTODown>(url, HttpMethod.Get); // Send get method and get the content of the request
```

### Résultats

Il y a deux type de résultats pour cette méthode, HttpResult et HttpResult<T>. HttpResult est construit de la manière suivante :
  
```C#
    public class HttpResult
    {
        public string ErrorMessage { get; set; }
        public HttpStatusCode Status { get; set; }
        public HttpRequestMessage RequestMessage { get; set; }
    }
```

HttpResult<T> hérite de cette classe et possède uniquement une propriété en plus : Content
  
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

Toutes les applications devraient avoir des logs, cela permet d'identifier et de résoudre un problème plus rapidement. LogService permet de créer un fichier de log quotidien à l'emplacement souhaité par l'utilisateur. LogService contient deux méthodes et une propriété. La propriété DirectoryPath permet de choisir le chemin des logs. Par défaut ces logs sont créés à la racine de l'application. Ensuite pour écrire dans les fichiers de logs on utilise deux méthodes : 
  - Info 
  - Error
  - (Des méthodes pourront être ajoutées dans les futures versions)

Le fichier de log porte comme nom le schéma suivant : ```Logs_{Day}-{Month}.log ```

Info prend un seul paramètre, le message à afficher dans le fichier de log.

``` 09:48:58 | Info | C:\Users\Thomas\Desktop\testLogs\testLogs\MainPage.xaml.cs/OnCounterClicked (19) | Button clicked ```

Voici un exemple de ce qui est logué avec une Info.

Error prend en paramètre une Exception.

``` 09:55:12 | Error | C:\Users\Thomas\Desktop\testLogs\testLogs\MainPage.xaml.cs/OnCounterClicked (20) | This is an error ```

Voici un exemple de ce qui est logué avec une Error.

### Utilisation

```C#
ILogService logService = new LogService(); // New instance of our service
logService.DirectoryPath = @"C:\logs"; // Set the path of logs folder

logService.Info("Button clicked"); // Create a new Info
logService.Error(new Exception("This is an error")); // Create a new Error
```





