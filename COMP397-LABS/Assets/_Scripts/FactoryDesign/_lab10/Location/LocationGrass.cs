using UnityEngine;

public class LocationGrass : ILocation
{
    public LocationGrass()
    {
        GenerateLocation();
    }
    public void GenerateLocation()
    {
        Debug.Log($"Generating Grass Area");
    }
}