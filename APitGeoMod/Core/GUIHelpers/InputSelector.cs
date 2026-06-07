using Astras_PitGeo.Libraries;

namespace Astras_PitGeo.Core.GUIHelpers;

public static class InputSelector
{
    public static string[] PitGInputNames =
    {
        "Right Grab",
        "Left Grab",
        "Right Trigger",
        "Left Trigger",
        "RightJoyStick (Hold)",
        "LeftJoyStick (Hold)",
        "A",
        "B",
        "X",
        "Y"
    };

    public static Func<bool>[] PitGInputs =
    {
        () => InputLib.RightGrab,
        () => InputLib.LeftGrab,
        () => InputLib.RightTrigger,
        () => InputLib.LeftTrigger,
        () => InputLib.RightJoystickClick,
        () => InputLib.LeftJoystickClick,
        () => InputLib.RightControllerAButton,
        () => InputLib.RightControllerBButton,
        () => InputLib.LeftControllerXButton,
        () => InputLib.LeftControllerYButton
    };

    public static int PitGSelectedIndex = 0;

    public static bool PitPressed => PitGInputs[PitGSelectedIndex]?.Invoke() ?? false;

}
