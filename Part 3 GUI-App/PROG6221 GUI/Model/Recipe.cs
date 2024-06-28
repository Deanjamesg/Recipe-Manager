using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_GUI.Model
{
    public class Recipe
    {
        public double ScaleFactor { get; set; }
        public string RecipeName { get; set; }
        public List<Step> Steps { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public double TotalCalories { get; set; }

        public Recipe()
        {
            Steps = new List<Step>();
            Ingredients = new List<Ingredient>();
        }

        //END OF RECIPE CLASS
        //-------------------------------------------------------------------------------------------------------------------------------------
    }
}
