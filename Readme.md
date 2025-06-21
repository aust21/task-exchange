# Task Exchange
Blazor-based web application that allows users to post, discover, and exchange tasks with one another. Whether you're looking for help with a small chore or offering your time to complete someone else's task, Task Exchange creates a community-driven platform for collaborative productivity.

## Features
- Task Exchange System – Users can offer and request tasks in a peer-to-peer model.
-  Task Listings – Browse available tasks posted by others with filters and search.
- Task Creation & Management – Post new tasks, describe them in detail, set deadlines, and edit or delete your own posts.
- User Profiles – View your posted and accepted tasks in your profile.
- Authentication – Secure user registration and login system (using Blazor Identity or similar).
- Task Bidding or Swapping – (Optional) Accept or swap tasks based on mutual agreement.

## Tech Stack
- Frontend & Backend: blazor (.NET 8+)
- Database: Entity Framework Core with PostgreSQL
- Styling: Tailwind CSS

## Getting Started
1. Clone the repository
```bash
git clone https://github.com/aust21/task-exchange.git
```
2. Navigate into the project
```bash
cd task-exchange/server
```
3. Modify database config in appsettings.json file in the server directory
4. Restore dependencies
```bash
dotnet restore 
```
5. Run the application
```bash
dotnet run 
```
6. Visit the browser
```bash
http://localhost:5225 
```

## Contributing
Contributions are welcome! Please fork the repository and open a pull request.

1. Fork it

2. Create your feature branch: git checkout -b feature/YourFeature

3. Commit your changes

Open a pull request