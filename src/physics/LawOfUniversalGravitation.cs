using System;
using Vector;

public class LawOfUniversalGravitation
{
	private const double GravitationalConstant = 6.67430e-11; // in m^3 kg^-1 s^-2

	private static double GravitationalForce(double mass1, double mass2, double distance)
	{
		if (distance <= 0)
			throw new ArgumentException("Distance must be greater than zero.");
		return GravitationalConstant * (mass1 * mass2) / (distance * distance);
	}

    public static Vector3 VectorGravitationalForce(
		double mass1, 
		double mass2,
        Vector3 position1,
        Vector3 position2)
	{
		var direction = position2 - position1;
		var distance = direction.Magnitude();

		if (distance <= 0)
			throw new ArgumentException("Distance must be greater than zero.");

		var forceMagnitude = GravitationalForce(mass1, mass2, distance);

		return forceMagnitude * direction.Normalize();
	}
}