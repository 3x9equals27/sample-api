namespace Cheezy.Exceptions
{
    public class RecommendationNotFoundException : Exception
    {
        public RecommendationNotFoundException(string message) : base(message)
        {
        }

        public RecommendationNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
