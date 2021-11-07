using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {

        const double DEFAULT_CALORIES = 2;


        private string flourType;
        private string bakingTechnique;
        private int weight;


        public Dough(string _flourType, string _bakingTechnique, int _weight)
        {
            this.FlourType = _flourType;
            this.BakingTecknique = _bakingTechnique;
            this.Weight = _weight;
        }

        public string FlourType
        {

            get { return flourType; }

            private set
            {
                string lowerFlouerType = value.ToLower();
                if (lowerFlouerType != "white" && lowerFlouerType != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;

            }
        }


        public string BakingTecknique
        {
            get
            {
                return bakingTechnique;
            }

            private set
            {
                string lowerType = value.ToLower();
                if (lowerType != "crispy" &&
                    lowerType != "chewy" &&
                    lowerType != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;

            }
        }


        public int Weight
        {
            get
            {
                return weight;
            }

            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }


        public double GetCalories()
        {
            var flouerModifier = this.GetFlourModifier(FlourType);
            var bakingTechniqueModifier = this.GetBakingTechniqueModifier(BakingTecknique);

            return DEFAULT_CALORIES * this.Weight * flouerModifier * bakingTechniqueModifier;
        }


        private double GetFlourModifier(string _modifierName)
        {
            string lowerModifier = _modifierName.ToLower();
            if (lowerModifier == "white")
            {
                return 1.5;
            }

            return 1;           
        }



        private double GetBakingTechniqueModifier(string _modifierName)
        {
            string lowerModifierName = _modifierName.ToLower();
            if (lowerModifierName == "crispy")
            {
                return 0.9;
            }
            if (lowerModifierName == "chewy")
            {
                return 1.1;
            }

            return 1; //homemade
        }








    }
}
