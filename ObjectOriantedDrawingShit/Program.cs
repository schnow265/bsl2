namespace ObjectOriantedDrawingShit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyRectangle rctngl = new MyRectangle(5, 5, 5, 5, MyRectangle.RctnglOpts.Outline);

            rctngl.Draw();

            Console.ReadLine();
        }
    }
}
