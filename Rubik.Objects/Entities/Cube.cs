using System.Text;

namespace Rubik.Objects {
    public class Cube {
        public Face[] Faces { get; } = new Face[6];

        public CubeSettings Settings { get; }
        public Cube(CubeSettings settings) {
            Settings = settings;
            foreach (Side face in Enum.GetValues(typeof(Side))) {
                Faces[(int)face] = new Face(face, settings);
            }
        }

        public void Execute(Side side, Direction rotation) {
            Execute(new CubeMove(side, rotation));
        }
        public void Execute(CubeMove moveRequest) {
            var side = moveRequest.Side;
            // Copy and set the move request face as front.
            Face[] rotatedCube = CloneCubeAndSetFrontAs(side);

            rotatedCube = RotateFrontFace(moveRequest, rotatedCube);

            // Put back the rotated cube.
            Parallel.ForEach(rotatedCube, item => Faces[(int)item.OriginalFace] = item);
        }

        private Face[] CloneCubeAndSetFrontAs(Side side) {
            var rotatedCube = new Face[6];
            rotatedCube[(int)Side.Front] = Faces[(int)side];
            rotatedCube[(int)Side.Up] = Faces[(int)side.GetUpFaceOf()];
            rotatedCube[(int)Side.Left] = Faces[(int)side.GetLeftFaceOf()];
            rotatedCube[(int)Side.Right] = Faces[(int)side.GetRightFaceOf()];
            rotatedCube[(int)Side.Back] = Faces[(int)side.GetBackFaceOf()];
            rotatedCube[(int)Side.Down] = Faces[(int)side.GetDownFaceOf()];
            return rotatedCube;
        }

        private Face[] RotateFrontFace(CubeMove moveRequest, Face[] cube) {
            var frontFace = cube[(int)Side.Front];
            var rightFace = cube[(int)Side.Right];
            var upFace = cube[(int)Side.Up];
            var leftFace = cube[(int)Side.Left];
            var downFace = cube[(int)Side.Down];

            // Correct the rotation of other faces if the front face changes from original side.
            if (moveRequest.Side == Side.Left) {
                upFace.Rotate90(false);
                downFace.Rotate90(true);
            } else if (moveRequest.Side == Side.Right) {
                upFace.Rotate90(true);
                downFace.Rotate90(false);
            } else if (moveRequest.Side == Side.Back) {
                upFace.Rotate180();
                downFace.Rotate180();
            } else if (moveRequest.Side == Side.Up) {
                rightFace.Rotate90(false);
                leftFace.Rotate90(true);
                upFace.Rotate180();
            } else if (moveRequest.Side == Side.Down) {
                rightFace.Rotate90(true);
                leftFace.Rotate90(false);
                downFace.Rotate180();
            }

            // Set the rotation effect of current front face and other faces.
            frontFace.Rotate90(moveRequest.Direction == Direction.Clockwise);
            if (moveRequest.Direction == Direction.Clockwise) {
                Square[] upRow = upFace.GetRow(Settings.Size - 1);
                upFace.SetRow(Settings.Size - 1, leftFace.GetColumn(Settings.Size - 1), true);
                leftFace.SetColumn(Settings.Size - 1, downFace.GetRow(0), true);
                downFace.SetRow(0, rightFace.GetColumn(0), true);
                rightFace.SetColumn(0, upRow, true);
            } else if (moveRequest.Direction == Direction.AntiClockwise) {
                Square[] upRow = upFace.GetRow(Settings.Size - 1);
                upFace.SetRow(Settings.Size - 1, rightFace.GetColumn(0), false);
                rightFace.SetColumn(0, downFace.GetRow(0), false);
                downFace.SetRow(0, leftFace.GetColumn(Settings.Size - 1), false);
                leftFace.SetColumn(Settings.Size - 1, upRow, false);
            }

            // Reverse cube rotations;
            if (moveRequest.Side == Side.Left) {
                upFace.Rotate90(true);
                downFace.Rotate90(false);
            } else if (moveRequest.Side == Side.Right) {
                upFace.Rotate90(false);
                downFace.Rotate90(true);
            } else if (moveRequest.Side == Side.Back) {
                upFace.Rotate180();
                downFace.Rotate180();
            } else if (moveRequest.Side == Side.Up) {
                rightFace.Rotate90(true);
                leftFace.Rotate90(false);
                upFace.Rotate180();
            } else if (moveRequest.Side == Side.Down) {
                rightFace.Rotate90(false);
                leftFace.Rotate90(true);
                downFace.Rotate180();
            }

            return cube;
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            foreach (Face face in Faces) {
                foreach (Square square in face.Squares) {
                    sb.Append(square.ToString());
                }
            }
            return sb.ToString();
        }
    }
}