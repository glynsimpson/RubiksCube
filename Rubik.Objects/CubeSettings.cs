namespace Rubik.Objects {
    public class CubeSettings {
        public int Size { get; }
        public SquareColor[] SquareColors { get; } = new SquareColor[6];

        public CubeSettings(
            SquareColor front = SquareColor.Green,
            SquareColor right = SquareColor.Red,
            SquareColor back = SquareColor.Blue,
            SquareColor left = SquareColor.Orange,
            SquareColor up = SquareColor.White,
            SquareColor down = SquareColor.Yellow) {
            Size = 3;
            SquareColors[(int)Side.Front] = front;
            SquareColors[(int)Side.Right] = right;
            SquareColors[(int)Side.Back] = back;
            SquareColors[(int)Side.Left] = left;
            SquareColors[(int)Side.Up] = up;
            SquareColors[(int)Side.Down] = down;
        }
    }
}