using System;
using System.Drawing;
using System.Windows.Forms;

namespace SearchAlgorithmBenchmarker
{
    public class IO
    {
        public static void Print(RichTextBox tb, string msg)
        {
            tb.Text += msg + '\n';
        }

        public static void SetWarningText(Label lbl, Color col, string msg)
        {
            lbl.Text = msg;
            lbl.ForeColor = col;
        }

        public static void SetWarningText(Label lbl, string msg)
        {
            lbl.Text = msg;
        }

        public static void ResetWarningText(Label lbl)
        {
            lbl.Text = string.Empty;
            lbl.ForeColor = Color.Black;
        }

        public static bool ParseInt(TextBox tb, ref int val)
        {
            return int.TryParse(tb.Text, out val);
        }

        public static void Clear(RichTextBox tb)
        {
            tb.Text = string.Empty;
        }
    }
}
