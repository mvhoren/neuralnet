using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeuralNetworking;
using System.Linq;

namespace NeuralNetworkingTests
{
	[TestClass]
	public class NeuralNetworkTests
	{
		readonly NeuronCount expectedInputs = 1;
		readonly NeuronCount[] expectedNeuronsPerHiddenLayer = new NeuronCount[] { 2, 3 };
		readonly NeuronCount expectedOutputs = 4;
		readonly int expectedNumberOfLayers = 5;

		INeuralNetwork network;

		[TestInitialize]
		public void Initialize()
		{
			network = new NeuralNetwork(2, 2, 3, 3, 3);
		}

		[TestMethod, ExpectedException(typeof(ArgumentException))]
		public void throws_when_given_null_hidden_layers() =>
			new NeuralNetwork(expectedInputs, expectedOutputs, null);

		[TestMethod, ExpectedException(typeof(ArgumentException))]
		public void throws_when_given_no_hidden_layers() =>
			new NeuralNetwork(expectedInputs, expectedOutputs, new NeuronCount[] { });

		[TestMethod]
		public void has_expected_number_of_layers() =>
			Assert.AreEqual(expectedNumberOfLayers, network.Layers.Length);

		// TODO: If neurons were modeled as an IReadOnlyCollection<Neuron> with a Length expressed as NeuronCount we would not have these casts :)
		[TestMethod]
		public void has_expected_number_of_neurons_per_layer() =>
			Enumerable.SequenceEqual(
				new[] { (int)expectedInputs }.Concat(expectedNeuronsPerHiddenLayer.Select(nc => (int)nc)).Concat(new[] { (int)expectedOutputs }),
				network.Layers.Select(l => l.Neurons.Length)
			);

		[TestMethod]
		public void each_neuron_on_each_layer_is_connected_to_each_neuron_on_the_previous_layer() =>
			network
				.Layers
				.Skip(1)
				.Zip(
					network.Layers,
					(currentLayer, previousLayer) => currentLayer.Neurons.All(n => Enumerable.SequenceEqual(n.Synapses, previousLayer.Neurons))
				);
	}
}
