using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestSharp;
using RestSharp.Deserializers;

namespace SWAPITurner
{
    class Program
    {
        // --Properties--
        const string baseURL = "https://swapi.co/api/";
        const int numArguments = 3;

        static void Main(string[] args)
        {
            if(args.Length != numArguments)
            {
                Console.WriteLine("This application requires three arguments.");
                return;
            }

            FilmArgs consoleArgs = new FilmArgs(args[0], args[1], args[2]);

            APIHandler apiHandler = new APIHandler(consoleArgs);

            apiHandler.GETFromAPI();
        }
    }
}
