using System;

namespace NeuralNetworking
{
	public class NeuronCount
	{
		int value;

		public static implicit operator NeuronCount(int value) =>
			new NeuronCount(value);

		public static implicit operator int(NeuronCount neuronCount) =>
			neuronCount.value;

		public NeuronCount(int value)
		{
			if (value < 1)
				throw new ArgumentException("Neuron count cannot be less than 1", nameof(value));
			this.value = value;
		}
	}
}
