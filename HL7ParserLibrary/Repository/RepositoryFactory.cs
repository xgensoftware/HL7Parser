using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7Parser.Repository
{
    /// <summary>
    /// Factory class to instantiate repository based on IEvent
    /// </summary>
    public class RepositoryFactory
    {
        public static T CreateRepository<T>()
        {           
            return (T)Activator.CreateInstance<T>();
            //return (T)Activator.CreateInstance(Type.GetType(string.Format("HL7Parser.Repository.{0}Repository", repoName)));
        }
    }
}
