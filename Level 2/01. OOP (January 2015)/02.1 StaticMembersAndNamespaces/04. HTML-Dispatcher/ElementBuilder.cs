namespace HTML_Dispatcher
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ElementBuilder
    {
        private readonly string[] tags = 
        { 
            "!DOCTYPE", "a", "abbr", "address", "area", "article", "aside",
            "audio", "b", "base", "bdi", "bdo", "blockquote", "body", "br", "button", "canvas", "caption", "cite", "code",
            "col", "colgroup", "command", "datalist", "dd", "del", "details", "dfn", "div", "dl", "dt", "em", "embed",
            "fieldset", "figcaption", "figure", "footer", "form", "h1 - h6", "head", "header", "hgroup", "hr", "html",
            "i", "iframe", "img", "input", "ins", "kbd", "keygen", "label", "legend", "li", "link", "map", "mark", "menu",
            "meta", "meter", "nav", "noscript", "object", "ol", "optgroup", "option", "output", "p", "param", "pre",
            "progress", "q", "rp", "rt", "ruby", "s", "samp", "script", "section", "select", "small", "source", "span",
            "strong", "style", "sub", "summary", "sup", "table", "tbody", "td", "textarea", "tfoot", "th", "thead", "time",
            "title", "tr", "track", "u", "ul", "var", "video", "wbr" 
        };

        private readonly string[] voidElements = 
        { 
            "area", "base", "br", "col", "embed", "hr", "img", "input",
            "keygen", "link", "meta", "param", "source", "track", "wbr" 
        };

        private string name;

        public ElementBuilder(string name)
        {
            this.Name = name;
            this.Content = string.Empty;
            this.Attributes = new Dictionary<string, string>();
        }

        public string Content { get; set; }

        public Dictionary<string, string> Attributes { get; private set; }      

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                if (!this.tags.Contains(value))
                {
                    throw new ArgumentOutOfRangeException("name", "Invalid tag name.");
                }

                this.name = value;
            }
        }

        public static string operator *(ElementBuilder element, int count)
        {
            StringBuilder result = new StringBuilder(element.ToString());
            for (int i = 1; i < count; i++)
            {
                result.Append(element);
            }

            return result.ToString();
        }
            
        public void AddAttribute(string attribute, string value)
        {
            if (string.IsNullOrEmpty(attribute))
            {
                throw new ArgumentException("Attribute cannot be empty");
            }

            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Attribute value cannot be empty");
            }
            
            this.Attributes.Add(attribute, value);
        }

        public void AddContent(string elementContent)
        {
            this.Content += elementContent;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("<{0}", this.Name);
            for (int i = 0; i < this.Attributes.Count; i++)
            {
                result.AppendFormat(" {0}=\"{1}\"", this.Attributes.ElementAt(i).Key, this.Attributes.ElementAt(i).Value);
            }

            if (this.voidElements.Contains(this.Name))
            {
                result.Append(" />");
            }
            else
            {
                result.AppendFormat(">{0}</{1}>", this.Content, this.Name);
            }
            
            return result.ToString();
        }
    }
}