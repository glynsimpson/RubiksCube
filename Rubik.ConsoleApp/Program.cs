namespace Rubik.ConsoleApp {
    internal class Program {
        private static async Task Main(string[] args) {
            Console.Title = "Rubik's cube simulator";
            ManipulateCube cube = new ManipulateCube();
            await cube.UseCube();
        }
    }
}