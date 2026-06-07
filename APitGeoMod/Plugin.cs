using Astras_PitGeo.Core;
using Astras_PitGeo.Core.Controllers;
using Astras_PitGeo.Stuff;
using BepInEx;
using UnityEngine;

namespace Astras_PitGeo.Loader;

[BepInPlugin(Constantss.GUID, Constantss.Name, Constantss.Version)]
public class Plugin : BaseUnityPlugin
{
    private void Start()
    {
        Patcher.Apply();
    }

    private void Awake()
    {
        GameObject PluginOBJ = new(Constantss.ObjectName);
        PluginOBJ.AddComponent<Main>();
        PluginOBJ.AddComponent<PitFinderController>();
        DontDestroyOnLoad(PluginOBJ);
    }
}