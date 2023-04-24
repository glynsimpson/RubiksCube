using Rubik.Objects;
namespace Rubik.ConsoleApp;

internal class ManipulateCube {
    Cube cube = new Cube(new CubeSettings());
    public Task UseCube() {
        // Collect the user's commands
        sendLayout(cube.ToString());
        do {
            Side moveFace = getFace();
            Direction moveDirection = getDirection();
            CubeMove move = new CubeMove(moveFace, moveDirection);

            if (move is not null) {
                getLayout(move);
                sendLayout(cube.ToString());
            }
        } while (true);
    }
    public void getLayout(CubeMove move) {
        // To manipulate cube from outside the program, pass CubeMove directly into here 
        cube.Execute(move);
    }
    private void sendLayout(string layout) {
        // Replace Console.WriteLine with code to send layout to wherever
        Console.WriteLine(layout);
    }
    private Side getFace() {
        Side? moveFace = new Side();
        do {
            Console.WriteLine("Which face do you want to turn? F/R/U/B/L/D ");
            string faceText = Console.ReadLine() + "";
            Side checkFace = new Side();
            moveFace = checkFace.getFace(faceText);
        } while (moveFace == null);
        return (Side)moveFace;
    }
    private Direction getDirection() {
        Direction? moveDirection = new Direction();
        do {
            Console.WriteLine("In which direction? C/A ");
            string directionText = Console.ReadLine() + "";
            Direction checkDirection = new Direction();
            moveDirection = checkDirection.getDirection(directionText);
        } while (moveDirection == null);
        return (Direction)moveDirection;
    }
}
