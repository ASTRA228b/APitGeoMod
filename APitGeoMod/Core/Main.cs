using UnityEngine;
using UnityEngine.InputSystem;
using Astras_PitGeo.Core.GUIHelpers;
using static Astras_PitGeo.Core.Global.GlobalVars;

namespace Astras_PitGeo.Core;

public class Main : MonoBehaviour
{
    private Rect Window = new Rect(155, 155, 360, 460);
    private bool Open = false;
    private bool StylesLoded = false;
    private bool dropdownOpen = false;
    private Texture2D? Windowtex, Background, Slidertex, SliderThumbtex;
    private GUIStyle? WindowStyle, Buttonss, SliderStyle, SliderThumbStyle;
    private Color WindowColor = new Color(0.1f, 0.1f, 0.1f, 1f);
    private Color ButtonColor = new Color(0.2f, 0.2f, 0.2f, 1f);
    private Color sliderTrackColor = new Color(0.15f, 0.15f, 0.15f, 1f);
    private Color sliderThumbColor = new Color(0.0f, 0.6f, 1f, 1f);
    private int Currenttab = 0;
    private string[] tabs = { "Main", "Input Settings" };

    private void OnGUI()
    {
        if (!StylesLoded)
        {
            INIT();
            StylesLoded = true;
        }
        if (Open)
        {
            Window.height = dropdownOpen ? 520 : 460;
            Window = GUILayout.Window(876543, Window, UIM, "Astras PitGeos", WindowStyle);
        }
    }

    private void UIM(int id)
    {
        Mod();
        GUILayout.Space(10f);
        if (GUILayout.Button("Close", Buttonss))
        {
            Open = !Open;
        }
        GUI.DragWindow();
    }

    private void Mod()
    {
        GUILayout.BeginVertical();
        Currenttab = GUILayout.Toolbar(Currenttab, tabs, Buttonss);
        switch (Currenttab)
        {
            case 0:
                MainMod();
                break;
            case 1:
                Settings();
                break;
        }
        GUILayout.EndVertical();
    }

    private void MainMod()
    {
        GUILayout.Label("Enable PitGeo");
        PitModOnn = GUILayout.Toggle(PitModOnn, "Enable");
        GUILayout.Space(2f);
        GUILayout.Label("Options:");
        GUILayout.Label("SlipWall");
        GUILayout.BeginHorizontal();
        if (GUILayout.Toggle(SlipOptions == SlipWallPitOptions.None, "None"))
        {
            SlipOptions = SlipWallPitOptions.None;
        }
        if (GUILayout.Toggle(SlipOptions == SlipWallPitOptions.UpperSlipWall, "Upper Wall"))
        {
            SlipOptions = SlipWallPitOptions.UpperSlipWall;
        }
        if (GUILayout.Toggle(SlipOptions == SlipWallPitOptions.LowerSlipWall, "Lower Wall"))
        {
            SlipOptions = SlipWallPitOptions.LowerSlipWall;
        }
        if (GUILayout.Toggle(SlipOptions == SlipWallPitOptions.BothSlipWalls, "Both"))
        {
            SlipOptions = SlipWallPitOptions.BothSlipWalls;
        }
        GUILayout.EndHorizontal();
        GUILayout.Label("Pit Ground");
        GUILayout.BeginHorizontal();
        if (GUILayout.Toggle(GroundOptions == PitGroundOptions.None, "None"))
        {
            GroundOptions = PitGroundOptions.None;
        }
        if (GUILayout.Toggle(GroundOptions == PitGroundOptions.PitGroundTop, "Top Ground"))
        {
            GroundOptions = PitGroundOptions.PitGroundTop;
        }
        if (GUILayout.Toggle(GroundOptions == PitGroundOptions.PitGroundBottom, "Bottom Ground"))
        {
            GroundOptions = PitGroundOptions.PitGroundBottom;
        }
        GUILayout.EndHorizontal();
        GUILayout.Label("Speed Settings:");
        GUILayout.Label("Slip Wall:");
        WallSlipMult = GUILayout.HorizontalSlider(WallSlipMult, 1f, 25f, SliderStyle, SliderThumbStyle);
        GUILayout.Label($"WMult1: {WallSlipMult:F2}");
        WallSlipMultOther = GUILayout.HorizontalSlider(WallSlipMultOther, 1f, 30f, SliderStyle, SliderThumbStyle);
        GUILayout.Label($"WMult2: {WallSlipMultOther:F2}");
        GUILayout.Label("Pit Ground:");
        GroundMult = GUILayout.HorizontalSlider(GroundMult, 1f, 25f, SliderStyle, SliderThumbStyle);
        GUILayout.Label($"GMult1: {GroundMult:F2}");
        GroundMultOther = GUILayout.HorizontalSlider(GroundMultOther, 1f, 30f, SliderStyle, SliderThumbStyle);
        GUILayout.Label($"GMult2: {GroundMultOther:F2}");
        GUILayout.Label($"Current Inputs: {InputSelector.PitGInputNames[InputSelector.PitGSelectedIndex]}");
        GUILayout.Label("Go into Setting to change this");
    }

    private void Settings()
    {
        GUILayout.Label("Set Inputs:");
        int OldIndex = InputSelector.PitGSelectedIndex;
        InputSelector.PitGSelectedIndex = MenuLib.Dropdown(
            "PitGeo_Inpit",
            InputSelector.PitGInputNames,
            InputSelector.PitGSelectedIndex,
            GUILayout.Width(200)
        );
        GUILayout.Label("Current Inputs:");
        GUILayout.Label($"{InputSelector.PitGInputNames[InputSelector.PitGSelectedIndex]}");
    }



    private void Update()
    {

        if (Keyboard.current.nKey.wasPressedThisFrame)
        {
            Open = !Open;
        }
    }
    

   

    private void INIT()
    {
        Windowtex = Texturing.MakeTextures(1, 1, WindowColor);
        Background = Texturing.MakeTextures(1, 1, ButtonColor);
        Slidertex = Texturing.MakeTextures(1, 1, sliderTrackColor);
        SliderThumbtex = Texturing.MakeTextures(1, 1, sliderThumbColor);
        WindowStyle = new GUIStyle(GUI.skin.window);
        WindowStyle.normal.background = Windowtex;
        WindowStyle.hover.background = Windowtex;
        WindowStyle.active.background = Windowtex;
        WindowStyle.focused.background = Windowtex;
        WindowStyle.onNormal.background = Windowtex;
        WindowStyle.onHover.background = Windowtex;
        WindowStyle.onActive.background = Windowtex;
        WindowStyle.onFocused.background = Windowtex;
        WindowStyle.normal.textColor = Color.white;
        WindowStyle.fontStyle = FontStyle.Normal;
        Buttonss = new GUIStyle(GUI.skin.button);
        Buttonss.normal.background = Background;
        Buttonss.active.background = Background;
        Buttonss.hover.background = Background;
        Buttonss.focused.background = Background;
        Buttonss.onNormal.background = Background;
        Buttonss.onActive.background = Background;
        Buttonss.onHover.background = Background;
        Buttonss.onFocused.background = Background;
        Buttonss.normal.textColor = Color.white;
        Buttonss.hover.textColor = Color.blue;
        Buttonss.active.textColor = Color.red;
        Buttonss.focused.textColor = Color.white;
        Buttonss.onNormal.textColor = Color.blue;
        Buttonss.onHover.textColor = Color.blue;
        Buttonss.onActive.textColor = Color.blue;
        Buttonss.onFocused.textColor = Color.blue;
        SliderStyle = new GUIStyle(GUI.skin.horizontalSlider);
        SliderThumbStyle = new GUIStyle(GUI.skin.horizontalSliderThumb);
        SliderStyle.normal.background = Slidertex;
        SliderStyle.active.background = Slidertex;
        SliderStyle.hover.background = Slidertex;
        SliderThumbStyle.normal.background = SliderThumbtex;
        SliderThumbStyle.active.background = SliderThumbtex;
        SliderThumbStyle.hover.background = SliderThumbtex;
    }

}