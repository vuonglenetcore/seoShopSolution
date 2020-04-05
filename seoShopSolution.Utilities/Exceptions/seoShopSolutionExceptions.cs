using System;

namespace seoShopSolution.Utilities.Exceptions
{
    public class seoShopSolutionExceptions : Exception
    {
        public seoShopSolutionExceptions()
        {
        }

        public seoShopSolutionExceptions(string message)
        {
        }

        public seoShopSolutionExceptions(string message, Exception inner) : base(message, inner)
        {
        }
    }
}