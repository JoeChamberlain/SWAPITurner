using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAPITurner
{
    public enum FilmEntity { characters, planets, starships };

    public class FilmArgs
    {


        // --Constructors--
        public FilmArgs() { }

        public FilmArgs(string fName, string fEntity, string fProperty)
        {
            filmNameArg = fName;
            filmEntityArg = ParseEntity(fEntity);
            filmPropertyArg = fProperty;
        }

        // --Properties--
        // First the name of a film will be given to request from the API.
        public string filmNameArg { get; set; }
        // Further specify a specific entity from that film. There are only three types of entity acceptable.
        public FilmEntity filmEntityArg { get; set; }
        // Filter by a specific property of that film's specified entity.
        public string filmPropertyArg { get; set; }


        // --Private Methods--
        private static FilmEntity ParseEntity(string entityArg)
        {
            FilmEntity convertedEnum;
            Enum.TryParse<FilmEntity>(entityArg, out convertedEnum);

            if(Enum.IsDefined(typeof(FilmEntity), convertedEnum))
            {
                return convertedEnum;
            }
            else
            {
                Console.WriteLine("An invalid [film entity] was entered. Defaulting to 'characters'.");

                return FilmEntity.characters;
            }
        }
    }

}
