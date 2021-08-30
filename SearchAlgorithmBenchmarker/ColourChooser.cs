using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchAlgorithmBenchmarker
{
    public partial class ColourChooser : ComboBox
    {
        public ColourChooser()
        {
            InitializeComponent();
            PopulateItems();

            DropDownStyle = ComboBoxStyle.DropDownList;
            DrawMode = DrawMode.OwnerDrawFixed;
            DrawItem += OnDrawItem;
        }

        private void PopulateItems()
        {
            Items.Clear();
            this.Items.Add(new ColourInfo("Black", Color.Black));
            this.Items.Add(new ColourInfo("Light Blue", Color.LightBlue));
            this.Items.Add(new ColourInfo("Navy Blue", Color.Navy));
            this.Items.Add(new ColourInfo("Green", Color.Green));
            this.Items.Add(new ColourInfo("Yellow", Color.Yellow));
            this.Items.Add(new ColourInfo("White", Color.White));
            this.Items.Add(new ColourInfo("Custom", Color.White));
            this.SelectedIndex = 0;
        }

        protected void OnDrawItem(object sender, DrawItemEventArgs e)
        {
            // Get colour
            ColourInfo col = (ColourInfo)Items[e.Index];

            // Fill background
            e.DrawBackground();

            // Fill colour box
            Rectangle rect = new Rectangle();
            rect.X = e.Bounds.X + 2;
            rect.Y = e.Bounds.Y + 2;

            rect.Width = 18;
            rect.Height = e.Bounds.Height - 5;
            e.Graphics.FillRectangle(new SolidBrush(col.Colour), rect);
            e.Graphics.DrawRectangle(SystemPens.WindowText, rect);

            // Draw colour name
            Brush brush = (e.State & DrawItemState.Selected) != DrawItemState.None ? SystemBrushes.HighlightText : SystemBrushes.WindowText;
            e.Graphics.DrawString(col.Name, Font, brush, e.Bounds.X + rect.X + rect.Width + 2, e.Bounds.Y + ((e.Bounds.Height - Font.Height) / 2));

            // Draw focus rect if needed
            if ((e.State & DrawItemState.NoFocusRect) == DrawItemState.None)
            {
                e.DrawFocusRectangle();
            }
        }

        public new ColourInfo SelectedItem
        {
            get
            {
                return (ColourInfo)base.SelectedItem;
            }

            set
            {
                base.SelectedItem = value;
                
            }
        }

        public new string SelectedText
        {
            get
            {
                return SelectedIndex >= 0 ? SelectedItem.Name : string.Empty;
            }

            set
            {
                for(int i = Items.Count - 1; i >= 0; i--)
                {
                    if(((ColourInfo)Items[i]).Name == value)
                    {
                        SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        public new Color SelectedValue
        {
            get
            {
                return SelectedIndex >= 0 ? SelectedItem.Colour : Color.White;
            }

            set
            {
                for (int i = Items.Count - 1; i >= 0; i--)
                {
                    if (((ColourInfo)Items[i]).Colour == value)
                    {
                        SelectedIndex = i;
                        break;
                    }
                }
            }
        }

    }

    public class ColourInfo
    {
        public string Name { get; set; }
        public Color Colour { get; set; }
        public ColourInfo(string name, Color col) { Name = name; Colour = col; }
    }

}
