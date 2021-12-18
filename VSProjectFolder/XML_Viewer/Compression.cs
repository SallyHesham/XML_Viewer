﻿public class Compression
{
    public static void Main(string[] args)
    {
        string compressedString = Compress(@"C:\Users\lenovo\Downloads\sample.xml");
        Console.WriteLine(string.Join(", ", compressedString));
        string decompressed = Decompress(compressedString);
        Console.WriteLine(decompressed);

        // to Display it on the console
        XmlDocument doc = new XmlDocument();
        XmlTextReader reader = new XmlTextReader(decompressed);
        reader.Read();
        // load reader   
        doc.Load(reader);
        // Display contents on the console  
        doc.Save(Console.Out);

    }

    public static string Compress(string uncompressed)
    {
        // build the dictionary
        Dictionary<string, int> dictionary = new Dictionary<string, int>();
        for (int i = 0; i < 256; i++)
            dictionary.Add(((char)i).ToString(), i);

        string w = string.Empty;
        List<int> compressed = new List<int>();

        foreach (char c in uncompressed)
        {
            string wc = w + c;
            if (dictionary.ContainsKey(wc))
            {
                w = wc;
            }
            else
            {
                // write w to output
                compressed.Add(dictionary[w]);
                // wc is a new sequence; add it to the dictionary
                dictionary.Add(wc, dictionary.Count);
                w = c.ToString();
            }
        }

        // write remaining output if necessary
        if (!string.IsNullOrEmpty(w))
            compressed.Add(dictionary[w]);
        // convert list<int> to string
        string compressedString = string.Join(" ", compressed.ToArray());

        return compressedString;
    }

    public static string Decompress(string compressedString)
    {
        // build the dictionary
        Dictionary<int, string> dictionary = new Dictionary<int, string>();
        for (int i = 0; i < 256; i++)
            dictionary.Add(i, ((char)i).ToString());
        //convert string to list<int> 
        List<int> compressed = new List<int>(Array.ConvertAll(compressedString.Split(" "), int.Parse));

        string w = dictionary[compressed[0]];
        compressed.RemoveAt(0);
        StringBuilder decompressed = new StringBuilder(w);

        foreach (int k in compressed)
        {
            string entry = null;
            if (dictionary.ContainsKey(k))
                entry = dictionary[k];
            else if (k == dictionary.Count)
                entry = w + w[0];

            decompressed.Append(entry);

            // new sequence; add it to the dictionary
            dictionary.Add(dictionary.Count, w + entry[0]);

            w = entry;
        }


        return decompressed.ToString();
    }
}
