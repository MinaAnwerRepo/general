using System.Text;
using System.IO;
using System.Windows.Forms;

namespace TextBoxStreamDirector
{
    public class ConsoleWriter : TextWriter
    {
        TextBox _output = null;

        public ConsoleWriter(TextBox output)
        {
            _output = output;
            _output.ScrollBars = ScrollBars.Both;
            _output.WordWrap = true;
        }
        public ConsoleWriter(TextBox output, bool WordWrap, ScrollBars bar)
        {
            _output = output;
            _output.ScrollBars = bar;
            _output.WordWrap = WordWrap;
        }

        public override void Write(char value)
        {
            base.Write(value);
            _output.AppendText(value.ToString());    // When character data is written, append it to the text box.
        }

        public override Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
    }

}
