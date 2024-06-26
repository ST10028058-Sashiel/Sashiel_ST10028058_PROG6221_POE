using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Sashiel_ST10028058_PROG6221_POE
{
    public partial class MainWindow : Window
    {
        private List<Recipe> recipes = new List<Recipe>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void EnterRecipe_Click(object sender, RoutedEventArgs e)
        {
            Recipe newRecipe = new Recipe();
            newRecipe.EnterRecipe();
            recipes.Add(newRecipe);
            MessageBox.Show("Recipe entered successfully!");
        }

        private void ViewAllRecipes_Click(object sender, RoutedEventArgs e)
        {
            if (recipes == null || recipes.Count == 0)
            {
                MessageBox.Show("No recipes available.");
                return;
            }

            var recipeNames = recipes.OrderBy(r => r.RecipeName).Select(r => r.RecipeName);
            string recipeList = string.Join("\n", recipeNames);
            MessageBox.Show("List of Recipes:\n\n" + recipeList);
        }

        private void SelectRecipe_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = Microsoft.VisualBasic.Interaction.InputBox("Enter the name of the recipe you want to display:", "Recipe Selection");

            if (string.IsNullOrWhiteSpace(recipeName))
            {
                MessageBox.Show("Please enter a valid recipe name.");
                return;
            }

            Recipe selectedRecipe = recipes?.Find(r => r.RecipeName == recipeName);

            if (selectedRecipe != null)
            {
                selectedRecipe.DisplayRecipe();
            }
            else
            {
                MessageBox.Show("Recipe not found!");
            }
        }

        private void ScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = Microsoft.VisualBasic.Interaction.InputBox("Enter the name of the recipe you want to scale:", "Recipe Scaling");

            if (string.IsNullOrWhiteSpace(recipeName))
            {
                MessageBox.Show("Please enter a valid recipe name.");
                return;
            }

            Recipe scaleRecipe = recipes?.Find(r => r.RecipeName == recipeName);

            if (scaleRecipe != null)
            {
                scaleRecipe.ScaleRecipe();
                MessageBox.Show("Recipe scaled successfully!");
            }
            else
            {
                MessageBox.Show("Recipe not found!");
            }
        }

        private void ResetQuantities_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = Microsoft.VisualBasic.Interaction.InputBox("Enter the name of the recipe you want to reset quantities:", "Reset Quantities");

            if (string.IsNullOrWhiteSpace(recipeName))
            {
                MessageBox.Show("Please enter a valid recipe name.");
                return;
            }

            Recipe recipeToReset = recipes?.Find(r => r.RecipeName == recipeName);

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

        private void ClearData_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = Microsoft.VisualBasic.Interaction.InputBox("Enter the name of the recipe you want to clear:", "Clear Recipe Data");

            if (string.IsNullOrWhiteSpace(recipeName))
            {
                MessageBox.Show("Please enter a valid recipe name.");
                return;
            }

            Recipe clearRecipe = recipes?.Find(r => r.RecipeName == recipeName);

            if (clearRecipe != null)
            {
                clearRecipe.ClearData();
                recipes.Remove(clearRecipe);
                MessageBox.Show("Data has been cleared successfully!");
            }
            else
            {
                MessageBox.Show("Recipe not found!");
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

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
            if (recipes == null || recipes.Count == 0)
            {
                MessageBox.Show("No recipes available.");
                return;
            }

            // Filter the recipes based on the provided criteria
            List<Recipe> filteredRecipes = new List<Recipe>();
            foreach (var recipe in recipes)
            {
                if (recipe.IngredientList != null &&
                    recipe.IngredientList.Any(i => i.Name.ToLower().Contains(ingredientName.ToLower())) &&
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
                var recipeNames = filteredRecipes.OrderBy(r => r.RecipeName).Select(r => r.RecipeName);
                string recipeList = string.Join("\n", recipeNames);
                MessageBox.Show("Filtered Recipes:\n\n" + recipeList);
            }
        }
    }
}
