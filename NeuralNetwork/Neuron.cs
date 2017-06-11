namespace NeuralNetworking
{
	public partial class NeuralNetwork
	{
		partial class NeuralNetworkLayer
		{
			class Neuron : INeuron
			{
				INeuron[] INeuron.Synapses => synapses;

				readonly INeuron[] synapses;

				public Neuron() { }

				public Neuron(INeuralNetworkLayer previousLayer)
				{
					synapses = previousLayer.Neurons;
				}
			}
		}
	}
}
