using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrySQLiteConsole
{
    public class User
    {
        public int Id;
        public string Name;

        public void Show()
        {
            var message = new StringBuilder()
                .Append($"{nameof(Id)} = {Id} / ")
                .Append($"{nameof(Name)} = {Name}")
                .ToString();

            Console.WriteLine(message);
        }
    }
}
