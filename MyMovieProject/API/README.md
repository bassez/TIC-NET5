# API routes fot our IMDB-ish project

## WIP

DB Tuto : https://docs.microsoft.com/fr-fr/ef/core/get-started/aspnetcore/new-db?tabs=netcore-cli

## Linux issues

```
System.ComponentModel.Win32Exception (8): Exec format error
```

start command : 
```
ASPNETCORE_ENVIRONMENT=Development mono bin/Debug/net461/API.exe
```

NO HTTPS Redirection !

## Encoding

Format : JSON
Header : Content-Type : application/json

## Models

### Movie

```
Movie {
  id             : int [pk]
  name           : varchar
  description    : text
  category       : text
  date_published : date
  publisher      : text
}
```

### User

```
User {
  id           : int [pk]
  pseudo       : varchar [unique]
  email        : varchar [unique]
  password     : varchar
  birthdate    : date
  date_created : date
}
```

## Routes 

### Movies 

#### POST /api/movies

> Creates a movie

Body : 
```
{
   name,
   description,
   category,
   date_published,
   publisher
}
```

Response : 
```
200 Created
```

#### GET /api/movies

> Get All movies

Response : 
```
[Movie]
```

#### GET /api/movies/:id

> Get a movie by ID

Response : 
```
Movie
```

#### DELETE /api/movies/:id

> Deletes a movie by ID

Response : 
```
200 Deleted
```



### Users

#### POST /api/users

> Creates a user

Body : 
```
{
  pseudo,
  email,
  password,
  birthdate
}
```

Response : 
```
200 Created
```

#### GET /api/users/:id

> Get a user by ID

Response : 
```
User
```

#### DELETE /api/users/:id

> Deletes a user by ID

Response : 
```
200 Deleted
```
