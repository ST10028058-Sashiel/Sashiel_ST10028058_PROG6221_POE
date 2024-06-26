using System;

namespace Sashiel_ST10028058_PROG6221_POE
{
    // Class representing an ingredient in a recipe
    internal class Ingredient
    {
        // Properties of the ingredient
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }

        // Constructor to initialize an ingredient with specified values
        public Ingredient(string name, double quantity, string unit, int calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
        }

        // Method to reset the quantity of the ingredient to zero
        public void ResetQuantity()
        {
            Quantity = 0;
        }
    }
}
