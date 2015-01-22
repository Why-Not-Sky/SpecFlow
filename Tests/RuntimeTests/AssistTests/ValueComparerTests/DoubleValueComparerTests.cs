﻿using FluentAssertions;
using NUnit.Framework;
using TechTalk.SpecFlow.Assist.ValueComparers;

namespace TechTalk.SpecFlow.RuntimeTests.AssistTests.ValueComparerTests
{
    [TestFixture, SetCulture("en-US")]
    public class DoubleValueComparerTests
    {
        [Test]
        public void Can_compare_if_the_value_is_a_double()
        {
            var valueComparer = new DoubleValueComparer();
            valueComparer.CanCompare(1.0).Should().BeTrue();
            valueComparer.CanCompare(3.34).Should().BeTrue();
            valueComparer.CanCompare(-1.24).Should().BeTrue();
        }

        [Test]
        public void Cannot_compare_if_the_value_is_null()
        {
            new DoubleValueComparer()
                .CanCompare(null)
                .Should().BeFalse();
        }

        [Test]
        public void Cannot_compare_if_the_value_is_not_a_double()
        {
            var valueComparer = new DoubleValueComparer();
            valueComparer.CanCompare("x").Should().BeFalse();
            valueComparer.CanCompare(1).Should().BeFalse();
            valueComparer.CanCompare(3.14M).Should().BeFalse();
        }

        [Test]
        public void Returns_true_when_the_double_values_match()
        {
            var valueComparer = new DoubleValueComparer();
            valueComparer.TheseValuesAreTheSame("3.14", 3.14).Should().BeTrue();
            valueComparer.TheseValuesAreTheSame("0", 0.0).Should().BeTrue();
            valueComparer.TheseValuesAreTheSame("-1", -1.0).Should().BeTrue();
        }

        [Test]
        public void Returns_false_when_the_double_values_do_not_match()
        {
            var valueComparer = new DoubleValueComparer();
            valueComparer.TheseValuesAreTheSame("-1", 1.0).Should().BeFalse();
            valueComparer.TheseValuesAreTheSame("0", 1.0).Should().BeFalse();
            valueComparer.TheseValuesAreTheSame("100.2874", 100.2873).Should().BeFalse();
        }

        [Test]
        public void Returns_false_when_the_expected_value_is_not_a_double()
        {
            var valueComparer = new DoubleValueComparer();
            valueComparer.TheseValuesAreTheSame("x", 0.0).Should().BeFalse();
            valueComparer.TheseValuesAreTheSame("", 0.0).Should().BeFalse();
            valueComparer.TheseValuesAreTheSame("-----3", 0).Should().BeFalse();
        }
    }
}