using System.ComponentModel.DataAnnotations;

namespace Rubik.Objects {
    public enum SquareColor : byte {
        [Display(Name = "G")] Green,
        [Display(Name = "B")] Blue,
        [Display(Name = "R")] Red,
        [Display(Name = "O")] Orange,
        [Display(Name = "W")] White,
        [Display(Name = "Y")] Yellow,
    }
}