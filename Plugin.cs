using BepInEx;
using HarmonyLib;
using UnityEngine;
using System.Reflection;
using ModelReplacement;
using BepInEx.Configuration;
using System;
using System.Xml.Linq;

namespace NepModelReplacement
{
    [BepInPlugin("meow.NepModelReplacement", "Hyperdimension Neptunia Model Replacement", "0.1.0")]
    [BepInDependency("meow.ModelReplacementAPI", BepInDependency.DependencyFlags.HardDependency)]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Assets.PopulateAssets();

            ModelReplacementAPI.RegisterSuitModelReplacement("Nepgear", typeof(MRNEPGEAR));
            ModelReplacementAPI.RegisterSuitModelReplacement("NepgearCosplay", typeof(MRNEPGEARCOSPLAY));
            ModelReplacementAPI.RegisterSuitModelReplacement("NepgearIdol", typeof(MRNEPGEARIDOL));
            ModelReplacementAPI.RegisterSuitModelReplacement("NepgearMaid", typeof(MRNEPGEARMAID));
            ModelReplacementAPI.RegisterSuitModelReplacement("NepgearSwimsuit", typeof(MRNEPGEARSWIMSUIT));
            ModelReplacementAPI.RegisterSuitModelReplacement("Neptune", typeof(MRNEPTUNE));
            ModelReplacementAPI.RegisterSuitModelReplacement("NeptuneIdol", typeof(MRNEPTUNEIDOL));
            ModelReplacementAPI.RegisterSuitModelReplacement("NeptuneSchool", typeof(MRNEPTUNESCHOOL));
            ModelReplacementAPI.RegisterSuitModelReplacement("NeptuneSwimsuit", typeof(MRNEPTUNESWIMSUIT));
            ModelReplacementAPI.RegisterSuitModelReplacement("NeptuneV", typeof(MRNEPTUNEV));
            ModelReplacementAPI.RegisterSuitModelReplacement("Noire", typeof(MRNOIRE));
            ModelReplacementAPI.RegisterSuitModelReplacement("NoireIdol", typeof(MRNOIREIDOL));
            ModelReplacementAPI.RegisterSuitModelReplacement("NoireSchool", typeof(MRNOIRESCHOOL));
            ModelReplacementAPI.RegisterSuitModelReplacement("NoireSwimsuit", typeof(MRNOIRESWIMSUIT));
            ModelReplacementAPI.RegisterSuitModelReplacement("NoireV", typeof(MRNOIREV));
            ModelReplacementAPI.RegisterSuitModelReplacement("Plutia", typeof(MRPLUTIA));
            ModelReplacementAPI.RegisterSuitModelReplacement("PlutiaSwimsuit", typeof(MRPLUTIASWIMSUIT));
            ModelReplacementAPI.RegisterSuitModelReplacement("Ram", typeof(MRRAM));
            ModelReplacementAPI.RegisterSuitModelReplacement("RamCosplay", typeof(MRRAMCOSPLAY));
            ModelReplacementAPI.RegisterSuitModelReplacement("RamIdol", typeof(MRRAMIDOL));
            ModelReplacementAPI.RegisterSuitModelReplacement("RamMaid", typeof(MRRAMMAID));
            ModelReplacementAPI.RegisterSuitModelReplacement("RamSwimsuit", typeof(MRRAMSWIMSUIT));
            ModelReplacementAPI.RegisterSuitModelReplacement("Rom", typeof(MRROM));
            ModelReplacementAPI.RegisterSuitModelReplacement("RomCosplay", typeof(MRROMCOSPLAY));
            ModelReplacementAPI.RegisterSuitModelReplacement("RomIdol", typeof(MRROMIDOL));
            ModelReplacementAPI.RegisterSuitModelReplacement("RomMaid", typeof(MRROMMAID));
            ModelReplacementAPI.RegisterSuitModelReplacement("RomSwimsuit", typeof(MRROMSWIMSUIT));
            ModelReplacementAPI.RegisterSuitModelReplacement("Uni", typeof(MRUNI));
            ModelReplacementAPI.RegisterSuitModelReplacement("UniCosplay", typeof(MRUNICOSPLAY));
            ModelReplacementAPI.RegisterSuitModelReplacement("UniIdol", typeof(MRUNIIDOL));
            ModelReplacementAPI.RegisterSuitModelReplacement("UniMaid", typeof(MRUNIMAID));
            ModelReplacementAPI.RegisterSuitModelReplacement("UniSwimsuit", typeof(MRUNISWIMSUIT));




            Harmony harmony = new Harmony("meow.NepModelReplacement");
            harmony.PatchAll();
            Logger.LogInfo($"Plugin {"meow.NepModelReplacement"} is loaded!");
        }
    }
    public static class Assets
    {
        // Replace mbundle with the Asset Bundle Name from your unity project 
        public static string mainAssetBundleName = "nepbundle";
        public static AssetBundle MainAssetBundle = null;

        private static string GetAssemblyName() => Assembly.GetExecutingAssembly().GetName().Name.Replace(" ","_");
        public static void PopulateAssets()
        {
            if (MainAssetBundle == null)
            {
                Console.WriteLine(GetAssemblyName() + "." + mainAssetBundleName);
                using (var assetStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(GetAssemblyName() + "." + mainAssetBundleName))
                {
                    MainAssetBundle = AssetBundle.LoadFromStream(assetStream);
                }

            }
        }
    }

}