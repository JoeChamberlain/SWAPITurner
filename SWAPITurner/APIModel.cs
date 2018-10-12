using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAPITurner
{
    //This is responsible for modeling the data to match the JSON schema from SWAPI for easy deserialization through an asynchronous template method.

    public class ResultsModel
    {
        // --Properties--
        public List<APIModelFilm> results { get; set; }
    }

    public class APIModelFilm
    {
        // --Properties--
        public string title { get; set; }
        public List<string> characters { get; set; }
        public List<string> planets { get; set; }
        public List<string> starships { get; set; }
    }

    public class APIModelPlanet
    {
        // --Properties--.
        public string name { get; set; }
        public string diameter { get; set; }
        public string rotation_period { get; set; }
        public string orbital_period { get; set; }
        public string gravity { get; set; }
        public string population { get; set; }
        public string climate { get; set; }
        public string terrain { get; set; }
        public string surface_water { get; set; }
        public string residents { get; set; }
        public string films { get; set; }
        public string url { get; set; }
        public string created { get; set; }
        public string edited { get; set; }

    }
    public class APIModelStarship
    {
        // --Properties--
        public string name { get; set; }
        public string model { get; set; }
        public string starship_class { get; set; }
        public string manufacturer { get; set; }
        public string cost_in_credits { get; set; }
        public string length { get; set; }
        public string crew { get; set; }
        public string passengers { get; set; }
        public string max_atmosphering_speed { get; set; }
        public string hyperdrive_rating { get; set; }
        public string MGLT { get; set; }
        public string cargo_capacity { get; set; }
        public string consumables { get; set; }
        public List<string> films { get; set; }
        public List<string> pilots { get; set; }
        public string url { get; set; }
        public string created { get; set; }
        public string edited { get; set; }
    }
    public class APIModelPeople
    {
        // --Properties--
        public string name { get; set; }
        public string birth_year { get; set; }
        public string eye_color { get; set; }
        public string gender { get; set; }
        public string hair_color { get; set; }
        public string height { get; set; }
        public string mass { get; set; }
        public string skin_color { get; set; }
        public string homeworld { get; set; }
        public string films { get; set; }
        public string species { get; set; }
        public string starships { get; set; }
        public string vehicles { get; set; }
        public string url { get; set; }
        public string created { get; set; }
        public string edited { get; set; }
    }
}
