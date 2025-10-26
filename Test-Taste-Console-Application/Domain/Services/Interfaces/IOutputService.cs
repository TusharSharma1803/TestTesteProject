namespace Test_Taste_Console_Application.Domain.Services.Interfaces
{
    ///<summary>
    /// An output service that can show data from the Solar System OpenData API<see href="https://api.le-systeme-solaire.net/"/> to a user via the console. 
    ///</summary>
    public interface IOutputService
    {
        void OutputAllPlanetsAndTheirMoonsToConsole();
        void OutputAllMoonsAndTheirMassToConsole();
        void OutputAllPlanetsAndTheirAverageMoonGravityToConsole();

        //[Tushar sharma] - 26th oct. 2025
        // Added a interface method so that we call also access it in the program.cs file
        // To call the method after having a dependency filled interface.
        /// <summary>
        ///     Console the average temperature of planets' moons
        /// </summary>
        void OutputAllPlanetsAndTheirAverageMoonTemperatureToConsole();
    }
}
