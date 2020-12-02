using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;

namespace OCRproject
{
    class Program
    {
        static void Main(string[] args)
        {
            var testImage = @"C:\Users\marksman3\Pictures\ps5.png";
            try
            {
                using (var engine = new TesseractEngine(@"tessdata", "por", EngineMode.Default))
                {
                    using (var img = Pix.LoadFromFile(testImage))
                    {
                        using(var page = engine.Process(img))
                        {
                            var texto = page.GetText();
                            Console.WriteLine("Taxa de precisao {0} ",page.GetMeanConfidence());

                            Console.WriteLine("Texto :\r\n{0}", texto);
                            //parei em 5:46 do video
                        }
                    }

                }
            }
            catch(Exception Ex)
            {
                Console.WriteLine("erro{0}",Ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }

        }
    }
}
