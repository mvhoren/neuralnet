using System.Linq;

namespace NeuralNetworking
{
	public partial class NeuralNetwork
	{
		partial class NeuralNetworkLayer : INeuralNetworkLayer
		{
			INeuron[] INeuralNetworkLayer.Neurons => neurons;

			readonly INeuron[] neurons;

			public NeuralNetworkLayer(NeuronCount numberOfNeurons)
			{
				neurons = Enumerable.Range(1, numberOfNeurons)
					.Select(_ => new Neuron())
					.ToArray();
			}

			public NeuralNetworkLayer(NeuronCount numberOfNeurons, NeuralNetworkLayer previousLayer)
			{
				neurons = Enumerable.Range(1, numberOfNeurons).Select(_ => new Neuron(previousLayer)).ToArray();
			}
		}
	}
}
