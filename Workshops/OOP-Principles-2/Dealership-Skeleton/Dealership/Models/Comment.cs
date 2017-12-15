using Dealership.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Models
{
    public class Comment : IComment
    {
        private string content;
        private string author;

        public Comment(string content)
        {
            if (content.Length < 3 || content.Length > 200)
            {
                throw new ArgumentException("Content must be between 3 and 200 characters long!");
            }
            this.content = content ?? throw new ArgumentNullException("Comment content cannot be null!");
        }

        public string Content => this.content;

        public string Author
        {
            get
            {
                return this.author;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Author is null!");
                }

                this.author = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("    ----------");
            sb.AppendLine(string.Format($"    {Content}"));
            sb.AppendLine(string.Format($"      User: {Author}"));
            sb.AppendLine("    ----------");


            return sb.ToString().TrimEnd();
        }
    }

}

