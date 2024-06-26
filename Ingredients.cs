using System;

namespace Sashiel_ST10028058_PROG6221_POE
{
    // Class representing an ingredient in a recipe
    internal class Ingredients
    {
        // Properties of the ingredient
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string UnitOfMeasurement { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }

        // Constructor to initialize an ingredient with specified values
        public Ingredients(string name, double quantity, string unitOfMeasurement, int calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            UnitOfMeasurement = unitOfMeasurement;
            Calories = calories;
            FoodGroup = foodGroup;
        }

        // Method to reset the quantity of the ingredient to zero
        public void ResetQuantities()
        {
            Quantity = 0;
        }
    }
}
