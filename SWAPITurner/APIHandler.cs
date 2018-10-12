using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestSharp;
using RestSharp.Deserializers;

namespace SWAPITurner
{

    public class APIHandler
    {
        // --Constructors--
        public APIHandler() { }

        public APIHandler(FilmArgs fArgs)
        {
            filmArgs = fArgs;
        }

        // --Fields--
        // Base URI from SWAPI
        const string baseURL = "https://swapi.co/api/";
        // Search string for finding film name by string. Searches the "title" field.
        const string filmSearchURL = "films/?search=";
        // Object for organizing arguments from console input
        FilmArgs filmArgs = new FilmArgs();


        // --Public Methods--
        public void GETFromAPI()
        {
            var request = new RestRequest();
            request.RequestFormat = DataFormat.Json;
            request.Resource = filmSearchURL + Uri.EscapeDataString(filmArgs.filmNameArg);

            var filmResponse = GETAsync<ResultsModel>(request, baseURL);

            foreach(APIModelFilm a in filmResponse.Result.results)
            {
                switch(filmArgs.filmEntityArg)
                {
                    case FilmEntity.characters:
                        GETEntityArgPeople(a.characters);
                        break;
                    case FilmEntity.planets:
                        GETEntityArgPlanet(a.planets);
                        break;
                    case FilmEntity.starships:
                        GETEntityArgStarship(a.starships);
                        break;
                }
            }
        }

        /*private void GETEntityArg<R>(List<string> argList, FilmEntity fEntity) where R : new()
        {
            var request = new RestRequest();
            request.RequestFormat = DataFormat.Json;

            foreach (string s in argList)
            {
                request.Resource = s;
                var entityResponse = GETAsync<R>(request);

                Console.WriteLine();
            }
        }*/

        private void GETEntityArgPeople(List<string> argList)
        {
            var request = new RestRequest();
            request.RequestFormat = DataFormat.Json;

            foreach (string s in argList)
            {

                var entityResponse = GETAsync<APIModelPeople>(request,s);

                Console.WriteLine();
            }
        }
        private void GETEntityArgPlanet(List<string> argList)
        {
            var request = new RestRequest();
            request.RequestFormat = DataFormat.Json;

            foreach (string s in argList)
            {
                var entityResponse = GETAsync<APIModelPlanet>(request,s);

                Console.WriteLine();
            }
        }
        private void GETEntityArgStarship(List<string> argList)
        {
            var request = new RestRequest();
            request.RequestFormat = DataFormat.Json;

            foreach (string s in argList)
            {
                request.Resource = s.Replace(baseURL,"");
                var entityResponse = GETAsync<APIModelStarship>(request,s);
                
                 Console.WriteLine(entityResponse.Result.name);                
            }
        }

        // --Private Methods--
        private async Task<T> GETAsync<T>(RestRequest request, string URL)
        {
            var client = new RestClient
            {
                BaseUrl = new Uri(baseURL)
            };

            IRestResponse<T> response = await client.ExecuteTaskAsync<T>(request);
            return response.Data;
        }
    }
}
