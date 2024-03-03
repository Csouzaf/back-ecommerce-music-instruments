namespace ecommerce_music_back.security.Model
{
    public static class RandomNumberGenerate
    {
        private static readonly Random _random = new Random();

        public static int Generate(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}