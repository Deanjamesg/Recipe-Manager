namespace PROG6221_POE
{
    //https://www.w3schools.com/cs/cs_enums.php
    //Delcaring a enum for the unit of measurement called UnitOM
    public enum UnitOM
    {
        Teaspoon = 1,
        Tablespoon,
        Cup,
        Gram,
        Kilogram,
        Milliliter,
        Litre,
        Whole,
        Clove,
        Slice
    }

    public enum FoodGroup
    {
        Vegetable = 1,
        Starch,
        Fruit,
        Grain,
        Meat,
        Poultry,
        Dairy,
        Oils,
        Spice
    }

    public class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public UnitOM UnitOfMeasurement { get; set; }
        public FoodGroup FoodGroup { get; set; }
        public double Calories { get; set; }
        public double OriginalQuantity { get; private set; }
        public double OriginalCalories { get; private set; }
        public UnitOM OriginalUnitOfMeasurement { get; private set; }

        public void SetOriginalValues()
        {
            OriginalQuantity = Quantity;
            OriginalCalories = Calories;
            OriginalUnitOfMeasurement = UnitOfMeasurement;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        public void ResetValues()
        {
            Quantity = OriginalQuantity;
            Calories = OriginalCalories;
            UnitOfMeasurement = OriginalUnitOfMeasurement;
        }

        //END OF INGREDIENT CLASS
        //-------------------------------------------------------------------------------------------------------------------------------------
    }
}
