using System;
using CelestialBody.CelestialBody;

public class VerletPhysicsEngine : IPhysicsEngine
{
	private const double G = 6.67430e-11;
	private const double Softening = 1e-5;

	public void Update(List<CelestialBody> bodies, double dt)
	{
		int n = bodies.Count;

		var accelerations = CalculateAccelerations(bodies);

		for (int i = 0; i < n; i++)
		{
			var body = bodies[i];
			var a = accelerations[i];

			body.Position += body.Velocity * dt + a * (0.5 * dt * dt);
		}

		var newAccelerations = CalculateAccelerations(bodies);

		for (int i = 0; i < n; i++)
		{
			var body = bodies[i];

			body.Velocity += (accelerations[i] + newAccelerations[i]) * (0.5 * dt);
		}
	}

	private Vector3[] CalculateAccelerations(List<CelestialBody> bodies)
	{
		int n = bodies.Count;
		var accelerations = new Vector3[n];

		for (int i = 0; i < n; i++)
			accelerations[i] = Vector3.Zero;

		for (int i = 0; i < n; i++)
		{
			for (int j = i + 1; j < n; j++)
			{
				var bi = bodies[i];
				var bj = bodies[j];

				var direction = bj.Position - bi.Position;
				double distance = direction.Magnitude() + Softening;

				double factor = G / (distance * distance * distance);

				var forceDirection = direction * factor;

				var ai = forceDirection * bj.Mass;
				var aj = forceDirection * bi.Mass;

				accelerations[i] += ai;
				accelerations[j] -= aj;
			}
		}

		return accelerations;
	}
}