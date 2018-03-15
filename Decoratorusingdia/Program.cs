using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decoratorusingdia
{
    class Program
    {
        static void Main(string[] args)
        {
            TextField TXTfield = new TextField(2,5);
            ScrollDecorator newscrolly = new ScrollDecorator(TXTfield);
            ScrollDecorator otherscrolly = new ScrollDecorator(newscrolly);
            BorderDecorator newBorder = new BorderDecorator(otherscrolly);
            BorderDecorator otherBorder = new BorderDecorator(newBorder);
            TXTfield.Draw();
            otherBorder.Draw();


            Console.ReadKey();
        }

        class TextField : Widget
        {
            int width;
            int height;
            public override void Draw()
            {
                Console.WriteLine("TextField: " + width + ", " + height);
            }

            public TextField(int w, int h)
            {
                width = w;
                height = h;
            }
        }

        class BorderDecorator : Decorator
        {

            public BorderDecorator(Widget w) : base(w)
            {
                
            }
            public override void Draw()
            {
                base.Draw();
                
                Console.WriteLine("\tBorderDecorator");
            }
        }

        class ScrollDecorator : Decorator
        {
           
            public ScrollDecorator(Widget w):base(w)
            {
              
            }
            public override void Draw()
            {
                base.Draw();
                Console.WriteLine("\tScrollDecorator");
            }
        }

        abstract class Decorator : Widget
        {
            Widget wid;
            public Decorator(Widget w)
            {
                wid = w;
            }
            public override void Draw()
            {
                wid.Draw();
            }
        }

        abstract class Widget
        {
            public abstract void Draw();
        }
    }
}
