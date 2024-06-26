using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Sashiel_ST10028058_PROG6221_POE
{
    // Interaction logic for MainWindow.xaml
    public partial class MainWindow : Window
    {
        // List to store all recipes
        private List<Recipe> recipeCollection = new List<Recipe>();

   
        // Event handler for entering a new recipe
        private void EnterRecipe_Click(object sender, RoutedEventArgs e)
        {
            Recipe newRecipe = new Recipe();
            newRecipe.EnterDetails();
            recipeCollection.Add(newRecipe);
            MessageBox.Show("Recipe entered successfully!");
        }

        // Event handler for viewing all recipes
        private void ViewAllRecipes_Click(object sender, RoutedEventArgs e)
        {
            if (recipeCollection == null || recipeCollection.Count == 0)
            {
                MessageBox.Show("No recipes available.");
                return;
            }

            var recipeNames = recipeCollection.OrderBy(r => r.Name).Select(r => r.Name);
            string recipeList = string.Join("\n", recipeNames);
            MessageBox.Show("List of Recipes:\n\n" + recipeList);
        }

        // Event handler for selecting a recipe to display
        private void SelectRecipe_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = Microsoft.VisualBasic.Interaction.InputBox("Enter the name of the recipe you want to display:", "Recipe Selection");

            if (string.IsNullOrWhiteSpace(recipeName))
            {
                MessageBox.Show("Please enter a valid recipe name.");
                return;
            }

            Recipe selectedRecipe = recipeCollection?.Find(r => r.Name == recipeName);

            if (selectedRecipe != null)
            {
                selectedRecipe.Display();
            }
            else
            {
                MessageBox.Show("Recipe not found!");
            }
        }

        // Event handler for scaling a recipe
        private void ScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = Microsoft.VisualBasic.Interaction.InputBox("Enter the name of the recipe you want to scale:", "Recipe Scaling");

            if (string.IsNullOrWhiteSpace(recipeName))
            {
                MessageBox.Show("Please enter a valid recipe name.");
                return;
            }

            Recipe recipeToScale = recipeCollection?.Find(r => r.Name == recipeName);

            if (recipeToScale != null)
            {
                recipeToScale.Scale();
                MessageBox.Show("Recipe scaled successfully!");
            }
            else
            {
                MessageBox.Show("Recipe not found!");
            }
        }

        // Event handler for resetting quantities of a recipe to their original values
        private void ResetQuantities_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = Microsoft.VisualBasic.Interaction.InputBox("Enter the name of the recipe you want to reset quantities:", "Reset Quantities");

            if (string.IsNullOrWhiteSpace(recipeName))
            {
                MessageBox.Show("Please enter a valid recipe name.");
                return;
            }

            Recipe recipeToReset = recipeCollection?.Find(r => r.Name == recipeName);

            if (recipeToReset != null)
            {
                recipeToReset.ResetQuantities();
                MessageBox.Show("Quantities reset successfully.");
            }
            else
            {
                MessageBox.Show("Recipe not found!");
            }
        }

        // Event handler for clearing recipe data
        private void ClearData_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = Microsoft.VisualBasic.Interaction.InputBox("Enter the name of the recipe you want to clear:", "Clear Recipe Data");

            if (string.IsNullOrWhiteSpace(recipeName))
            {
                MessageBox.Show("Please enter a valid recipe name.");
                return;
            }

            Recipe recipeToClear = recipeCollection?.Find(r => r.Name == recipeName);

            if (recipeToClear != null)
            {
                recipeToClear.Clear();
                recipeCollection.Remove(recipeToClear);
                MessageBox.Show("Data has been cleared successfully!");
            }
            else
            {
                MessageBox.Show("Recipe not found!");
            }
        }

        // Event handler for exiting the application
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // Event handler for filtering recipes
        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            string ingredientName = Microsoft.VisualBasic.Interaction.InputBox("Enter the name of the ingredient:", "Filter by Ingredient");
            string foodGroup = Microsoft.VisualBasic.Interaction.InputBox("Choose a food group:", "Filter by Food Group");

            // Validate ingredient name
            if (string.IsNullOrWhiteSpace(ingredientName))
            {
                MessageBox.Show("Please enter a valid ingredient name.");
                return;
            }

            // Validate food group
            if (string.IsNullOrWhiteSpace(foodGroup))
            {
                MessageBox.Show("Please choose a valid food group.");
                return;
            }

            // Check if recipes list is available
            if (recipeCollection == null || recipeCollection.Count == 0)
            {
                MessageBox.Show("No recipes available.");
                return;
            }

            // Filter the recipes based on the provided criteria
            List<Recipe> filteredRecipes = new List<Recipe>();
            foreach (var recipe in recipeCollection)
            {
                if (recipe.IngredientList != null &&
                    recipe.IngredientList.Any(i => i.Name.ToLower().Contains(ingredientName.ToLower())) &&
                    !string.IsNullOrWhiteSpace(recipe.FoodGroup) &&
                    recipe.FoodGroup.ToLower() == foodGroup.ToLower())
                {
                    filteredRecipes.Add(recipe);
                }
            }

            // Display the results
            if (filteredRecipes.Count == 0)
            {
                MessageBox.Show("No recipes found matching the given criteria.");
            }
            else
            {
                var recipeNames = filteredRecipes.OrderBy(r => r.Name).Select(r => r.Name);
                string recipeList = string.Join("\n", recipeNames);
                MessageBox.Show("Filtered Recipes:\n\n" + recipeList);
            }
        }
    }
}
