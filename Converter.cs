using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace GlitchText
{
    public class Converter
    {
        private Dictionary<byte, char> charTranslation;
        private Dictionary<char, byte> byteTranslation;

        public Converter()
        {
            charTranslation = new Dictionary<byte, char>();
            byteTranslation = new Dictionary<char, byte>();
            byte start = 0;

            for (int i = 0x21; i < 0x7E; i++, start++)
            {
                charTranslation.Add(start, (char)i);
                byteTranslation.Add((char)i, start);
            }
            for (int i = 0xA1; i < 0x144; i++, start++)
            {
                charTranslation.Add(start, (char)i);
                byteTranslation.Add((char)i, start);
            }
        }

        public string EncodeWithStringUnicode(string inputFileName)
        {
            System.IO.FileStream inFile;
            byte[] binaryData;

            try
            {
                inFile = new System.IO.FileStream(inputFileName,
                                          System.IO.FileMode.Open,
                                          System.IO.FileAccess.Read);
                binaryData = new Byte[inFile.Length];
                long bytesRead = inFile.Read(binaryData, 0,
                                     (int)inFile.Length);
                inFile.Close();
            }
            catch (System.Exception exp)
            {
                // Error creating stream or reading from it.
                System.Console.WriteLine("{0}", exp.Message);
                return null;
            }

            StringBuilder retSet = new StringBuilder();

            for (int countChar = 0; countChar < binaryData.Length; countChar++)
            {
                retSet.Append(charTranslation[binaryData[countChar]]);
            }

            return retSet.ToString();
        }

        public Image DecodeFromStringUnicode(string input)
        {
            List<byte> imageBytes = new List<byte>();

            foreach (char inputChar in input)
            {
                if (!byteTranslation.ContainsKey(inputChar)) // if there's no match, skip, it's a symbol added by the user that has no translation
                {
                    continue;
                }
                imageBytes.Add(byteTranslation[inputChar]);
            }

            MemoryStream ms = new MemoryStream(imageBytes.ToArray(), 0,
              imageBytes.Count);

            // Convert byte[] to Image
            ms.Write(imageBytes.ToArray(), 0, imageBytes.Count);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        //public string EncodeWithString(string inputFileName)
        //{
        //    System.IO.FileStream inFile;
        //    byte[] binaryData;

        //    try
        //    {
        //        inFile = new System.IO.FileStream(inputFileName,
        //                                  System.IO.FileMode.Open,
        //                                  System.IO.FileAccess.Read);
        //        binaryData = new Byte[inFile.Length];
        //        long bytesRead = inFile.Read(binaryData, 0,
        //                             (int)inFile.Length);
        //        inFile.Close();
        //    }
        //    catch (System.Exception exp)
        //    {
        //        // Error creating stream or reading from it.
        //        System.Console.WriteLine("{0}", exp.Message);
        //        return null;
        //    }

        //    // Convert the binary input into Base64 UUEncoded output.
        //    string base64String;
        //    try
        //    {
        //        base64String =
        //          System.Convert.ToBase64String(binaryData,
        //                                 0,
        //                                 binaryData.Length);
        //    }
        //    catch (System.ArgumentNullException)
        //    {
        //        System.Console.WriteLine("Binary data array is null.");
        //        return null;
        //    }

        //    return base64String;

        //}

        //public Image DecodeFromString(string base64String)
        //{
        //    if (base64String.Length % 4 != 0)
        //    {
        //        // shorten it to a multiple of 4
        //        base64String = base64String.Substring(0, base64String.Length - (base64String.Length % 4));
        //    }

        //    // Convert Base64 String to byte[]
        //    byte[] imageBytes = Convert.FromBase64String(base64String);
        //    MemoryStream ms = new MemoryStream(imageBytes, 0,
        //      imageBytes.Length);

        //    // Convert byte[] to Image
        //    ms.Write(imageBytes, 0, imageBytes.Length);
        //    Image image = Image.FromStream(ms, true);
        //    return image;
        //}

    }
}