using System.Collections.Generic;
using Newtonsoft.Json;

namespace Test_Taste_Console_Application.Domain.DataTransferObjects
{
    public class PlanetDto
    {
        public string Id { get; set; }
        public float SemiMajorAxis { get; set; }

        // [Tushar sharma] - 26th oct. 2025 
        // As we are already getting the avgTemp in the api response 
        // We are gonna use it, as it already has the averageTemperature of planets' moon.
        /// <summary>
        ///     Get the average temperature of planets' moon.
        /// </summary>
        [JsonProperty("avgTemp")]
        public float AverageMoonTemperature { get; set; }
        public ICollection<MoonDto> Moons { get; set; }
    }
}