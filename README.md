# conways-game-of-life
Simple implementation of Conway's Game of Life using .NET 7 and React 19

# Frontend

React front end application that implements simulating Conway’s Game of Life Conway's Game
of Life - Wikipedia
Create a UI that has:
1. A board that allows turning on and off squares
2. A way to advance to the next state
3. A way to play forever the next states
4. A way to advance x number of states
With a normal web service there might be an API, but the React app should take the place of the API.
Include all code to simulate the Game of Life but treat that code as if it were going to be called from an
API. Do not implement a backend API, unless you want to.
This could take four to five hours. The implementation should be production ready. You don’t need to
implement any authentication/authorization. Be ready to discuss your solution.

# Backend
Implement an API for Conway's Game of Life using C# ( .NET 7 )
The API should have implementations for at least the following:
1. Allows uploading a new board state, returns id of board
2. Get next state for board, returns next state
3. Gets x number of states away for board
4. Gets final state for board. If board doesn't go to conclusion after x number of attempts, returns
error
The service you write should be able to restart/crash/etc... but retain the state of the boards.
The code you write should be production ready. You don’t need to implement any
authentication/authorization. Be prepared to show how your code meets production ready
requirements.

This may take up to 4 – 5 hours to complete. Come prepared to talk about your architecture and coding
decisions.