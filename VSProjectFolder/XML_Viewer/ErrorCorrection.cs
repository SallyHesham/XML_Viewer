using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace XML_Viewer
{
    class ErrorCorrection
    {
        public static void check()
        {
            StreamReader reader = new StreamReader(xml_ref.file_path);
            StreamWriter writer = new StreamWriter("corrected.xml");
            string originalLine;
            string line;
            string tag;
            Stack<string> tagsStack = new Stack<string>();

            while(reader.Peek() != -1)
            {
                originalLine = reader.ReadLine();
                line = originalLine.Trim();
                // to make sure it is not a data line
                if (line[0] != '<')
                {
                    writer.WriteLine(originalLine);
                    continue;
                }

                string[] arr = line.Split('<', '>');
                if (arr.Length <= 3)
                {
                    tag = arr[1];
                    // if closing tag
                    if (tag[0] == '/')
                    {
                        // discard extra closing tag when stack is empty
                        if (tagsStack.Count == 0) continue;

                        tag = tag.Substring(1, tag.Length - 1);
                        // if no error
                        if (tagsStack.Peek() == tag)
                        {
                            tagsStack.Pop();
                            writer.WriteLine(originalLine);
                        }
                        // if error
                        else
                        {
                            string lineCorrection;
                            lineCorrection = originalLine.Split('/')[0];
                            lineCorrection += ('/' + tagsStack.Pop() + '>');
                            writer.WriteLine(lineCorrection);

                            // if original closing tag is still needed

                            if (tagsStack.Peek() == tag)
                            {
                                tagsStack.Pop();
                                writer.WriteLine(originalLine);
                            }
                        }
                    }
                    // if opening tag
                    else
                    {
                        tagsStack.Push(tag);
                        writer.WriteLine(originalLine);
                    }
                }
                else
                {
                    // if opening and closing tag exist
                    if (arr.Length == 5)
                    {
                        tagsStack.Push(arr[1]);
                        tag = arr[3].Substring(1, arr[3].Length - 1);
                        // if no errors (tags match)
                        if (tagsStack.Peek() == tag)
                        {
                            tagsStack.Pop();
                            writer.WriteLine(originalLine);
                        }
                        // if error (mismatched tags)
                        else
                        {
                            string lineCorrection;
                            lineCorrection = originalLine.Split('/')[0];
                            lineCorrection += ('/' + tagsStack.Pop() + '>');
                            writer.WriteLine(lineCorrection);
                        }
                    }
                    // if only one tag exists
                    else
                    {
                        tagsStack.Push(arr[1]);
                        string lineCorrection;
                        lineCorrection = originalLine;
                        lineCorrection += ("</" + tagsStack.Pop() + '>');
                        writer.WriteLine(lineCorrection);
                    }
                }
            }

            reader.Close();
            writer.Close();
            xml_ref.file_path = Path.GetFullPath("corrected.xml");
            return;
        }
    }
}
