namespace Rubik.Objects {
	public class Square { 
		public SquareColor Colour { get; }
		public (string row, string column) OriginalPositon { get; }

		public Square(SquareColor colour, (int row, int column) position) {
			Colour = colour;
			OriginalPositon = (position.row.ToString(), position.column.ToString());
		}

		public static Square Green((int row, int column) originalPositon)
			=> new Square(SquareColor.Green, originalPositon);
		public static Square Blue((int row, int column) originalPositon)
			=> new Square(SquareColor.Blue, originalPositon);
		public static Square Red((int row, int column) originalPositon)
			=> new Square(SquareColor.Red, originalPositon);
		public static Square Orange((int row, int column) originalPositon)
			=> new Square(SquareColor.Orange, originalPositon);
		public static Square White((int row, int column) originalPositon)
			=> new Square(SquareColor.White, originalPositon);
		public static Square Yellow((int row, int column) originalPositon)
			=> new Square(SquareColor.Yellow, originalPositon);

        public override string ToString() {
            return Colour.ToString().Substring(0, 1);
        }
    }
}