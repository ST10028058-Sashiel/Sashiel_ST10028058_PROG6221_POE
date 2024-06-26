
# Recipe Application

## Description
This is a WPF (Windows Presentation Foundation) application for managing recipes. The application allows users to enter new recipes, view all recipes, select a recipe to display, scale a recipe, reset recipe quantities to their original values, clear recipe data, filter recipes by ingredient and food group, and exit the application.

## Features
- Enter a new recipe
- View all recipes
- Select a recipe to display
- Scale a recipe
- Reset quantities for a recipe to their original values
- Clear recipe data
- Filter recipes by ingredient and food group
- Exit the application

## Requirements
- .NET Framework (4.8 or higher)
- Visual Studio (2019 or later)

## Instructions to Compile and Run

### Clone the Repository
First, clone the repository to your local machine using the following command:
```sh
git clone <repository_url>
```
Replace `<repository_url>` with the actual URL of your repository.

### Open the Project in Visual Studio
1. Launch Visual Studio.
2. Click on `File` > `Open` > `Project/Solution`.
3. Navigate to the directory where you cloned the repository and select the solution file (`.sln`).

### Restore NuGet Packages
Before building the project, make sure all NuGet packages are restored:
1. Right-click on the solution in the Solution Explorer.
2. Select `Restore NuGet Packages`.

### Build the Project
1. In Visual Studio, click on `Build` > `Build Solution`.
2. Ensure that the project builds successfully without any errors.

### Run the Application
1. Set the `MainWindow.xaml` as the startup item if it is not already set:
   - Right-click on `MainWindow.xaml` in the Solution Explorer.
   - Select `Set as Startup Item`.
2. Click on `Debug` > `Start Debugging` or press `F5` to run the application.

### Using the Application
- **Enter a New Recipe**: Click on the "Enter a New Recipe" button and follow the prompts to enter the recipe details.
- **View All Recipes**: Click on the "View All Recipes" button to display a list of all entered recipes.
- **Select a Recipe to Display**: Click on the "Select a Recipe to Display" button, enter the recipe name, and view its details.
- **Scale a Recipe**: Click on the "Scale a Recipe" button, enter the recipe name, and specify the scaling factor.
- **Reset Quantities for a Recipe**: Click on the "Reset Quantities for a Recipe" button, enter the recipe name, and reset the ingredient quantities to their original values.
- **Clear Recipe Data**: Click on the "Clear Recipe Data" button, enter the recipe name, and clear its data.
- **Filter**: Click on the "Filter" button, enter the ingredient name and food group to filter recipes based on the criteria.
- **Exit**: Click on the "Exit" button to close the application.



