namespace Rubik.Objects {
    public class CubeMove {
        public Side Side { get; }
        public Direction Direction { get; }
        public CubeMove(Side side, Direction direction) {
            Side = side;
            Direction = direction;
        }
    }
}