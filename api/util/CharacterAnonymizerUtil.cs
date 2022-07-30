using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalyst;
using Catalyst.Models;
using Version = Mosaik.Core.Version;
using Mosaik.Core;
using P = Catalyst.PatternUnitPrototype;
using System.Globalization;
using System.Text.RegularExpressions;

namespace StoryGhost.Util
{
    public class CharacterAnonymizer
    {

        public string ToTitleCase(string text)
        {
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
            return myTI.ToTitleCase(text.ToLower());
        }

        public string AllCapsToTitleCase(string text)
        {
            string pattern = @"\b[A-Z]{2,}\b";

            var res = Regex.Replace(text, pattern, match => ToTitleCase(match.Value));

            return res;
        }

        // public static async Task<List<string>> GetCharacterNames(string text, List<string> knownCharacterNames)
        // {
        //     text = AllCapsToTitleCase(text);
        //     var nlp = await Pipeline.ForAsync(Language.English);
        //     //nlp.RemoveAllNeuralizers();
        //     nlp.RemoveAll(p => true); // remove previously added entities
        //     nlp = await Pipeline.ForAsync(Language.English);

        //     nlp.Add(await AveragePerceptronEntityRecognizer.FromStoreAsync(language: Language.English, version: Version.Latest, tag: "WikiNER"));

        //     //var neuralizer = new Neuralyzer(Language.English, 0, "WikiNER-sample-fixes");

        //     var spotter = new Spotter(Language.Any, 0, "character name", "Person");

        //     foreach (var knownCharacter in knownCharacterNames)
        //     {
        //         //Teach the Neuralyzer class to add the entity type Person for a match for the single token "knownCharacter"
        //         //neuralizer.TeachAddPattern("Person", knownCharacter, mp => mp.Add(new PatternUnit(P.Single().WithToken(knownCharacter))));
        //         //neuralizer.TeachAddPattern("Person", knownCharacter.ToUpper(), mp => mp.Add(new PatternUnit(P.Single().WithToken(knownCharacter.ToUpper()))));
        //         spotter.AddEntry(knownCharacter);
        //         spotter.AddEntry(knownCharacter.ToUpper());
        //     }

        //     //nlp.UseNeuralyzer(neuralizer);

        //     nlp.Add(spotter);

        //     var doc = new Document(text, Language.English);

        //     nlp.ProcessSingle(doc);

        //     var results = doc.SelectMany(span => span.GetEntities()).Where(e => e.EntityType.Type == "Person").Select(e => $"{e.Value}").Distinct().ToList();

        //     return results;
        // }

        public async Task<(string, string, Dictionary<string, int>)> AnonymizeCharacters(string originalFull, string originalSummary, List<string> knownCharacterNames)
        {
            var detectedNames = knownCharacterNames;//await GetCharacterNames(originalFull + "\n\n" + originalSummary, knownCharacterNames);
            var detectedNamesLower = detectedNames.Select(n => n.ToLower()).ToList();
            //Console.WriteLine("DETECTED: " + string.Join(", ", detectedNames));

            var namesToIndex = new Dictionary<string, int>();

            // build a list of all possible ways the same character might be referenced, and assign a character index to keep track. For example:
            // Tony = 0
            // Stark = 0
            // Tony Stark = 0
            // Obadiah = 1
            // Stane = 1
            // Obadiah Stane = 1

            var curNameNum = 0;

            foreach (var name in knownCharacterNames)
            {
                namesToIndex.Add(name, curNameNum);

                var nameParts = name.Split(' ').ToList();

                foreach (var part in nameParts)
                {
                    if (namesToIndex.ContainsKey(ToTitleCase(part)) == false)
                    {
                        namesToIndex.Add(ToTitleCase(part), curNameNum);
                    }

                    if (namesToIndex.ContainsKey(part.ToUpper()) == false)
                    {
                        namesToIndex.Add(part.ToUpper(), curNameNum);
                    }

                    if (detectedNamesLower.Contains(part.ToLower()))
                    {
                        var detectedName = detectedNamesLower.Where(n => n == part.ToLower()).First();

                        if (namesToIndex.ContainsKey(ToTitleCase(detectedName)) == false)
                        {
                            namesToIndex.Add(ToTitleCase(detectedName), curNameNum);
                        }

                        if (namesToIndex.ContainsKey(detectedName.ToUpper()) == false)
                        {
                            namesToIndex.Add(detectedName.ToUpper(), curNameNum);
                        }
                    }
                }

                curNameNum += 1;
            }

            foreach (var name in detectedNames)
            {
                if (namesToIndex.ContainsKey(name) == false)
                {
                    namesToIndex.Add(name, curNameNum);

                    if (namesToIndex.ContainsKey(ToTitleCase(name)) == false)
                    {
                        namesToIndex.Add(ToTitleCase(name), curNameNum);
                    }

                    if (namesToIndex.ContainsKey(name.ToUpper()) == false)
                    {
                        namesToIndex.Add(name.ToUpper(), curNameNum);
                    }

                    curNameNum += 1;
                }
            }

            // print final lookup dictionary
            //namesToIndex.Select(i => $"{i.Key}: {i.Value}").ToList().ForEach(Console.WriteLine);

            var separator = " ===SG=== ";

            var result = originalFull + separator + originalSummary;

            foreach (var name in namesToIndex.Keys.OrderByDescending(x => x.Length))
            {
                //Console.WriteLine($"replacing: {name}");
                result = result.Replace(name, $"CHARACTER{namesToIndex[name]}");
                result = result.Replace(name.ToUpper(), $"CHARACTER{namesToIndex[name]}");
            }

            var resultParts = result.Split(separator);

            return (resultParts[0], resultParts[1], namesToIndex);
        }

        public string DeAnonymize(string text, Dictionary<string, int> namesToIndex, bool useShortestName)
        {
            // given a string like "CHARACTER0 talks with CHARACTER1" we use namesToIndex to replace them with the shortest real names found

            for (var i = 0; i < 10; i++)
            { // assume max of 10 possible characters
                var possibleNames = namesToIndex.Where(kvp => kvp.Value == i).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                //possibleNames.Select(i => $"{i.Key}: {i.Value}").ToList().ForEach(Console.WriteLine);

                var possibleNamesList = possibleNames.Select(kvp => kvp.Key);

                if (useShortestName)
                {
                    possibleNamesList = possibleNamesList.OrderBy(x => x.Length);
                }
                else
                {
                    possibleNamesList = possibleNamesList.OrderByDescending(x => x.Length);
                }

                var shortestName = possibleNamesList.ToList().FirstOrDefault();

                if (shortestName != null)
                {
                    text = text.Replace($"CHARACTER{i}", shortestName);
                }
            }

            return text;
        }

    }
}