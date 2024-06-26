using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sashiel_ST10028058_PROG6221_POE
{
    internal class Recipe
    {
        private List<Ingredients> ingredients = new List<Ingredients>();
        private List<string> steps = new List<string>();
        public string? RecipeName { get; set; }
        public object? Ingredients { get; internal set; }



        public void EnterRecipe()
        {
            RecipeName = PromptInput("Enter the name of the recipe:");
            int numIngredients = int.Parse(PromptInput("Enter the number of ingredients:"));
            ingredients.Clear();
            for (int i = 1; i <= numIngredients; i++)
            {
                string name = PromptInput($"Enter the name of ingredient {i}:");
                double quantity = double.Parse(PromptInput($"Enter the quantity of {name}:"));
                string unitOfMeasurement = PromptInput($"Enter the unit of measurement of {name}:");
                int calories = int.Parse(PromptInput($"Enter the number of calories of {name}:"));
                string foodGroup = PromptInput($"Enter the food group of {name}:");

                ingredients.Add(new Ingredients(name, quantity, unitOfMeasurement, calories, foodGroup));
            }

            int numSteps = int.Parse(PromptInput("Enter the number of steps:"));
            steps.Clear();
            for (int i = 1; i <= numSteps; i++)
            {
                string step = PromptInput($"Enter description of step {i}:");
                steps.Add(step);
            }

            MessageBox.Show("Recipe entered successfully!");
        }

        public void DisplayRecipe()
        {

            StringBuilder recipeInfo = new StringBuilder();

            recipeInfo.AppendLine($"Recipe: {RecipeName}");
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

            int totalCalories = ingredients.Sum(i => i.Calories);
            recipeInfo.AppendLine($"Total Calories: {totalCalories}");

            if (totalCalories > 300)
            {
                recipeInfo.AppendLine("WARNING: The total calories of this recipe exceed 300!");
            }

            MessageBox.Show(recipeInfo.ToString(), "Recipe Details");
        }

        public void ScaleRecipe()
        {
            double factor = double.Parse(PromptInput("Enter the scaling factor (0.5, 2, or 3):"));

            foreach (Ingredients ingredient in ingredients)
            {
                ingredient.Quantity *= factor;
            }

            MessageBox.Show("Recipe scaled successfully!");
        }

        public void ResetQuantities()
        {
            foreach (Ingredients ingredient in ingredients)
            {
                ingredient.ResetQuantities();
            }

            MessageBox.Show("Quantities reset successfully.");
            DisplayRecipe();
        }

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

        private string PromptInput(string message)
        {
            return Interaction.InputBox(message, "Recipe Entry");
        }

        internal static object Where(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
        public string? FoodGroup { get; set; }

        public List<Ingredients>? IngredientList { get; set; }
    }

}

