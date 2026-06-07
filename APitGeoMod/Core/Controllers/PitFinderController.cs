using UnityEngine;
using Astras_PitGeo.Core.GUIHelpers;
using static Astras_PitGeo.Core.Global.GlobalVars;

namespace Astras_PitGeo.Core.Controllers;

public class PitFinderController : MonoBehaviour
{
    private void Start()
    {
        FindObjects();
    }

    private void FixedUpdate()
    {
        if (PitModOnn)
        {
            WallSettings();
            PitGroundSettings();
        }
    }

    private void FindObjects()
    {
        PitWallUpper = GameObject.Find(ObjPath + "pit upper slippery wall");
        PitWallLower = GameObject.Find(ObjPath + "pit lower slippery wall");
        PitGroundTop = GameObject.Find(ObjPath + "pit ground top");
        PitGroundBottom = GameObject.Find(ObjPath + "pit ground bottom");
    }

    private void WallSettings()
    {
        switch (SlipOptions)
        {
            case SlipWallPitOptions.None:
                break;

            case SlipWallPitOptions.UpperSlipWall:
                if (PitWallUpper != null)
                SurfaceMult(PitWallUpper, WallSlipMult, WallSlipMultOther);
                break;

            case SlipWallPitOptions.LowerSlipWall:
                if (PitWallLower != null) SurfaceMult(PitWallLower, WallSlipMult, WallSlipMultOther); break;

            case SlipWallPitOptions.BothSlipWalls:
                if (PitWallLower != null) SurfaceMult(PitWallLower, WallSlipMult, WallSlipMultOther);
                if (PitWallUpper != null) SurfaceMult(PitWallUpper, WallSlipMult, WallSlipMultOther);
                break;
        }
    }

    private void PitGroundSettings()
    {
        switch (GroundOptions)
        {
            case PitGroundOptions.None:
                break;

            case PitGroundOptions.PitGroundTop:
               if (PitGroundTop != null) SurfaceMult(PitGroundTop, GroundMult, GroundMultOther); break;

            case PitGroundOptions.PitGroundBottom:
                if (PitGroundBottom != null) SurfaceMult(PitGroundBottom, GroundMult, GroundMultOther); break;
        }
    }

    private void SurfaceMult(GameObject OBJ, float MLT1, float MLT2)
    {
        if (OBJ == null) return;

        GorillaSurfaceOverride Surface = OBJ.GetComponent<GorillaSurfaceOverride>();

        if (Surface == null) return;

        if (InputSelector.PitPressed)
        {
            Surface.extraVelMultiplier = MLT1;
            Surface.extraVelMaxMultiplier = MLT2;
        }
    }
}