using HarmonyLib;

namespace Astras_PitGeo.Stuff;

public class Patcher
{
    public static void Apply()
    {
        Harmony VALL = new(Constantss.GUID);
        VALL.PatchAll();
    }
}