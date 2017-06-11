using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeuralNetworking;
using System;

namespace NeuralNetworkingTests
{
	[TestClass]
	public class NeuronCountTests
	{
		[TestMethod, ExpectedException(typeof(ArgumentException))]
		public void cannot_be_zero() =>
			new NeuronCount(0);

		[TestMethod, ExpectedException(typeof(ArgumentException))]
		public void cannot_be_negative() =>
			new NeuronCount(-1);

		[TestMethod]
		public void can_be_one() =>
			new NeuronCount(1);

		[TestMethod]
		public void can_be_two() =>
			new NeuronCount(2);
	}
}
