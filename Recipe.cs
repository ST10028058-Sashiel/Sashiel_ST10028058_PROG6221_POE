using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Sashiel_ST10028058_PROG6221_POE
{
    // Class representing a recipe
    internal class Recipe
    {
        // Private lists to store ingredients and steps of the recipe
        private List<Ingredients> ingredients = new List<Ingredients>();
        private List<string> steps = new List<string>();

        // Properties of the recipe
        public string? RecipeName { get; set; }
        public string? FoodGroup { get; set; }
        public List<Ingredients>? IngredientList => ingredients;

        // Method to prompt the user to enter the recipe details
        public void EnterRecipe()
        {
            // Prompt the user to enter the name and food group of the recipe
            RecipeName = PromptInput("Enter the name of the recipe:");
            FoodGroup = PromptInput("Enter the food group of the recipe:");

            // Prompt the user to enter the number of ingredients
            int numIngredients = GetValidatedIntInput("Enter the number of ingredients:");
            ingredients.Clear();

            // Loop to get details of each ingredient
            for (int i = 1; i <= numIngredients; i++)
            {
                string name = PromptInput($"Enter the name of ingredient {i}:");
                double quantity = GetValidatedDoubleInput($"Enter the quantity of {name}:");
                string unitOfMeasurement = PromptInput($"Enter the unit of measurement of {name}:");
                int calories = GetValidatedIntInput($"Enter the number of calories of {name}:");
              

                ingredients.Add(new Ingredients(name, quantity, unitOfMeasurement, calories, FoodGroup));
            }

            // Prompt the user to enter the number of steps
            int numSteps = GetValidatedIntInput("Enter the number of steps:");
            steps.Clear();

            // Loop to get details of each step
            for (int i = 1; i <= numSteps; i++)
            {
                string step = PromptInput($"Enter description of step {i}:");
                steps.Add(step);
            }

            MessageBox.Show("Recipe entered successfully!");
        }

        // Method to display the recipe details
        public void DisplayRecipe()
        {
            StringBuilder recipeInfo = new StringBuilder();

            // Build the recipe details string
            recipeInfo.AppendLine($"Recipe: {RecipeName}");
            recipeInfo.AppendLine($"Food Group: {FoodGroup}");
            recipeInfo.AppendLine();
            recipeInfo.AppendLine("Ingredients:");
            foreach (Ingredients ingredient in ingredients)
            {
                recipeInfo.AppendLine($"{ingredient.Name} - {ingredient.Quantity} {ingredient.UnitOfMeasurement}");
            }
            recipeInfo.AppendLine();
            recipeInfo.AppendLine("Steps:");
            for (int i = 0; i < steps.Count; i++)
            {
                recipeInfo.AppendLine($"{i + 1}. {steps[i]}");
            }
            recipeInfo.AppendLine();

            // Calculate and display the total calories
            int totalCalories = ingredients.Sum(i => i.Calories);
            recipeInfo.AppendLine($"Total Calories: {totalCalories}");

            // Show a warning if the total calories exceed 300
            if (totalCalories > 300)
            {
                recipeInfo.AppendLine("WARNING: The total calories of this recipe exceed 300!");
            }

            MessageBox.Show(recipeInfo.ToString(), "Recipe Details");
        }

        // Method to scale the recipe quantities by a specified factor
        public void ScaleRecipe()
        {
            double factor = GetValidatedDoubleInput("Enter the scaling factor (0.5, 2, or 3):");

            foreach (Ingredients ingredient in ingredients)
            {
                ingredient.Quantity *= factor;
            }

            MessageBox.Show("Recipe scaled successfully!");
        }

        // Method to reset the quantities of all ingredients in the recipe
        public void ResetQuantities()
        {
            foreach (Ingredients ingredient in ingredients)
            {
                ingredient.ResetQuantities();
            }

            MessageBox.Show("Quantities reset successfully.");
            DisplayRecipe();
        }

        // Method to clear the recipe data
        public void ClearData()
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to clear the data?", "Clear Recipe Data", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                ingredients.Clear();
                steps.Clear();
                MessageBox.Show("Data has been cleared successfully!");
            }
            else
            {
                MessageBox.Show("Data was not cleared.");
            }
        }

        // Helper method to prompt the user for input
        private string PromptInput(string message)
        {
            return Interaction.InputBox(message, "Recipe Entry");
        }

        // Helper method to get a validated integer input from the user
        private int GetValidatedIntInput(string message)
        {
            int result;
            while (!int.TryParse(PromptInput(message), out result) || result < 0)
            {
                MessageBox.Show("Please enter a valid positive integer.");
            }
            return result;
        }

        // Helper method to get a validated double input from the user
        private double GetValidatedDoubleInput(string message)
        {
            double result;
            while (!double.TryParse(PromptInput(message), out result) || result < 0)
            {
                MessageBox.Show("Please enter a valid positive number.");
            }
            return result;
        }
    }
}
