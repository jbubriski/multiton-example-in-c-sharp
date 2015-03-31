using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultitonExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Multiton example:");
            Console.WriteLine("");

            var policyManager = new PolicyManager();

            var policyCarA = policyManager.GetActivePolicy("Car");
            var policyCarB = policyManager.GetActivePolicy("Car");
            var policyHouseA = policyManager.GetActivePolicy("House");
            var policyHouseB = policyManager.GetActivePolicy("House");

            Console.WriteLine("Car Policy A ID: {0}", policyCarA.Id);
            Console.WriteLine("Car Policy B ID: {0}", policyCarB.Id);

            Console.WriteLine("House Policy A ID: {0}", policyHouseA.Id);
            Console.WriteLine("House Policy B ID: {0}", policyHouseB.Id);

            Console.WriteLine("");
            Console.WriteLine("Enter to exit...");

            Console.ReadLine();
        }
    }

    public class Policy
    {
        public Guid Id { get; set; }
        
        public string Type { get; set; }
        
        public Policy(string type)
        {
            Id = Guid.NewGuid();

            Type = type;
        }
    }

    public class PolicyManager
    {
        // Can be static
        private Dictionary<string, Policy> _policies = new Dictionary<string, Policy>();

        public Policy GetActivePolicy(string type)
        {
            if (!_policies.ContainsKey(type))
            {
                _policies[type] = new Policy(type);
            }

            return _policies[type];
        }
    }
}
