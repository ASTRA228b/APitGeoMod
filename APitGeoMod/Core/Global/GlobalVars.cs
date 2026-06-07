using UnityEngine;

namespace Astras_PitGeo.Core.Global;

public static class GlobalVars
{
    public enum SlipWallPitOptions
    {
        None,
        UpperSlipWall,
        LowerSlipWall,
        BothSlipWalls,
    }

    public enum PitGroundOptions
    {
        None,
        PitGroundTop,
        PitGroundBottom
    }

    public static SlipWallPitOptions SlipOptions = SlipWallPitOptions.None;
    public static PitGroundOptions GroundOptions = PitGroundOptions.None;

    public static GameObject? PitWallUpper;
    public static GameObject? PitWallLower;
    public static GameObject? PitGroundTop;
    public static GameObject? PitGroundBottom;

    public static string ObjPath = "Environment Objects/LocalObjects_Prefab/Forest/Terrain/";

    public static float WallSlipMult = 1f;
    public static float WallSlipMultOther = 1f;

    public static float GroundMult = 1f;
    public static float GroundMultOther = 1f;

    public static bool PitModOnn = false;
}