namespace KalenderPlaner
{
    internal class Genome<T>
    {
        public float Fitness;
        public T Parameter;

        public Genome(T parameter)
        {
            Parameter = parameter;
            Fitness = 0;
        }

        public Genome()
        {
            
        }
    }
}