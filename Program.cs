using System;

// This will be needed in order to use RegEx and remove punctation in the string
using System.Text.RegularExpressions;

// We need the dictionary to return the string and the integer. List cannot acheive this
using System.Collections.Generic;

namespace WordFrequency
{
    class Program
    {
        static void Main(string[] args)
        {
            string GetText()
            {
                return @"
                    Look again at that dot. That's here. That's home. That's us. On it everyone you love, everyone you know, everyone you ever heard of, every human being who ever was, lived out their lives. The aggregate of our joy and suffering, thousands of confident religions, ideologies, and economic doctrines, every hunter and forager, every hero and coward, every creator and destroyer of civilization, every king and peasant, every young couple in love, every mother and father, hopeful child, inventor and explorer, every teacher of morals, every corrupt politician, every 'superstar,' every 'supreme leader,' every saint and sinner in the history of our species lived there--on a mote of dust suspended in a sunbeam.
                    The Earth is a very small stage in a vast cosmic arena. Think of the rivers of blood spilled by all those generals and emperors so that, in glory and triumph, they could become the momentary masters of a fraction of a dot. Think of the endless cruelties visited by the inhabitants of one corner of this pixel on the scarcely distinguishable inhabitants of some other corner, how frequent their misunderstandings, how eager they are to kill one another, how fervent their hatreds.
                    Our posturings, our imagined self-importance, the delusion that we have some privileged position in the Universe, are challenged by this point of pale light. Our planet is a lonely speck in the great enveloping cosmic dark. In our obscurity, in all this vastness, there is no hint that help will come from elsewhere to save us from ourselves.
                    The Earth is the only world known so far to harbor life. There is nowhere else, at least in the near future, to which our species could migrate. Visit, yes. Settle, not yet. Like it or not, for the moment the Earth is where we make our stand.
                    It has been said that astronomy is a humbling and character-building experience. There is perhaps no better demonstration of the folly of human conceits than this distant image of our tiny world. To me, it underscores our responsibility to deal more kindly with one another, and to preserve and cherish the pale blue dot, the only home we've ever known.
                    - Carl Sagan
                    ";
            }

            // In order to get the word frequency we need to use Regular Expression in order to replace the punctation with just strings of words. 
            // We need the parameters to be what we are looking for. what we just want and an empty string
            // Remove substrings from any place in your string
            string regex = Regex.Replace(GetText(), "[^A-Za-z ]", String.Empty);

            // Because we need to store key/value pairs we need
            // Dictionary are better than list in this instance since we need to create a collection of keys and values 
            // Initailized as empty so we can add to it
            Dictionary<string, int> BlueDot = new Dictionary<string, int>();

            // The Sagan quote needs to be split up so we can collect the data. Since we removed the puncation above
            // Iterate through the "array". Remove the excess, then increase to the next word as we tally them individually.
            // Then add to the Dictionary with the string and the total. Start at one and count up 
            foreach (string word in regex.Split(' '))
            {
                // Remove all the leading and trailing whitespace from the current string. 
                // eliminates it at the start or end 
                if (word.Trim() == "")
                {
                    continue;
                }
                // Since we are wanting the frequency of words  we use the .ContainsKey to get the specified key
                // The Dictionary<> has a specified Key of string
                // Earlier we told the program that string and word are together since we are iterating over the excerpt
                else if (BlueDot.ContainsKey(word))
                {
                    BlueDot[word] += 1;
                }
                else
                {
                    BlueDot.Add(word, 1);
                }
            }

            Console.WriteLine("--- Carl Sagan's 'Pale Blue Dot' Word Frequency ---");

            // Now iterate through the Dictionary and push to the terminal line the words and their frequency
            foreach (KeyValuePair<string, int> word in BlueDot)
            {
                Console.WriteLine($"{word.Key} -- {word.Value}");
            }
        }
    }
}
