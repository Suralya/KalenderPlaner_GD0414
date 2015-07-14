namespace BackpackProblem
{
    internal class Item
    {
        public string Name;
        public int Weight;
        public int Worth;

        public Item(int weigth, int worth, string name)
        {
            Weight = weigth;
            Worth = worth;
            Name = name;
        }
    }
}