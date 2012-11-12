using System.Text;

namespace GameOfLife
{
    public class CustomStringBuilder
    {
        private readonly StringBuilder sb;

        public CustomStringBuilder()
        {
            sb = new StringBuilder();
        }

        public void Append(string s)
        {
            sb.Append(s);
        }

        public string Flush()
        {
            var s = sb.ToString();
            sb.Clear();
            return s;
        }
    }
}
