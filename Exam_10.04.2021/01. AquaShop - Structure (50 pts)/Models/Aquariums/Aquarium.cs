using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private List<IDecoration> decorations;
        private List<IFish> fish;


        public Aquarium(string name, int capacity)
        {
            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();
            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Aquarium name cannot be null or empty.");
                }

                this.name = value;
            }
        }


        public int Capacity { get; private set; }



        public int Comfort
        {
            get
            {
                return this.decorations.Sum(d => d.Comfort);
            }
        }


        public ICollection<IDecoration> Decorations
        {
            get
            {
                return this.decorations.AsReadOnly();
            }
        }


        public ICollection<IFish> Fish
        {
            get
            {
                return this.fish.AsReadOnly();
            }
        }

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }

        //HERE
        public void AddFish(IFish fish)
        {
            if (this.fish.Count < Capacity)
            {
                this.fish.Add(fish);
            }
            else
            {
                throw new InvalidOperationException("Not enough capacity.");
            }
        }

        public void Feed()
        {
            foreach (var f in this.fish)
            {
                f.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{Name} ({this.GetType().Name}):");
            stringBuilder.AppendLine("Fish: ");
            if (fish.Count == 0)
            {
                stringBuilder.Append("none");
            }
            else
            {
                stringBuilder.Append(string.Join(", ", fish));
            }
           
            stringBuilder.AppendLine($"{this.decorations.Count}");
            stringBuilder.AppendLine($"Comfort");

            return stringBuilder.ToString().TrimEnd();
        }


        public bool RemoveFish(IFish fish)
        {
            return this.fish.Remove(fish);
        }
    }
}
