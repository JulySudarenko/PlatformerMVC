namespace Level
{
    public class Square
    {
        public ControlNode TopLeft;
        public ControlNode TopRight;
        public ControlNode BottomLeft;
        public ControlNode BottomRight;

        public Square(ControlNode topLeft, ControlNode topRight, ControlNode bottomRight, ControlNode bottomLeft)
        {
            TopLeft = topLeft;
            TopRight = topRight;
            BottomLeft = bottomLeft;
            BottomRight = bottomRight;
        }
    }
}
