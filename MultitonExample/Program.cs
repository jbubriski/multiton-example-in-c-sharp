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

            // Set 2 different references to be the car policy
            var policyCarA = policyManager.GetActivePolicy("Car");
            var policyCarB = policyManager.GetActivePolicy("Car");

            // Set 2 different references to be the house policy
            var policyHouseA = policyManager.GetActivePolicy("House");
            var policyHouseB = policyManager.GetActivePolicy("House");

            // Show that the multiton got the same object twice
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
            // When creating a new policy, generate a new Guid to prove that the multiton is doing it's job
            Id = Guid.NewGuid();

            Type = type;
        }
    }

    /// <summary>
    /// Provides access to policies.
    /// </summary>
    public class PolicyManager
    {
        // This can be static in a console/desktop application, just be wary of potential memory issues
        private Dictionary<string, Policy> _policies = new Dictionary<string, Policy>();

        /// <summary>
        /// Get the current active policy of the given type.
        /// </summary>
        /// <param name="type">The type of policy to retrieve.</param>
        /// <returns>The current active policy of the given type</returns>
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
