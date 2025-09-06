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
Implement an API for Conway's Game of Life using C# (net7.0)
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

Code Challenge Recommendations

The following document offers a reminder of some activities to take into consideration as
part of the “Code challenge” process held by the client.
The intention of it is to make sure all these areas are covered in the best way possible
before submitting the challenge.
Please review the document before the interview and analyze the best way to incorporate
these suggestions as part of the code challenge project.

Requirements Understanding
• Understand the problem: Ensure you understand the task, constraints, and
expected output before starting.
• Functional correctness: Ensure all requirements of the challenge are met.
• Edge cases: Account for possible edge cases in the problem domain and list them if
needed
• Clarify assumptions: Document any assumptions you’ve made.
• Scalability: Address scalability if the problem has large input/output sizes.

Code Quality
• Readable and maintainable code:
• Use clear, descriptive variable, function, and class names.
• Avoid deep nesting; refactor complex logic into helper methods or
classes.

• Commenting and documentation:
• Add concise comments for complex logic.
• Include a summary of the solution at the top of the main file or function.
• Adherence to coding standards:
• Follow language-specific style guides (e.g., Microsoft’s C# coding
conventions for C#).
• Ensure consistent formatting (e.g., spaces, tabs, braces, indentation).
• Avoid hardcoding:
• Use configuration files or constants for environment-specific values.
• DRY (Don’t Repeat Yourself):
• Eliminate redundant code through reusable methods or classes.

• SOLID principles:
• Write code that adheres to object-oriented design principles.

Error Handling
• Graceful error handling:
• Use appropriate try-catch blocks.
• Return meaningful error messages or error codes in APIs.
• Input validation:
• Validate all inputs and provide user-friendly error messages.
• Logging:
• Log errors with sufficient detail (e.g., exception message, stack trace).
• Use different log levels (e.g., Info, Warning, Error) for appropriate
situations.

Testing
• Unit tests:
• Cover key methods and edge cases (e.g., 0, negative numbers, empty
strings)
• Ensure 80-100% code coverage for critical sections.
• Manual testing:
• Test the code for functional correctness and UX (if applicable).
• Testing framework:
• Use appropriate tools (e.g., xUnit, MSTest for C#).
• Integration tests (could be a suggestion for the review instance):
• Test interactions between components (e.g., database and API).
• Stress testing (could be a suggestion for the review instance):
• Simulate high load scenarios (if the problem is performance-sensitive).

Performance
• Optimize algorithms:
• Choose the most efficient algorithm for the problem (e.g., avoid O(n2)
when O(n) is possible).
▪ Reference: Big-O Cheat Sheet

• Memory management:
• Ensure memory is released properly in resource-intensive applications.
• Reduce API/IO Calls:
• Avoid unnecessary calls in loops; fetch all data at once when possible.
• Asynchronous operations:
• Use async/await for I/O operations to improve responsiveness.
• Profiling (could be a suggestion for the review instance):
• Use performance profiling tools to identify bottlenecks.

Security
• Secure input handling:
• Sanitize inputs to avoid SQL injection, XSS, or other attacks.
• Data protection:
• Avoid exposing sensitive information (e.g., passwords, tokens).
• Use environment variables for secrets and keys.
• Error concealment:
• Avoid revealing internal stack traces or system details to end-users.

Deployment Readiness
• Environment configuration:
• Use separate configurations for development, staging, and production.
• Persistence:
• Ensure state or data persistence is addressed.
• Dependency management:
• Include a README with installation/setup instructions.
• Use dependency management tools (e.g., NuGet for C#).
• Containerization (could be a suggestion for the review instance):
• Provide a Dockerfile if appropriate for the challenge.

Documentation
• README file:
• Problem description.
• Steps to run the code locally.
• Explanation of the solution and thought process.
• List of assumptions and trade-offs.
• API documentation (if applicable):
• Use tools like Swagger or provide a simple table describing endpoints.

Code Robustness
• Concurrency handling:
• If applicable, ensure thread-safety and proper use of locks or
asynchronous patterns.

• Idempotency:
• Ensure repeatable operations (e.g., API calls) are idempotent where
needed.
• Graceful degradation:
• Implement fallback mechanisms if dependencies fail.

Some other tips to Demonstrate Professionalism
• Version control:
• Use meaningful commit messages and a clear branching strategy (e.g.,
feature/<task_name>).

• Modularity:
• Structure the code into appropriate layers (e.g., Controllers, Services,
Models in a web app).
• Scalability considerations:
• Mention scalability strategies in documentation (e.g., caching, sharding,
load balancing).
• Future extensibility:
• Make the design extensible for potential future requirements.

Example Folder Structure for a C# Project
src/
Controllers/
GameOfLifeController.cs
Services/
GameOfLifeService.cs
Models/
Board.cs
Data/
GameOfLifeContext.cs
Program.cs
appsettings.json
tests/
UnitTests/
GameOfLifeServiceTests.cs
README.md
Dockerfile

Final Checklist (summary)
• Functional correctness tested for all use cases.
• Code quality adheres to best practices.
• Comprehensive error handling.
• Unit and integration tests included with high coverage.
• Optimized for performance and scalability.
• Properly documented (README, inline comments, and API docs).
• Ready for deployment with persistence and environment configurations.