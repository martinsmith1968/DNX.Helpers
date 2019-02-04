using DNX.Helpers.Strings;
using NUnit.Framework;
using Shouldly;

namespace Test.DNX.Helpers.Strings
{
    [TestFixture]
    public class ArgumentParserTests
    {
        [TestCase("command value1 value2 --option optionValue", 5, "command|value1|value2|--option|optionValue")]
        [TestCase("command value1 \"value2\" --option 'optionValue'", 5, "command|value1|value2|--option|'optionValue'")]
        [TestCase("command \" value1 has multiple  spaces \" \"value2 contains spaces\" --option 'optionValue'", 5, "command| value1 has multiple  spaces |value2 contains spaces|--option|'optionValue'")]
        public void When_called_with_a_valid_simple_string_of_values(string text, int parameterCount, string resultsByPipe)
        {
            var result = ArgumentParser.ParseArguments(text);

            result.ShouldNotBeNull();
            result.Count.ShouldBe(parameterCount);

            var parameters = resultsByPipe.Split("|".ToCharArray());
            parameters.Length.ShouldBe(parameterCount);

            var parameterPosition = 0;
            foreach (var parameter in parameters)
            {
                parameter.ShouldBe(result[parameterPosition]);

                ++parameterPosition;
            }
        }
    }
}
