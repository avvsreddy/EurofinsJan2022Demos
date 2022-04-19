using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IoCDemoWebApplication.Models
{

    public interface ISecure
    {
        void Secure();
    }

    public class DummySecure : ISecure
    {
        public void Secure()
        {
            // implement dummy security
        }
    }


    public class RealSecure : ISecure
    {
        public void Secure()
        {
            // implement with real security
        }
    }

    public class DummyProductsRepo : IProductsRepo
    {
        private readonly ISecure secure;

        public DummyProductsRepo(ISecure secure)
        {
            this.secure = secure;
        }
        public List<string> GetProducts()
        {
            secure.Secure();
            return new List<string>
            {
                "Product 1",
                "Product 2",
                "Product 3",
                "Product 4",
                "Product 5"
            };
        }
    }

    public class RealProductsRepo : IProductsRepo
    {
        private readonly ISecure secure;

        public RealProductsRepo(ISecure secure)
        {
            this.secure = secure;
        }
        public List<string> GetProducts()
        {
            secure.Secure();
            return new List<string>
            {
                "Product 1 DB",
                "Product 2 DB",
                "Product 3 DB",
                "Product 4 DB",
                "Product 5 DB"
            };
        }
    }
}