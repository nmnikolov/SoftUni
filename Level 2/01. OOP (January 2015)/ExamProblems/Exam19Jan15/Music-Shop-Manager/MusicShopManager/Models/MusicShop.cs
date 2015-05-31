namespace MusicShopManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Instrument.Drum;
    using Instrument.Guitar;
    using Interfaces;

    public class MusicShop : IMusicShop
    {
        private const int MusicShopDelimiterLength = 5;
        private const char MusicShopDelimiterSymbol = '=';
        private const char ArticleDelimiterSymbol = '-';
        private const string DefaultRequiredMessage = "The {0} is required";
        private string name;

        public MusicShop(string name)
        {
            this.Name = name;
            this.Articles = new List<IArticle>();
        }

        public string Name 
        {
            get
            {
                return this.name;
            }
            
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(DefaultRequiredMessage, "name"));
                }

                this.name = value;
            }
        }

        public IList<IArticle> Articles { get; private set; }

        public void AddArticle(IArticle article)
        {
            this.Articles.Add(article);
        }

        public void RemoveArticle(IArticle article)
        {
            this.Articles.Remove(article);
        }

        public string ListArticles()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(string.Format("{0} {1} {0}", new string(MusicShopDelimiterSymbol, MusicShopDelimiterLength), this.Name));

            if (this.Articles.Any())
            {
                var shop = new List<string>();

                var microphones = this.Articles.Where(a => a is Microphone.Microphone).ToList();
                var drums = this.Articles.Where(a => a is Drum).ToList();
                var electricGuitars = this.Articles.Where(a => a is ElectricGuitar).ToList();
                var acousticGuitars = this.Articles.Where(a => a is AcousticGuitar).ToList();
                var bassGuitars = this.Articles.Where(a => a is BassGuitar).ToList();

                AddToShop(shop, "Microphones", microphones);
                AddToShop(shop, "Drums", drums);
                AddToShop(shop, "Electric guitars", electricGuitars);
                AddToShop(shop, "Acoustic guitars", acousticGuitars);
                AddToShop(shop, "Bass guitars", bassGuitars);

                output.Append(string.Join(Environment.NewLine, shop));
            }
            else
            {
                output.AppendLine("The shop is empty. Come back soon.");
            }

            return output.ToString();
        }

        private static void AddToShop(ICollection<string> shop, string instrumentType, List<IArticle> articles)
        {
            if (articles.Any())
            {
                var orderedArticles = articles.OrderBy(a => a.Make + " " + a.Model);
                var articlesStr = string.Format(
                    "{0} {1} {0}{2}{3}",
                    new string(ArticleDelimiterSymbol, MusicShopDelimiterLength),
                    instrumentType,
                    Environment.NewLine,
                    string.Join(Environment.NewLine, orderedArticles));

                shop.Add(articlesStr);
            }
        }
    }
}