using System;
using System.Linq;
using Test_Taste_Console_Application.Constants;
using Test_Taste_Console_Application.Domain.Objects;
using Test_Taste_Console_Application.Domain.Services.Interfaces;
using Test_Taste_Console_Application.Utilities;

namespace Test_Taste_Console_Application.Domain.Services
{
    /// <inheritdoc />
    public class ScreenOutputService : IOutputService
    {
        private readonly IPlanetService _planetService;

        private readonly IMoonService _moonService;

        public ScreenOutputService(IPlanetService planetService, IMoonService moonService)
        {
            _planetService = planetService;
            _moonService = moonService;
        }

        public void OutputAllPlanetsAndTheirMoonsToConsole()
        {
            //[Tushar sharma] - 26th oct 2025 
            // information for user that the data is loading.
            ConsoleWriter.CreateInfo(OutputString.LoadingData);

            //The service gets all the planets from the API.
            var planets = _planetService.GetAllPlanets().ToArray();

            //[Tushar sharma] - 26th oct 2025 
            // information for user that the loading complete.
            ConsoleWriter.CreateInfo(OutputString.LoadingComplete);

            //If the planets aren't found, then the function stops and tells that to the user via the console.
            if (!planets.Any())
            {
                Console.WriteLine(OutputString.NoPlanetsFound);
                return;
            }

            //[Tushar sharma] - 26th oct 2025 
            // information for user that we are writing the data.
            ConsoleWriter.CreateInfo(OutputString.WritingData);

            //The column sizes and labels for the planets are configured here. 
            var columnSizesForPlanets = new[] { 20, 20, 30, 20 };
            var columnLabelsForPlanets = new[]
            {
                OutputString.PlanetNumber, OutputString.PlanetId, OutputString.PlanetSemiMajorAxis,
                OutputString.TotalMoons
            };

            //The column sizes and labels for the moons are configured here.
            //The second moon's column needs the 2 extra '-' characters so that it's aligned with the planet's column.
            var columnSizesForMoons = new[] { 20, 70 + 2 };
            var columnLabelsForMoons = new[]
            {
                OutputString.MoonNumber, OutputString.MoonId
            };

            //The for loop creates the correct output.
            for (int i = 0, j = 1; i < planets.Length; i++, j++)
            {
                //First the line is created.
                ConsoleWriter.CreateLine(columnSizesForPlanets);

                //Under the line the header is created.
                ConsoleWriter.CreateText(columnLabelsForPlanets, columnSizesForPlanets);

                //Under the header the planet data is shown.
                ConsoleWriter.CreateText(
                    new[]
                    {
                        j.ToString(), CultureInfoUtility.TextInfo.ToTitleCase(planets[i].Id),
                        planets[i].SemiMajorAxis.ToString(),
                        planets[i].Moons.Count.ToString()
                    },
                    columnSizesForPlanets);

                //Under the planet data the header for the moons is created.
                ConsoleWriter.CreateLine(columnSizesForPlanets);
                ConsoleWriter.CreateText(columnLabelsForMoons, columnSizesForMoons);

                //The for loop creates the correct output.
                for (int k = 0, l = 1; k < planets[i].Moons.Count; k++, l++)
                {
                    ConsoleWriter.CreateText(
                        new[]
                        {
                            l.ToString(), CultureInfoUtility.TextInfo.ToTitleCase(planets[i].Moons.ElementAt(k).Id)
                        },
                        columnSizesForMoons);
                }

                //Under the data the footer is created.
                ConsoleWriter.CreateLine(columnSizesForMoons);
                
                //[Tushar sharma] - 26th oct 2025 
                // information for user that the writing complete.
                ConsoleWriter.CreateInfo(OutputString.WritingComplete);

                ConsoleWriter.CreateEmptyLines(2);

                

                /*
                    This is an example of the output for the planet Earth:
                    --------------------+--------------------+------------------------------+--------------------
                    Planet's Number     |Planet's Id         |Planet's Semi-Major Axis      |Total Moons
                    10                  |Terre               |0                             |1
                    --------------------+--------------------+------------------------------+--------------------
                    Moon's Number       |Moon's Id
                    1                   |La Lune
                    --------------------+------------------------------------------------------------------------
                */
            }
        }

        public void OutputAllMoonsAndTheirMassToConsole()
        {
            //[Tushar sharma] - 26th oct 2025 
            // information for user that the data is loading.
            ConsoleWriter.CreateInfo(OutputString.LoadingData);

            //The function works the same way as the PrintAllPlanetsAndTheirMoonsToConsole function. You can find more comments there.
            var moons = _moonService.GetAllMoons().ToArray();

            //[Tushar sharma] - 26th oct 2025 
            // information for user that the loading complete.
            ConsoleWriter.CreateInfo(OutputString.LoadingComplete);

            if (!moons.Any())
            {
                Console.WriteLine(OutputString.NoMoonsFound);
                return;
            }

            //[Tushar sharma] - 26th oct 2025 
            // information for user that we are writing the data.
            ConsoleWriter.CreateInfo(OutputString.WritingData);

            var columnSizesForMoons = new[] { 20, 20, 30, 20 };
            var columnLabelsForMoons = new[]
            {
                OutputString.MoonNumber, OutputString.MoonId, OutputString.MoonMassExponent, OutputString.MoonMassValue
            };

            ConsoleWriter.CreateHeader(columnLabelsForMoons, columnSizesForMoons);

            for (int i = 0, j = 1; i < moons.Length; i++, j++)
            {
                ConsoleWriter.CreateText(
                    new[]
                    {
                        j.ToString(), CultureInfoUtility.TextInfo.ToTitleCase(moons[i].Id),
                        moons[i].MassExponent.ToString(), moons[i].MassValue.ToString()
                    },
                    columnSizesForMoons);
            }

            ConsoleWriter.CreateLine(columnSizesForMoons);

            //[Tushar sharma] - 26th oct 2025 
            // information for user that the writing complete.
            ConsoleWriter.CreateInfo(OutputString.WritingComplete);

            ConsoleWriter.CreateEmptyLines(2);

            

            /*
                This is an example of the output for the moon around the earth:
                --------------------+--------------------+------------------------------+--------------------
                Moon's Number       |Moon's Id           |Moon's Mass Exponent          |Moon's Mass Value
                --------------------+--------------------+------------------------------+--------------------
                1                   |Lune                |22                            |7,346             
                ...more data...
                --------------------+--------------------+------------------------------+--------------------
             */
        }

        public void OutputAllPlanetsAndTheirAverageMoonGravityToConsole()
        {
            //[Tushar sharma] - 26th oct 2025 
            // information for user that the data is loading.
            ConsoleWriter.CreateInfo(OutputString.LoadingData);

            //The function works the same way as the PrintAllPlanetsAndTheirMoonsToConsole function. You can find more comments there.
            var planets = _planetService.GetAllPlanets().ToArray();

            //[Tushar sharma] - 26th oct 2025 
            // information for user that the loading complete.
            ConsoleWriter.CreateInfo(OutputString.LoadingComplete);

            if (!planets.Any())
            {
                Console.WriteLine(OutputString.NoMoonsFound);
                return;
            }

            //[Tushar sharma] - 26th oct 2025 
            // information for user that we are writing the data.
            ConsoleWriter.CreateInfo(OutputString.WritingData);

            var columnSizes = new[] { 20, 30 };
            var columnLabels = new[]
            {
                OutputString.PlanetId, OutputString.PlanetMoonAverageGravity
            };


            ConsoleWriter.CreateHeader(columnLabels, columnSizes);

            foreach(Planet planet in planets)
            {
                if(planet.HasMoons())
                {
                    ConsoleWriter.CreateText(new string[] { $"{planet.Id}", $"{planet.AverageMoonGravity}" }, columnSizes);
                }
                else
                {
                    ConsoleWriter.CreateText(new string[] { $"{planet.Id}", $"-" }, columnSizes);
                }
            }

            ConsoleWriter.CreateLine(columnSizes);

            //[Tushar sharma] - 26th oct 2025 
            // information for user that the writing complete.
            ConsoleWriter.CreateInfo(OutputString.WritingComplete);

            ConsoleWriter.CreateEmptyLines(2);

            

            /*
                --------------------+--------------------------------------------------
                Planet's Number     |Planet's Average Moon Gravity
                --------------------+--------------------------------------------------
                1                   |0.0f
                --------------------+--------------------------------------------------
            */
        }

        //[Tushar sharma] - 26th oct. 2025
        /// <summary>
        ///     Console the Planets with the Average temperature of planets' moons
        /// </summary>
        public void OutputAllPlanetsAndTheirAverageMoonTemperatureToConsole()
        {
            //[Tushar sharma] - 26th oct 2025 
            // information for user that the data is loading.
            ConsoleWriter.CreateInfo(OutputString.LoadingData);

            //The function works the same way as the PrintAllPlanetsAndTheirMoonsToConsole function. You can find more comments there.
            var planets = _planetService.GetAllPlanets().ToArray();

            //[Tushar sharma] - 26th oct 2025 
            // information for user that the loading complete.
            ConsoleWriter.CreateInfo(OutputString.LoadingComplete);

            if (!planets.Any())
            {
                Console.WriteLine(OutputString.NoMoonsFound);
                return;
            }

            //[Tushar sharma] - 26th oct 2025 
            // information for user that we are writing the data.
            ConsoleWriter.CreateInfo(OutputString.WritingData);

            var columnSizes = new[] { 20, 30 };
            var columnLabels = new[]
            {
                OutputString.PlanetId, OutputString.PlanetMoonAverageTemperature
            };


            ConsoleWriter.CreateHeader(columnLabels, columnSizes);

            foreach (Planet planet in planets)
            {
                if (planet.HasMoons())
                {
                    ConsoleWriter.CreateText(new string[] { $"{planet.Id}", $"{planet.AverageMoonTemperature}" }, columnSizes);
                }
                else
                {
                    ConsoleWriter.CreateText(new string[] { $"{planet.Id}", $"-" }, columnSizes);
                }
            }

            ConsoleWriter.CreateLine(columnSizes);
            //[Tushar sharma] - 26th oct 2025 
            // information for user that the writing complete.
            ConsoleWriter.CreateInfo(OutputString.WritingComplete);
            ConsoleWriter.CreateEmptyLines(2);


            /*
                Example of showing how the data will be shown to the console.
                --------------------+--------------------------------------------------
                Planet's Number     |Planet's Average Moon Temperature
                --------------------+--------------------------------------------------
                1                   |0.0f
                --------------------+--------------------------------------------------
            */
        }
    }
}
