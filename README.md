# C# Components

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
