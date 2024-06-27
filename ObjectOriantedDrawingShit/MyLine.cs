namespace ObjectOriantedDrawingShit
{
    public class MyLine
    {
        #region Members
        public enum Orientation { Vertical, Horizontal };

        private int _top, _left, _dim;
        private Orientation _ori;
        #endregion

        #region Properties

        public int Top
        {
            get { 
                return _top; 
            }
            set {
                if (value < 0)
                {
                    _top = 0;
                }
                else if (value > 100)
                {
                    _top = 100;
                } else
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

        public Orientation Ori
        {
            get { return _ori; }
            set { _ori = value; }
        }
        #endregion

        #region Methods

        public void Draw()
        {
            for (int i = 0; i < _dim; i++)
            {
                if (_ori == Orientation.Horizontal)
                {
                    Console.SetCursorPosition(_left++, _top);
                }
                else
                {
                    Console.SetCursorPosition(_left, _top++);
                }
                Console.Write('*');
            }
        }

        #endregion

        public MyLine(int top, int left, int dim, Orientation ori) {
            Top = top;
            Left = left;
            Dim = dim;
            Ori = ori;
        }
    }
}
