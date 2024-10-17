namespace ObjectOriantedDrawingShit
{
    internal class MyRectangle
    {
        #region Members

        private int _dim;
        private int _height;

        private int _left;
        private int _top;

        private RctnglOpts _opts;

        public enum RctnglOpts { Filled, Outline };

        #endregion

        #region Setters
        public int Length
        {
            get { return _dim; }
            set
            {
                if (value < 0)
                {
                    _dim = 0;
                }
                else if (value > 100)
                {
                    _dim = 100;
                }
                else
                {
                    _dim = value;
                }
            }
        }
        public int Height
        {
            get { return _height; }
            set
            {
                if (value < 0)
                {
                    _height = 0;
                }
                else if (value > 100)
                {
                    _height = 100;
                }
                else
                {
                    _height = value;
                }
            }
        }
        public int Top
        {
            get { return _top; }
            set
            {
                if (value < 0)
                {
                    _top = 0;
                }
                else if (value > 100)
                {
                    _top = 100;
                }
                else
                {
                    _top = value;
                }
            }
        }

        public int Left
        {
            get { return _left; }
            set
            {
                if (value < 0)
                {
                    _left = 0;
                }
                else if (value > 100)
                {
                    _left = 100;
                }
                else
                {
                    _left = value;
                }
            }
        }

        public int Dim
        {
            get { return _dim; }
            set
            {
                if (value < 0)
                {
                    _dim = 0;
                }
                else if (value > 100)
                {
                    _dim = 100;
                }
                else
                {
                    _dim = value;
                }
            }
        }
        public RctnglOpts Opts
        {
            get { return _opts; }
            set { _opts = value; }
        }
        #endregion

        public void Draw()
        {
            if (_opts == RctnglOpts.Outline)
            {
                MyLine left = new MyLine(_top, _left, _dim, MyLine.Orientation.Vertical);
                MyLine top = new MyLine(_top, _left, _dim, MyLine.Orientation.Horizontal);
                MyLine bottom = new MyLine(_top * 2, _left, _dim+1, MyLine.Orientation.Horizontal);
                MyLine right = new MyLine(_top, _left * 2, _dim, MyLine.Orientation.Vertical);

                left.Draw();
                top.Draw();
                bottom.Draw();
                right.Draw();
            } else
            {
                MyLine ö;
                for (int i = _dim; i > 0; i--)
                {
                    ö = new MyLine(_top, _left, i, MyLine.Orientation.Horizontal); // doesn't work
                }
            }
        }

        public MyRectangle(int length, int height, int left, int top, RctnglOpts opts)
        {
            Dim = length;
            Height = height;
            Left = left;
            Top = top;
            Opts = opts;
        }
    }
}
