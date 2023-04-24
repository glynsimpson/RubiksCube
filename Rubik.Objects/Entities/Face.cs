namespace Rubik.Objects {
	public class Face { 
		public int FaceSize { get; }
		public Side OriginalFace { get; }
		public Square[,] Squares { get; }

		public Face(Side face, Square[,] squares, int faceSize) {
			OriginalFace = face;
			FaceSize = faceSize;
			Squares = squares;
		}

		public Face(Side face, SquareColor squareColor, int faceSize) {
			OriginalFace = face;
			FaceSize = faceSize;
			Squares = new Square[faceSize, faceSize];

			foreach (int rowIndex in Enumerable.Range(0, faceSize)) {
				foreach (int columnIndex in Enumerable.Range(0, faceSize)) {
					Squares[rowIndex, columnIndex] = new Square(squareColor, (rowIndex, columnIndex));
				}
			}
		}

		public Face(Side face, CubeSettings settings) : this(face, settings.SquareColors[(int)face], settings.Size) { }

		public Square[] GetRow(int rowIndex) {
			var rowSquares = new Square[FaceSize];
			for (int columnIndex = 0; columnIndex < FaceSize; columnIndex++) {
				rowSquares[columnIndex] = Squares[rowIndex, columnIndex];
			}
			return rowSquares;
		}

		public Square[] GetColumn(int columnIndex) {
			var columnSquares = new Square[FaceSize];
			for (int rowIndex = 0; rowIndex < FaceSize; rowIndex++) {
				columnSquares[rowIndex] = Squares[rowIndex, columnIndex];
			}
			return columnSquares;
		}

		public void SetRow(int rowIndex, Square[] columns, bool clockwise) {
			if (columns.Length != FaceSize) throw new ArgumentException($"The row does not contain the correct number of columns. Size must be {FaceSize}");

			for (int columnIndex = 0; columnIndex < FaceSize; columnIndex++) {
				if (clockwise)
					Squares[rowIndex, columnIndex] = columns[FaceSize - 1 - columnIndex];
				else
					Squares[rowIndex, columnIndex] = columns[columnIndex];
			}
		}

		public void SetColumn(int columnIndex, Square[] rows, bool clockwise) {
			if (rows.Length != FaceSize) throw new ArgumentException($"The columns does not contain the correct number of rows. Size must be {FaceSize}");

			for (int rowIndex = 0; rowIndex < FaceSize; rowIndex++) {
				if (clockwise)
					Squares[rowIndex, columnIndex] = rows[rowIndex];
				else
					Squares[rowIndex, columnIndex] = rows[FaceSize - rowIndex - 1];
			}
		}

		public void Rotate90(bool clockwise) {
			for (int rowIndex = 0; rowIndex < FaceSize / 2; rowIndex++) {
				for (int colIndex = rowIndex; colIndex < FaceSize - rowIndex - 1; colIndex++) {
					var temp = Squares[rowIndex, colIndex];
					if (clockwise) {
						Squares[rowIndex, colIndex] = Squares[FaceSize - colIndex - 1, rowIndex];
						Squares[FaceSize - colIndex - 1, rowIndex] = Squares[FaceSize - rowIndex - 1, FaceSize - colIndex - 1];
						Squares[FaceSize - rowIndex - 1, FaceSize - colIndex - 1] = Squares[colIndex, FaceSize - rowIndex - 1];
						Squares[colIndex, FaceSize - rowIndex - 1] = temp;
					} else {
						Squares[rowIndex, colIndex] = Squares[colIndex, FaceSize - rowIndex - 1];
						Squares[colIndex, FaceSize - rowIndex - 1] = Squares[FaceSize - rowIndex - 1, FaceSize - colIndex - 1];
						Squares[FaceSize - rowIndex - 1, FaceSize - colIndex - 1] = Squares[FaceSize - colIndex - 1, rowIndex];
						Squares[FaceSize - colIndex - 1, rowIndex] = temp;
					}
				}
			}
		}

		public void Rotate180() {
			var temp = new Square[FaceSize, FaceSize];

			// copy the original array to temp array
			for (int i = 0; i < FaceSize; i++) {
				for (int j = 0; j < FaceSize; j++) {
					temp[i, j] = Squares[i, j];
				}
			}

			// use temp array to rotate and set the original array
			for (int i = 0; i < FaceSize; i++) {
				for (int j = 0; j < FaceSize; j++) {
					Squares[FaceSize - i - 1, FaceSize - j - 1] = temp[i, j];
				}
			}
		}
	}
}