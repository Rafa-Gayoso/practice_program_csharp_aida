# Read Books Service

A kata to practice TDD with test doubles.

## What do we want to build?
We want to create a service that returns the list of books that a given user has read.

## Business rules
The service only returns the list of books read by a given user, if the logged
user is a friend of the given user.

If the given user is not a friend of the logged user, the list of books will be
empty.

If there's no logged user, the service should throw an exception.

## Context
* The friends of a user are stored in the persistence.
* The books that a user has read are stored in the persistence.
* The logged user can be obtained from the session object.

## Constraints
This is the interface of the entry point (the ReadBooksService ):
public List<Book> GetBooksReadByUser(User user)

A Book has a title.
A User has an id

## Análisis 

### Dependencias 
* SessionObject (mock) input indirecto
* Sistema de persistencia (mock) 

### Lista de ejemplos

No user logged => throw exception 
User not friend of the logged user => return empty list
User is friend of the logged user => return list that user has read
