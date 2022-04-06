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
        private List<IDecoration> decorations;
        private List<IFish> fishes;
        private string name;
        private int capacity;

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
        }

        public Aquarium()
        {
            this.decorations = new List<IDecoration>();
            this.fishes = new List<IFish>();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Aquarium name cannot be null or empty.");
                }
                name = value;
            }

        }

        public int Capacity

        { get => capacity; private set => capacity = value; }



        public int Comfort => this.decorations.Sum(x => x.Comfort);

        public ICollection<IDecoration> Decorations { get; }

        public ICollection<IFish> Fish { get; }

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.fishes.Count == this.capacity)
            {
                throw new InvalidOperationException("Not enough capacity.");
            }
            this.fishes.Add(fish);
        }

        public void Feed()
        {
            foreach (IFish fish in this.Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.name} ({this.GetType().Name}):");
            sb.AppendLine($"Fish: {(this.fishes.Any() ? string.Join(", ", this.fishes.Select(x => x.Name)) : "none")}");
            sb.AppendLine($"Decorations: {this.decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");
            return sb.ToString();
        }

        public bool RemoveFish(IFish fish)
       => this.fishes.Remove(fish);
    }
}
