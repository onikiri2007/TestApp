using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using TestApp2.Models;
using Xamarin.Forms;

namespace TestApp2.Services
{
    public interface IRandomizerService
    {
        Task<Pattern> GetRandomPattern();
        Task<Pattern> GetRandomColor();
        Size GetRandomSize(double withinWidth, double withinHeight);
    }


    public class RandomizerService : IRandomizerService
    {
        private const string RANDOM_IMAGE_URL = "http://www.colourlovers.com/api/patterns/random";
        private const string RANDOM_COLOR_URL = "http://www.colourlovers.com/api/colors/random";

        public async Task<Pattern> GetRandomPattern()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(1);
                    var r = await client.GetAsync(RANDOM_IMAGE_URL);

                    if (r.StatusCode == HttpStatusCode.OK)
                    {
                        var res = await r.Content.ReadAsStringAsync();

                       
                        var doc = XDocument.Parse(res);

                        var imageUrlNode = doc.Root.Elements().First().Elements("imageUrl").FirstOrDefault();

                        if (imageUrlNode != null)
                        {
                            return new Pattern()
                            {
                                ImageUrl = imageUrlNode.Value
                            };
                        }
                    }


                }

               
            }
            catch
            {
                
            }

            return GetLocalRandomColor();
        }

        private Pattern GetLocalRandomColor()
        {
            return new Pattern()
            {
                Color = GenerateRandomColor()
            };
        }

        private static Color GenerateRandomColor()
        {
            var generator = RandomProvider.GetRandomGenerator();
            return Color.FromRgb(generator.Next(0,255), generator.Next(0,255), generator.Next(0,255));
        }

        public async Task<Pattern> GetRandomColor()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var r = await client.GetAsync(RANDOM_COLOR_URL);

                    if (r.StatusCode == HttpStatusCode.OK)
                    {
                        var res = await r.Content.ReadAsStringAsync();


                        var doc = XDocument.Parse(res);

                        var colorNode = doc.Root.Elements().First().Elements("rgb").FirstOrDefault();

                        if (colorNode != null)
                        {
                            var red = int.Parse(colorNode.Elements("red").First().Value);
                            var green = int.Parse(colorNode.Elements("green").First().Value);
                            var blue = int.Parse(colorNode.Elements("blue").First().Value);
                            return new Pattern()
                            {
                                Color = Color.FromRgb(red, green, blue)
                            };
                        }
                    }
                }
            }
            catch
            {
               
            }

            return GetLocalRandomColor();
        }

        public Size GetRandomSize(double withinWidth, double withinHeight)
        {
            var generator = RandomProvider.GetRandomGenerator();
            var width = generator.Next(24, (int) withinHeight/4);
            var height = generator.Next(24, (int) withinHeight/4);
            return new Size(width, height);
        }

        
    }
}
