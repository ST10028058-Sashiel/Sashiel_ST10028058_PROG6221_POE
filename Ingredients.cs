using System;

namespace Sashiel_ST10028058_PROG6221_POE
{
    // Class representing an ingredient in a recipe
    internal class Ingredient
    {
        // Properties of the ingredient
        public string Name { get; set; }
        public double Quantity { get; set; }
        public double OriginalQuantity { get; private set; }
        public string Unit { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }

        // Constructor to initialize an ingredient with specified values
        public Ingredient(string name, double quantity, string unit, int calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            OriginalQuantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
        }

        // Method to reset the quantity of the ingredient to its original value
        public void ResetQuantity()
        {
            Quantity = OriginalQuantity;
        }
    }
}

//coder attribution https://javatpoint.com/wpf-in-c-sharp
//coder attribution: A. Troelsen and P. Japikse. 2022. Pro C# 10 with .NET 6. 11th ed.West Chester, OH, USA. Apress.