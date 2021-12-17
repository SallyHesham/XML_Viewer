using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace XML_Viewer
{
    
    class compression
    {
        //add key in dictionary or updat it and increase its value by 1 
        public static void AddOrUpdate<TKey, TValue>(this Dictionary<TKey, List<TValue>> dictionary, TKey key, TValue value)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key].Add(value++);
            }
            else
            {
                dictionary.Add(key, new List<TValue> { value });
            }
        }

        //calculate the word frequency in the text.
        public Dictionary getWord(string file)
        {
            Dictionary<string, List<string>> dct = new Dictionary<string, List<string>>();
            StreamReader reader = new StreamReader(file);
            string line;
            string words[];
            int value = 0;

            while (reader.Peek() != -1)
            {
                line = line.Trim();
                words = line.Split(" ");

                foreach (string i in words)
                {
                    //Add an identifier(</w>) at the end of each word to identify the end of a word
                    StringBuilder s = new StringBuilder(i);
                    s.Append("</W>");
                    dct.AddOrUpdate(i, ++value);

                }
            }
            return dct;
        }

        //Split the word into characters and then calculate the character frequency
        public Dictionary getToken(Dictionary dct)
        {
            Dictionary<string, List<string>> dct_token = new Dictionary<string, List<string>>();

            char chars[];
            int value = 0;
            string s;

            foreach (KeyValuePair<int, string> kvp in dct)
            {
                chars = (kvp.Key).ToCharArray();
                foreach (char c in chars)
                    dct_token.AddOrUpdate(c, value);
            }
            return dct_token;
        }

        //calculate the Pair frequency
        public Dictionary getPair(Dictionary dct)
        {
            Dictionary<string, List<string>> dct_char = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> dct_pair = new Dictionary<string, List<string>>();

            char chars[];
            int value = 0;
            string s;

            foreach (KeyValuePair<string, int> kvp in dct)
            {
                chars = (kvp.Key).ToCharArray();
                for (int j = 0; j < len(char) j++)
                    s = chars[j] "," chars[j + 1];
                    dct_pair.AddOrUpdate(s, value);
            }
            return dct_pair;
        }

        // merge the most frequently occurring byte pairing.
        public Dictionary mergeWords(Dictionary dct_pair, Dictionary vIN)
        {
            vOUT[];
            joined_pair = Regex.Escape(" " .join(dct_pair))
            p = Regex.Compile(r'(?<!\S)' + joined_pair + r'(?!\S)')
            for word in vIN:
            wOUT = p.sub(''.join(dct_pair), word)
            vOUT[wOUT] = vIN[word]
            return vOUT;
        }

        public compress(string file)
        {
            Dictionary<string, List<string>> pairs1 = new Dictionary<string, List<string>>();
            var vocab = getWord(string file);
            var best;
            var tokens;
            int num_merges = 1000;
            for (int i = 0; i < num_merges; i++)
            {
                pairs1 = getPair(vocab);
                // most frequent pair
                foreach (KeyValuePair<string, int> kvp in pairs1)
                {
                    if (kvp.Value > (kvp + 1).Value)
                        best = kvp.Key;
                }

                vocab = mergeWords(best, vocab);
                tokens = getToken(vocab);
            }
            return tokens;
        }    
    }
}