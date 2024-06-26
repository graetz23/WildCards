# WildCards
A playing card simulator / library and a playground for object-oriented programming using software design pattern; all written in C#.

## Purpose
### Simulator
The simulator should play some playing card games, e.g. like Texas hold'em poker. It should generate statistical data and the implementation target is a threaded background process that is runnable as a daemon on some sever, e.g. a 24/7 GNU/Linux. 

### Design Patterns
For the implementation of the simulator, different software design pattens are applied. Those are adapted towards C# and vary e.g. from Factory, Facade, Decorator, Prototype, Strategy, to the Observer pattern.

### Philosophy
The project supplies oneself as a *try-out* object-oriented code and also as a *look-up* or a *how-to do it* in C# summary for myself.

## Development
Mono and MonoDevelop by debian GNU/Linux is and was used in first steps for implementation. In 2023 the project had been switched to _dotnet_ (former .NET core).

## Usage
Take a _bash_, clone the repo, and: _dotnet build_ && _dotnet run_

## Remarks
**I used this project in 2018 to get from C++ and Java into microsoft's C# and also into mono and MonoDevelop. Nowadays I use it to try _dotnet core framework_ project and solution management using the console or bash, respectively.**

## Contact
Christian (graetz23@gmail.com).

## Changelog

### 20240503
Updating towards dotnet core framework and how to use it.

### 20230516
Switching project to dotnet (.NET core)

### 20221106
Adding Helper methods for MD5, pseudo UUID v5, and non-case sensitive compares.
Adding classes Staple and Bank for handling Jetons.

### 20221105
  - Updating copyright and refactoring project.
  - Refactoring code in several cases.
  - Adding class Statics for random number with seeding.
  - Adding class Tags for static names, shorts, and values.
  - Adding classes for a state machine and texas hold em poker.
  - Adding namespace Jetons and base class Jeton.
  - Adding a Bank object that exchange dollars to Jeton objects.
    - The bank object can balance its spent Jetons against its account.
    - The bank object can check Jetons for their registration.
  - Adding the shuffling behaviour 'Stacked'.
  - Fixing the random shuffler bug.

### 20200301
  - Refactoring the project's new github account.
