# WildCards
A playing card simulator / library and playground for software design pattern; written in C#.

## Purpose
### Simulator
The simulator should play some playing card games, e.g. like Texas hold'em poker. It should generate statistical data and the implementation target is a threaded background process that is runnable as a daemon on some sever, e.g. a 24/7 GNU/Linux. 

### Design Patterns
For the implementation of the simulator, different software design pattens are applied. Those are adapted towards C# and vary e.g. from Factory, Facade, Decorator, Prototype, Strategy, to the Observer pattern.

### Philosophy
The project supplies oneself as a *look-up* or a *how-to do it* in C# summary.

## Development
Mono and MonoDevelop by debian GNU/Linux was used for implementation in 2018 to 2022.
By 2022 I switched to MSVS Community and coded on my 2010's iCore 7.

## Remarks
I used this project in 2018 to get from C++ into C# and also into mono and MonoDevelop.

## Contact
Christian (graetz23@gmail.com).

## Changelog
### 20221105
Updating copyright and refactoring project.
Refactoring code in several cases.
Adding class Statics for random number with seeding.
Adding class Tags for static names, shorts, and values.
Adding classes for a state machine and texas hold em poker.
Adding namespace Jetons and base class Jeton.
Adding the shuffling behaviour 'Stacked'.
Fixing the random shuffler bug.

### 20200301
Refactoring the project's new github account.
