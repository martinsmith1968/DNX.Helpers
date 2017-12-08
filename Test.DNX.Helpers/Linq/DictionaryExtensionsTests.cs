using System;
using System.Collections.Generic;
using System.Linq;
using DNX.Helpers.Exceptions;
using DNX.Helpers.Linq;
using DNX.Helpers.Strings;
using NUnit.Framework;
using Shouldly;

namespace Test.DNX.Helpers.Linq
{
    [TestFixture]
    public class DictionaryExtensionsTests
    {
        [TestCase("a=1;b=2;c=3", "b", ExpectedResult = "2")]
        [TestCase("a=1;b=2;c=3", "a", ExpectedResult = "1")]
        [TestCase("a=1;b=2;c=3", "c", ExpectedResult = "3")]
        [TestCase("a=1;b=2;c=3", "z", ExpectedResult = null)]
        [TestCase("a=1;b=2;c=3", "", ExpectedResult = null)]
        public string Test_GetValue(string dictionaryText, string key)
        {
            var dictionary = dictionaryText.Split(";")
                .Select(x => x.ParseFirstMatchToDictionary(@"([^=]+)=(.*)"))
                .ToDictionary(
                    a => a["1"],
                    a => a["2"]
                );

            var result = dictionary.GetValue(key);

            return result;
        }

        [TestCase("blah")]
        public void Test_GetValue_doesnt_allow_null_dictionary(string key)
        {
            Dictionary<string, string> dictionary = null;

            var ex = Assert.Throws<ArgumentNullException>(
                () => dictionary.GetValue(key)
                );

            ex.ShouldNotBeNull();
            ex.ParamName.ShouldBe("dictionary");
        }

        [TestCase("a=1;b=2;c=3", null, ExpectedResult = false)]
        public bool Test_GetValue_doesnt_allow_null_keyname(string dictionaryText, string key)
        {
            try
            {
                Test_GetValue(dictionaryText, key);

                return true;
            }
            catch (ArgumentNullException ex)
            {
                ex.ParamName.ShouldBe("keyName");

                return false;
            }
        }

        [TestCase("a=1;b=2;c=3", "b", "4", ExpectedResult = "a=1;b=4;c=3")]
        [TestCase("a=1;b=2;c=3", "a", "4", ExpectedResult = "a=4;b=2;c=3")]
        [TestCase("a=1;b=2;c=3", "c", "4", ExpectedResult = "a=1;b=2;c=4")]

        [TestCase("a=1;b=2;c=3", "z", "4", ExpectedResult = "a=1;b=2;c=3;z=4")]
        [TestCase("a=1;b=2;c=3", "", "4", ExpectedResult = "a=1;b=2;c=3;=4")]
        public string Test_SetValue(string dictionaryText, string key, string newValue)
        {
            var dictionary = dictionaryText.Split(";")
                .Select(x => x.ParseFirstMatchToDictionary(@"([^=]+)=(.*)"))
                .ToDictionary(
                    a => a["1"],
                    a => a["2"]
                );

            dictionary.SetValue(key, newValue);

            var result = string.Join(";", dictionary
                .Select(x => string.Format("{0}={1}", x.Key, x.Value))
                );

            return result;
        }
        [TestCase("blah", "blah")]
        public void Test_SetValue_doesnt_allow_null_dictionary(string key, string value)
        {
            Dictionary<string, string> dictionary = null;

            var ex = Assert.Throws<ArgumentNullException>(
                () => dictionary.SetValue(key, value)
                );

            ex.ShouldNotBeNull();
            ex.ParamName.ShouldBe("dictionary");
        }

        [TestCase("a=1;b=2;c=3", null, "4", ExpectedResult = false)]
        public bool Test_SetValue_doesnt_allow_null_keyname(string dictionaryText, string key, string newValue)
        {
            try
            {
                Test_SetValue(dictionaryText, key, newValue);

                return true;
            }
            catch (ArgumentNullException ex)
            {
                ex.ParamName.ShouldBe("keyName");

                return false;
            }
        }

        [TestCase("a=1;b=2;c=3", "b", "q", ExpectedResult = "a=1;c=3;q=2")]
        [TestCase("a=1;b=2;c=3", "a", "q", ExpectedResult = "b=2;c=3;q=1")]
        [TestCase("a=1;b=2;c=3", "c", "q", ExpectedResult = "a=1;b=2;q=3")]
        [TestCase("a=1;b=2;c=3", "z", "q", ExpectedResult = "a=1;b=2;c=3")]
        [TestCase("a=1;b=2;c=3", "", "q", ExpectedResult = "a=1;b=2;c=3")]
        public string Test_RenameKey(string dictionaryText, string keyName, string newKeyName)
        {
            var dictionary = dictionaryText.Split(";")
                .Select(x => x.ParseFirstMatchToDictionary(@"([^=]+)=(.*)"))
                .ToDictionary(
                    a => a["1"],
                    a => a["2"]
                );

            dictionary.RenameKey(keyName, newKeyName);

            var result = string.Join(";", dictionary
                .OrderBy(d => d.Key)
                .Select(x => string.Format("{0}={1}", x.Key, x.Value))
                );

            return result;
        }

        [TestCase("a=1;b=2;c=3", "a", null, ExpectedResult = false)]
        [TestCase("a=1;b=2;c=3", null, "a", ExpectedResult = false)]
        public bool Test_RenameKey_doesnt_allow_null_keyname(string dictionaryText, string key, string newKeyName)
        {
            try
            {
                Test_RenameKey(dictionaryText, key, newKeyName);

                return true;
            }
            catch (ArgumentNullException ex)
            {
                ex.ParamName.EndsWith("KeyName").ShouldBeTrue();    // fromKeyName, toKeyName

                return false;
            }
        }

        [Test]
        public void MergeUnique_can_combine_dictionaries_successfully()
        {
            // Arrange
            var dict1 = new Dictionary<string, int>()
            {
                { "A1", 1 },
                { "A2", 2 },
                { "A3", 3 },
                { "A4", 4 },
                { "A5", 5 },
            };

            var dict2 = new Dictionary<string, int>()
            {
                { "B1", 1 },
                { "B2", 2 },
                { "B3", 3 },
            };

            var dict3 = new Dictionary<string, int>()
            {
                { "C1", 1 },
                { "C2", 2 },
                { "C3", 3 },
            };

            // Act
            var result1 = DictionaryExtensions.MergeUnique(dict1, dict2, dict3);
            var result2 = DictionaryExtensions.Merge(MergeTechnique.Unique, dict1, dict2, dict3);

            // Assert
            result1.ShouldNotBeNull();
            result1.Count.ShouldBe(dict1.Count + dict2.Count + dict3.Count);
            foreach (var kvp1 in dict1)
            {
                result1.ContainsKey(kvp1.Key).ShouldBeTrue();
                result1[kvp1.Key].ShouldBe(kvp1.Value);
            }
            foreach (var kvp2 in dict2)
            {
                result1.ContainsKey(kvp2.Key).ShouldBeTrue();
                result1[kvp2.Key].ShouldBe(kvp2.Value);
            }
            foreach (var kvp3 in dict3)
            {
                result1.ContainsKey(kvp3.Key).ShouldBeTrue();
                result1[kvp3.Key].ShouldBe(kvp3.Value);
            }

            CollectionAssert.AreEqual(result1, result2);
        }

        [Test]
        public void MergeUnique_with_dictionaries_with_key_clashes_fails()
        {
            // Arrange
            var dict1 = new Dictionary<string, int>()
            {
                { "A1", 1 },
                { "A2", 2 },
                { "A3", 3 },
                { "A4", 4 },
                { "A5", 5 },
            };

            var dict2 = new Dictionary<string, int>()
            {
                { "B1", 1 },
                { "A2", 2 },
                { "B3", 3 },
            };

            // Act
            try
            {
                var result = DictionaryExtensions.MergeUnique(dict1, dict2);

                Assert.Fail("Expected exception not thrown");
            }
            catch (ArgumentException e)
            {
                e.Message.ShouldNotBeNull();
            }

            try
            {
                var result = DictionaryExtensions.Merge(MergeTechnique.Unique, dict1, dict2);

                Assert.Fail("Expected exception not thrown");
            }
            catch (ArgumentException e)
            {
                e.Message.ShouldNotBeNull();
            }
        }

        [Test]
        public void MergeFirst_can_combine_unique_dictionaries_successfully()
        {
            // Arrange
            var dict1 = new Dictionary<string, int>()
            {
                { "A1", 1 },
                { "A2", 2 },
                { "A3", 3 },
                { "A4", 4 },
                { "A5", 5 },
            };

            var dict2 = new Dictionary<string, int>()
            {
                { "B1", 1 },
                { "B2", 2 },
                { "B3", 3 },
            };

            var dict3 = new Dictionary<string, int>()
            {
                { "C1", 1 },
                { "C2", 2 },
                { "C3", 3 },
            };

            // Act
            var result1 = DictionaryExtensions.MergeFirst(dict1, dict2, dict3);
            var result2 = DictionaryExtensions.Merge(MergeTechnique.TakeFirst, dict1, dict2, dict3);

            // Assert
            result1.ShouldNotBeNull();
            result1.Count.ShouldBe(dict1.Count + dict2.Count + dict2.Count);
            foreach (var kvp1 in dict1)
            {
                result1.ContainsKey(kvp1.Key).ShouldBeTrue();
                result1[kvp1.Key].ShouldBe(kvp1.Value);
            }
            foreach (var kvp2 in dict2)
            {
                result1.ContainsKey(kvp2.Key).ShouldBeTrue();
                result1[kvp2.Key].ShouldBe(kvp2.Value);
            }
            foreach (var kvp3 in dict3)
            {
                result1.ContainsKey(kvp3.Key).ShouldBeTrue();
                result1[kvp3.Key].ShouldBe(kvp3.Value);
            }

            CollectionAssert.AreEqual(result1, result2);
        }

        [Test]
        public void MergeFirst_with_dictionaries_with_key_clashes_uses_first_found_values_successfully()
        {
            // Arrange
            var dict1 = new Dictionary<string, int>()
            {
                { "A1", 1 },
                { "A2", 2 },
                { "A3", 3 },
                { "A4", 4 },
                { "A5", 5 },
            };

            var dict2 = new Dictionary<string, int>()
            {
                { "A2", 12 },
                { "A4", 14 },
                { "A6", 16 },
            };

            var dict3 = new Dictionary<string, int>()
            {
                { "A1", 21 },
                { "A3", 23 },
                { "A5", 25 },
            };

            // Act
            var result1 = DictionaryExtensions.MergeFirst(dict1, dict2, dict3);
            var result2 = DictionaryExtensions.Merge(MergeTechnique.TakeFirst, dict1, dict2, dict3);

            // Assert
            result1.ShouldNotBeNull();
            result1.Count.ShouldBe(dict1.Select(d => d.Key).Union(dict2.Select(d => d.Key)).Union(dict3.Select(d => d.Key)).Distinct().Count());
            foreach (var kvp1 in dict1)
            {
                result1.ContainsKey(kvp1.Key).ShouldBeTrue();
            }
            foreach (var kvp2 in dict2)
            {
                result1.ContainsKey(kvp2.Key).ShouldBeTrue();
            }
            foreach (var kvp3 in dict3)
            {
                result1.ContainsKey(kvp3.Key).ShouldBeTrue();
            }
            result1["A1"].ShouldBe(1);
            result1["A2"].ShouldBe(2);
            result1["A3"].ShouldBe(3);
            result1["A4"].ShouldBe(4);
            result1["A5"].ShouldBe(5);
            result1["A6"].ShouldBe(16);

            CollectionAssert.AreEqual(result1, result2);
        }

        [Test]
        public void MergeLast_can_combine_dictionaries_successfully()
        {
            // Arrange
            var dict1 = new Dictionary<string, int>()
            {
                { "A1", 1 },
                { "A2", 2 },
                { "A3", 3 },
                { "A4", 4 },
                { "A5", 5 },
            };

            var dict2 = new Dictionary<string, int>()
            {
                { "B1", 1 },
                { "B2", 2 },
                { "B3", 3 },
            };

            var dict3 = new Dictionary<string, int>()
            {
                { "C1", 1 },
                { "C2", 2 },
                { "C3", 3 },
            };

            // Act
            var result1 = DictionaryExtensions.MergeLast(dict1, dict2, dict3);
            var result2 = DictionaryExtensions.Merge(MergeTechnique.TakeLast, dict1, dict2, dict3);

            // Assert
            result1.ShouldNotBeNull();
            result1.Count.ShouldBe(dict1.Count + dict2.Count + dict2.Count);
            foreach (var kvp1 in dict1)
            {
                result1.ContainsKey(kvp1.Key).ShouldBeTrue();
                result1[kvp1.Key].ShouldBe(kvp1.Value);
            }
            foreach (var kvp2 in dict2)
            {
                result1.ContainsKey(kvp2.Key).ShouldBeTrue();
                result1[kvp2.Key].ShouldBe(kvp2.Value);
            }
            foreach (var kvp3 in dict3)
            {
                result1.ContainsKey(kvp3.Key).ShouldBeTrue();
                result1[kvp3.Key].ShouldBe(kvp3.Value);
            }

            CollectionAssert.AreEqual(result1, result2);
        }

        [Test]
        public void MergeLast_with_dictionaries_with_key_clashes_uses_last_found_values_successfully()
        {
            // Arrange
            var dict1 = new Dictionary<string, int>()
            {
                { "A1", 1 },
                { "A2", 2 },
                { "A3", 3 },
                { "A4", 4 },
                { "A5", 5 },
            };

            var dict2 = new Dictionary<string, int>()
            {
                { "A2", 12 },
                { "A4", 14 },
                { "A6", 16 },
            };

            var dict3 = new Dictionary<string, int>()
            {
                { "A1", 21 },
                { "A3", 23 },
                { "A5", 25 },
            };

            // Act
            var result1 = DictionaryExtensions.MergeLast(dict1, dict2, dict3);
            var result2 = DictionaryExtensions.Merge(MergeTechnique.TakeLast, dict1, dict2, dict3);

            // Assert
            result1.ShouldNotBeNull();
            result1.Count.ShouldBe(dict1.Select(d => d.Key).Union(dict2.Select(d => d.Key)).Union(dict3.Select(d => d.Key)).Distinct().Count());
            foreach (var kvp1 in dict1)
            {
                result1.ContainsKey(kvp1.Key).ShouldBeTrue();
            }
            foreach (var kvp2 in dict2)
            {
                result1.ContainsKey(kvp2.Key).ShouldBeTrue();
            }
            foreach (var kvp3 in dict3)
            {
                result1.ContainsKey(kvp3.Key).ShouldBeTrue();
            }
            result1["A1"].ShouldBe(21);
            result1["A2"].ShouldBe(12);
            result1["A3"].ShouldBe(23);
            result1["A4"].ShouldBe(14);
            result1["A5"].ShouldBe(25);
            result1["A6"].ShouldBe(16);

            CollectionAssert.AreEqual(result1, result2);
        }

        [Test]
        public void MergeWith_can_merge_a_target_dictionary_and_leave_source_and_target_untouched_successfully()
        {
            // Arrange
            var dict1 = new Dictionary<string, int>()
            {
                { "A1", 1 },
                { "A2", 2 },
                { "A3", 3 },
                { "A4", 4 },
                { "A5", 5 },
            };

            var dict2 = new Dictionary<string, int>()
            {
                { "B1", 11 },
                { "B2", 12 },
                { "B3", 13 },
            };

            // Act
            var result = dict1.MergeWith(dict2, MergeTechnique.Unique);

            // Assert
            dict1.Count.ShouldBe(5);
            dict2.Count.ShouldBe(3);
            result.ShouldNotBeNull();
            result.Count.ShouldBe(dict1.Count + dict2.Count);
            foreach (var kvp1 in dict1)
            {
                result.ContainsKey(kvp1.Key).ShouldBeTrue();
            }
            foreach (var kvp2 in dict2)
            {
                result.ContainsKey(kvp2.Key).ShouldBeTrue();
            }
            result["A1"].ShouldBe(1);
            result["A2"].ShouldBe(2);
            result["A3"].ShouldBe(3);
            result["A4"].ShouldBe(4);
            result["A5"].ShouldBe(5);
            result["B1"].ShouldBe(11);
            result["B2"].ShouldBe(12);
            result["B3"].ShouldBe(13);
        }

        [Test]
        public void MergeWith_can_chain_merge_target_dictionaries_and_leave_sources_and_targets_untouched_successfully()
        {
            // Arrange
            var dict1 = new Dictionary<string, int>()
            {
                { "A1", 1 },
                { "A2", 2 },
                { "A3", 3 },
                { "A4", 4 },
                { "A5", 5 },
            };

            var dict2 = new Dictionary<string, int>()
            {
                { "B1", 11 },
                { "B2", 12 },
                { "B3", 13 },
            };

            var dict3 = new Dictionary<string, int>()
            {
                { "C1", 21 },
                { "C2", 22 },
            };

            // Act
            var result = dict1
                .MergeWith(dict2, MergeTechnique.Unique)
                .MergeWith(dict3, MergeTechnique.Unique)
                ;

            // Assert
            dict1.Count.ShouldBe(5);
            dict2.Count.ShouldBe(3);
            dict3.Count.ShouldBe(2);
            result.ShouldNotBeNull();
            result.Count.ShouldBe(dict1.Count + dict2.Count + dict3.Count);
            foreach (var kvp1 in dict1)
            {
                result.ContainsKey(kvp1.Key).ShouldBeTrue();
            }
            foreach (var kvp2 in dict2)
            {
                result.ContainsKey(kvp2.Key).ShouldBeTrue();
            }
            foreach (var kvp3 in dict3)
            {
                result.ContainsKey(kvp3.Key).ShouldBeTrue();
            }
            result["A1"].ShouldBe(1);
            result["A2"].ShouldBe(2);
            result["A3"].ShouldBe(3);
            result["A4"].ShouldBe(4);
            result["A5"].ShouldBe(5);
            result["B1"].ShouldBe(11);
            result["B2"].ShouldBe(12);
            result["B3"].ShouldBe(13);
            result["C1"].ShouldBe(21);
            result["C2"].ShouldBe(22);
        }

        [Test]
        public void Merge_fails_when_invalid_or_unknown_MergeTechnique_specified()
        {
            // Arrange
            var dict1 = new Dictionary<string, int>()
            {
                { "A1", 1 },
                { "A2", 2 },
                { "A3", 3 },
                { "A4", 4 },
                { "A5", 5 },
            };

            var dict2 = new Dictionary<string, int>()
            {
                { "B1", 11 },
                { "B2", 12 },
                { "B3", 13 },
            };

            var mergeTechnique = (MergeTechnique)int.MaxValue;

            // Act
            var ex = Assert.Throws<EnumValueException<MergeTechnique>>(() =>
                {
                    dict1.MergeWith(dict2, mergeTechnique);
                }
            );

            // Assert
            ex.ShouldNotBeNull();
            ex.Value.ShouldBe(mergeTechnique);
            ex.Type.ShouldBe(typeof(MergeTechnique));
        }
    }
}
