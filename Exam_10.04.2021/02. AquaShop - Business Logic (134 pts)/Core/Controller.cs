using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {

        private readonly List<IAquarium> aquariums;
        private DecorationRepository decorations;


        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }


        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType == nameof(FreshwaterAquarium))
            {
                if (this.aquariums.FirstOrDefault(a => a.Name == aquariumName) == null)
                {
                    this.aquariums.Add(new FreshwaterAquarium(aquariumName));
                    return $"Successfully added {aquariumType}.";
                }

            }
            else if (aquariumType == nameof(SaltwaterAquarium))
            {
                if (this.aquariums.FirstOrDefault(a => a.Name == aquariumName) == null)
                {
                    this.aquariums.Add(new SaltwaterAquarium(aquariumName));
                    return $"Successfully added {aquariumType}.";
                }
            }
            else
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }

            return null;
        }



        public string AddDecoration(string decorationType)
        {
            if (decorationType == nameof(Ornament))
            {
                if (decorations.FindByType(decorationType) == null)
                {
                    this.decorations.Add(new Ornament());
                    return $"Successfully added {decorationType}.";
                }
            }
            else if (decorationType == nameof(Plant))
            {
                if (decorations.FindByType(decorationType) == null)
                {
                    this.decorations.Add(new Plant());
                    return $"Successfully added {decorationType}.";
                }
            }
            else
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }


            return null;
        }




        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            var aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);
            IFish fish = null;

            if (fishType == nameof(FreshwaterFish))
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == nameof(SaltwaterFish))
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException("Invalid fish type.");
            }

            if (aquarium.GetType().Name == nameof(FreshwaterAquarium) && fishType == nameof(SaltwaterFish))
            {
                return "Water not suitable.";
            }
            else if (aquarium.GetType().Name == nameof(SaltwaterAquarium) && fishType == nameof(FreshwaterFish))
            {
                return "Water not suitable.";
            }

            aquarium.AddFish(fish);
            return $"Successfully added {fishType} to {aquariumName}.";
        }


        public string CalculateValue(string aquariumName)
        {
            var aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);
            decimal value = 0.0m;

            foreach (var f in aquarium.Fish)
            {
                value += f.Price;
            }

            foreach (var d in aquarium.Decorations)
            {
                value += d.Price;
            }

            return $"The value of Aquarium {aquariumName} is {value}.";
        }



        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            foreach (var fs in aquarium.Fish)
            {
                fs.Eat();
            }

            return $"Fish fed: {aquarium.Fish.Count}";
        }


        public string InsertDecoration(string aquariumName, string decorationType)
        {

            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);
            IDecoration decoration = null;

            if (decorationType == nameof(Ornament) && aquarium.Decorations.FirstOrDefault(d => d.GetType().Name == decorationType) == null)
            {
                decoration = new Ornament();             
                aquarium.AddDecoration(decoration);                           
            }
            else if (decorationType == nameof(Plant) && aquarium.Decorations.FirstOrDefault(d => d.GetType().Name == decorationType) == null)
            {
                decoration = new Plant();                            
                aquarium.AddDecoration(decoration);               
            }
            else
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }

            this.decorations.Remove(decoration);
            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        //Here
        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var aquarium in this.aquariums)
            {
                stringBuilder.AppendLine(aquarium.GetInfo());
            }

            return stringBuilder.ToString().TrimEnd();


        }
    }
}
