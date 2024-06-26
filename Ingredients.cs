using System;

namespace Sashiel_ST10028058_PROG6221_POE
{
    internal class Ingredients
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string UnitOfMeasurement { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }

        public Ingredients(string name, double quantity, string unitOfMeasurement, int calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            UnitOfMeasurement = unitOfMeasurement;
            Calories = calories;
            FoodGroup = foodGroup;
        }

        public void ResetQuantities()
        {
            Quantity = 0;
        }
    }
}
