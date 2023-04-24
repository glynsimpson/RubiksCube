using System.ComponentModel.DataAnnotations;

namespace Rubik.Objects {
    public enum Direction {
        [Display(Name = "Clockwise")] Clockwise,
        [Display(Name = "Anti-clockwise")] AntiClockwise
    }
    public static class FaceExtensions {
        public static string ToString(this Direction rotation) {
            return rotation.ToString().Substring(0, 1);
        }
        public static Direction? getDirection(this Direction face, string thisDirection) {
            foreach (Direction directionList in Enum.GetValues(typeof(Direction))) {
                if (directionList.ToString().Substring(0, 1) == thisDirection.ToUpper()) return directionList;
            }
            return null;
        }
    }
}