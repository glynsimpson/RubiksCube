using System.ComponentModel.DataAnnotations;
namespace Rubik.Objects {
	public enum Side {
		[Display(Name = "Front")] Front,
		[Display(Name = "Right")] Right,
		[Display(Name = "Up")] Up,
		[Display(Name = "Back")] Back,
		[Display(Name = "Left")] Left,
		[Display(Name = "Down")] Down,
	}

	public static class SideExtensions {
		public static Side GetBackFaceOf(this Side face)
			=> face switch {
				Side.Front => Side.Back,
				Side.Right => Side.Left,
				Side.Back => Side.Front,
				Side.Left => Side.Right,
				Side.Up => Side.Down,
				_ => Side.Up,
			};
		public static Side GetRightFaceOf(this Side face)
			=> face switch {
				Side.Front => Side.Right,
				Side.Right => Side.Back,
				Side.Back => Side.Left,
				Side.Left => Side.Front,
				_ => Side.Right,
			};
		public static Side GetLeftFaceOf(this Side face)
			=> face switch {
				Side.Front => Side.Left,
				Side.Right => Side.Front,
				Side.Back => Side.Right,
				Side.Left => Side.Back,
				_ => Side.Left,
			};
		public static Side GetUpFaceOf(this Side face)
			=> face switch {
				Side.Up => Side.Back,
				Side.Down => Side.Front,
				_ => Side.Up,
			};
		public static Side GetDownFaceOf(this Side face)
			=> face switch {
				Side.Up => Side.Front,
				Side.Down => Side.Back,
				_ => Side.Down,
			};

        public static string ToString(this Side face) {
            return face.ToString().Substring(0, 1);
        }
        public static Side? getFace(this Side face, string thisFace) {
            foreach (Side faceList in Enum.GetValues(typeof(Side))) {
				if (faceList.ToString().Substring(0, 1) == thisFace.ToUpper()) return faceList;
			}
			return null;
        }
    }
}