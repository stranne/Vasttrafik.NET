namespace Stranne.VasttrafikNET.ApiModels.JourneyPlanner.Enums
{
    /// <summary>
    /// Journey transportation type
    /// </summary>
    public enum JourneyType
    {
        /// <summary>
        /// Västtågen
        /// </summary>
        Vasttagen = 1,
        /// <summary>
        /// Long distance train
        /// </summary>
        LongDistanceTrain = 2,
        /// <summary>
        /// Regional train
        /// </summary>
        RegionalTrain = 3,
        /// <summary>
        /// Bus
        /// </summary>
        Bus = 4,
        /// <summary>
        /// Buss
        /// </summary>
        Boat = 5,
        /// <summary>
        /// Boat
        /// </summary>
        Tram = 6,
        /// <summary>
        /// Tram
        /// </summary>
        Taxi = 7,
        /// <summary>
        /// Taxi
        /// </summary>
        Walk = 8,
        /// <summary>
        /// Walk
        /// </summary>
        Bike = 9,
        /// <summary>
        /// Car
        /// </summary>
        Car = 10
    }
}