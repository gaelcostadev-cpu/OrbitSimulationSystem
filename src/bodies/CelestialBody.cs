
public static class CelestialBody
{
    private string Name { get; }
    private double Mass { get; }
    private Vector.Vector3 Position { get; set; }
    private Vector.Vector3 Velocity { get; set; }
    private Vector.Vector3 Acceleration { get; set; }

    static CelestialBody(
        string name, 
        double mass, 
        Vector.Vector3 position, 
        Vector.Vector3 velocity, 
        Vector.Vector3 acceleration)
    {
        Name = name;
        Mass = mass;
        Position = position;
        Velocity = velocity;
        Acceleration = acceleration;
    }
}
