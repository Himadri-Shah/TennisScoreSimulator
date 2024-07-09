
# Tennis Match Simulator - .NET Console Application


## Table of Contents

- [Overview](#overview)
- [Features](#Features)
- [Implementation of SOLID Principles](#ImplementationSOLIDPrinciples)
- [Tech Stack](#TechStack)
- [Installation](#installation)
- [Usage](#Usage)
- [Output](#Output)


###  <a name="overview"></a>Overview
This project simulates a tennis match in a .NET console application. It allows users to simulate matches between two players, track scores, and determine match outcomes based on tennis rules.

### Features
•	Simulates tennis matches between two players.                                       
•	Tracks scores: points, games, and sets.                                   
•	Handles tiebreak situations.                
•	Handles Deuce-Advantage situations.

### Implementation of SOLID Principles
•	Single Responsibility Principle: Each class (Player, TennisGame) has a clear responsibility                                                                  
    (e.g., Player manages player state, TennisGame manages the game logic and scoring)


•	Open/Closed Principle: Classes are open for extension                                  (e.g., adding new features) but closed for modification (e.g., existing behavior remains unchanged).         

•	Liskov Substitution Principle: The Player class can be substituted by any derived classes if extended, without affecting the TennisGame class.   

•	Interface Segregation Principle: Implemented Iplayer & ITennisGame to adhere this principle and facilitate dependency injection.

•	Dependency Inversion Principle: Classes depend on abstractions (e.g., Player class) rather than concrete implementations.

### Tech Stack

•	Visual Studio 2019                                      
•	C#.Net                              
•	NUnit testing              
•	Validation & Exception Handling                         
•	SOLID Principles



###  <a name="installation"></a>Installation
1.	Clone the repository:
```
git clone https://github.com/Himadri-Shah/TennisScoreSimulator.git
```
2.	Navigate to the project directory:
```
cd TennisScore_Simulator
```
3.	Build the project:
```
dotnet build
```

### Usage
1.	Run the application:
```
dotnet run
```

2.	Follow the on-screen instructions to start a tennis match simulation:
o	Enter player names.
o	Customize match settings if prompted.
o	Begin the match simulation.
3.	The application will display real-time scoring updates and match progress.

### Output

1. Example Input Data
   ![image](https://github.com/Himadri-Shah/TennisScoreSimulator/assets/58495795/a0ec2e10-44b9-46b3-9222-8bb9c6dd2041)

2.  Output from console
   ![image](https://github.com/Himadri-Shah/TennisScoreSimulator/assets/58495795/7029c262-1845-4fb2-92ae-333fc63c7f6a)

    
   
