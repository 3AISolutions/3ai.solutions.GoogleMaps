namespace _3ai.solutions.GoogleMaps
{
    public enum TravelMode
    {
        driving,
        walking,
        bicycling,
        transit,
    }

    public enum Avoid
    {
        tolls,
        highways,
        ferries,
    }

    public enum TransitMode
    {
        bus,
        subway,
        train,
        tram,
        rail, //["train", "tram", "subway"]
    }

    public enum TransitRoutingPreference
    {
        less_walking,
        fewer_transfers,
    }

    public enum TrafficModel
    {
        best_guess,
        optimistic,
        pessimistic,
    }

    public enum Units
    {
        metric,
        imperial,
    }
}