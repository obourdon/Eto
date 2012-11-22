using System;
using System.IO;
using System.Reflection;

namespace Eto.Drawing
{
    public interface IPen : IInstanceWidget
	{
        float Width { get; set; }
        PenAlignment Alignment { get; set; }
        Color Color { get; set; }
        void Create(Color color, float width, PenAlignment alignment, DashStyle dashStyle);
        void Create(Brush brush);
    }

    public class Pen : InstanceWidget
	{        
		IPen inner;

        public float Width
        {
            get { return inner.Width; }
            set { inner.Width = value; }
        }

        public PenAlignment Alignment
        {
            get { return inner.Alignment; }
            set { inner.Alignment = value; }
        }

        public Pen(): 
            this(Generator.Current)
        {
        }

        public Pen(Generator g)
            : base(g, typeof(IPen))
        {
            inner = (IPen)Handler;
        }

        public Pen(Generator g, Color color, float width, PenAlignment alignment, DashStyle dashStyle)
            : this(Generator.Current)
        {
            inner.Create(color, width, alignment, dashStyle);
        }

        public Pen(Brush brush)
            : this(Generator.Current)
        {
            inner.Create(brush);
        }

        public Color Color
        {
            get
            {
                return inner.Color;
            }
            set
            {
                inner.Color = value;
            }
        }
    }

    // Summary:
    //     Specifies the alignment of a Pen in relation to the
    //     theoretical, zero-width line.
    public enum PenAlignment
    {
        // Summary:
        //     The Pen object is centered over the theoretical line.
        Center = 0,
        //
        // Summary:
        //     The Pen is positioned on the inside of the
        //     theoretical line.
        Inset = 1,
        //
        // Summary:
        //     The Pen is positioned on the outside of the theoretical
        //     line.
        Outset = 2,
        //
        // Summary:
        //     The Pen is positioned to the left of the theoretical
        //     line.
        Left = 3,
        //
        // Summary:
        //     The Pen is positioned to the right of the theoretical
        //     line.
        Right = 4,
    }

    // Summary:
    //     Specifies the style of dashed lines drawn with a Pen.
    public enum DashStyle
    {
        // Summary:
        //     A solid line.
        Solid = 0,
        //
        // Summary:
        //     A line consisting of dashes.
        Dash = 1,
        //
        // Summary:
        //     A line consisting of dots.
        Dot = 2,
        //
        // Summary:
        //     A line consisting of a repeating pattern of dash-dot.
        DashDot = 3,
        //
        // Summary:
        //     A line consisting of a repeating pattern of dash-dot-dot.
        DashDotDot = 4,
        //
        // Summary:
        //     A user-defined custom dash style.
        Custom = 5,
    }
}
