using System;
using System.Linq;

namespace NeuralNetworking
{

	public partial class NeuralNetwork : INeuralNetwork
	{
		INeuralNetworkLayer[] INeuralNetwork.Layers => layers;

		readonly NeuralNetworkLayer[] layers;

		public NeuralNetwork(NeuronCount inputs, NeuronCount outputs, params NeuronCount[] hiddenLayers)
		{
			if (hiddenLayers == null || !hiddenLayers.Any())
				throw new ArgumentException("At least one hidden layer is required", nameof(hiddenLayers));

			NeuralNetworkLayer previousLayer = null;

			layers = new[] { inputs }
				.Concat(hiddenLayers)
				.Concat(new[] { outputs })
				.Select(nc =>
				{
					previousLayer = previousLayer == null ? new NeuralNetworkLayer(nc) : new NeuralNetworkLayer(nc, previousLayer);
					return previousLayer;
				})
				.ToArray();
		}
	}
}