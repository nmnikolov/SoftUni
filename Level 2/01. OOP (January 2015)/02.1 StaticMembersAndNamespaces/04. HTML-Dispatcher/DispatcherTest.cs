using System;

namespace HTML_Dispatcher
{
    class DispatcherTest
    {
        public static void Main()
        {
            try
            {
                ElementBuilder div = new ElementBuilder("div");
                div.AddAttribute("id", "page");
                div.AddAttribute("class", "big");
                div.AddContent("<p>Hello</p>");

                Console.WriteLine(div);
                Console.WriteLine(div*2);
                Console.WriteLine();

                string url = HTMLDispatcher.CreateURL("www.abv.bg", "Abv", "Link to abv.bg");
                string image = HTMLDispatcher.CreateImage("c://image.jpg", "some image", "Image");
                string input = HTMLDispatcher.CreateInput("text", "username", "user");

                Console.WriteLine(url);
                Console.WriteLine(image);
                Console.WriteLine(input);
                Console.WriteLine();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
            }          
        }
    }
}