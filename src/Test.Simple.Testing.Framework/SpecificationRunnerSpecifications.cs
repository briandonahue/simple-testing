﻿using System;
using Simple.Testing.Framework;

namespace Test.Simple.Testing.Framework
{
    public class SpecificationRunnerSpecifications
    {
        public Specification when_running_specification_with_exception_in_before = new QuerySpecification<SpecificationRunner, RunResult>()
        {
            On = () => new SpecificationRunner(),
            When = runner => runner.RunSpecification(TestSpecs.SpecWithExceptionInBefore.AsRunnable()),
            Expect =
                {
                    result => result.Passed == false,
                    result => result.Thrown is ArgumentException,
                    result => result.Thrown.Message == "test",
                    result => result.Message == "Before Failed",
                    result => result.Expectations.Count == 0
                }
        };

        public Specification when_running_specification_with_exception_in_on = new QuerySpecification<SpecificationRunner, RunResult>()
        {
            On = () => new SpecificationRunner(),
            When = runner => runner.RunSpecification(TestSpecs.SpecWithExceptionInOn.AsRunnable()),
            Expect =
                {
                    result => result.Passed == false,
                    result => result.Thrown is ArgumentException,
                    result => result.Thrown.Message == "test2",
                    result => result.Message == "On Failed",
                    result => result.Expectations.Count == 0
                }
        };

        public Specification when_running_specification_with_no_when = new QuerySpecification<SpecificationRunner, RunResult>()
        {
            On = () => new SpecificationRunner(),
            When = runner => runner.RunSpecification(TestSpecs.SpecWithNoWhen.AsRunnable()),
            Expect =
                {
                    result => result.Passed == false,
                    result => result.Thrown == null,
                    result => result.Message == "No when on specification",
                    result => result.Expectations.Count == 0
                }
        };

        public Specification when_running_specification_with_exception_in_when = new QuerySpecification<SpecificationRunner, RunResult>()
        {
            On = () => new SpecificationRunner(),
            When = runner => runner.RunSpecification(TestSpecs.SpecWithExceptionInWhen.AsRunnable()),
            Expect =
                {
                    result => result.Passed == false,
                    result => result.Thrown is ArgumentException,
                    result => result.Message == "When Failed",
                    result => result.Expectations.Count == 0
                }
        };

        public Specification when_running_specification_with_exception_in_finally = new QuerySpecification<SpecificationRunner, RunResult>()
        {
            On = () => new SpecificationRunner(),
            When = runner => runner.RunSpecification(TestSpecs.SpecWithExceptionInFinally.AsRunnable()),
            Expect =
                {
                    result => result.Passed == false,
                    result => result.Thrown is ArgumentException,
                    result => result.Message == "Finally failed",
                    result => result.Expectations.Count == 1
                }
        };


        public Specification when_running_specification_with_exception_in_expectation = new QuerySpecification<SpecificationRunner, RunResult>()
        {
            On = () => new SpecificationRunner(),
            When = runner => runner.RunSpecification(TestSpecs.SpecWithExceptionInExpectation.AsRunnable()),
            Expect =
                {
                    result => !result.Passed,
                    result => result.Thrown == null,
                    result => result.Message == null,
                    result => result.Expectations.Count == 1,
                    result => result.Expectations[0].Passed == false,
                    result => result.Expectations[0].Exception is ArgumentException,
                    result => result.Expectations[0].Exception.Message == "methodthatthrows"
                }
        };

        public Specification when_running_passing_specification_with_single_expectation = new QuerySpecification<SpecificationRunner, RunResult>()
        {
            On = () => new SpecificationRunner(),
            When = runner => runner.RunSpecification(TestSpecs.SpecWithSinglePassingExpectation.AsRunnable()),
            Expect =
                {
                    result => result.Passed == true,
                    result => result.Thrown == null,
                    result => result.Message == null,
                    result => result.Expectations.Count == 1,
                    result => result.Expectations[0].Passed,
                    result => result.Expectations[0].Exception == null,
                }
        };
    }
}
