using System;
using BepInEx;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;
using GorillaNetworking;
using UnityEngine.Networking;

namespace KnownIssues
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class Class1 : BaseUnityPlugin
    {
        private const string modGUID = "KnownIssues";
        private const string modName = "KnownIssues";
        private const string modVersion = "1.0.0";

        static string textURL = "";
        static string finishText;

        // When the script is started do this \\
        public void Awake()
        {
            // Harmony Patches \\
            var harmony = new Harmony(modGUID);
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        [HarmonyPatch(typeof(GorillaLocomotion.Player))]
        [HarmonyPatch("FixedUpdate", MethodType.Normal)]
        class MainPatch
        {
            static void Prefix(GorillaLocomotion.Player __instance)
            {
                try
                {
                    for (int i = 0; i < GorillaComputer.instance.levelScreens.Length; i++)
                    {
                        Material colorr = new Material(Shader.Find("Standard"));
                        colorr.color = Color.black;
                        GameObject.Find("Level/lower level/StaticUnlit/screen").GetComponent<Renderer>().material = colorr;
                        GameObject.Find("Level/lower level/UI/CodeOfConduct").GetComponent<Text>().text = "[<color=yellow>KNOWN ISSUES</color>]";
                        GameObject.Find("Level/lower level/UI/CodeOfConduct/COC Text").GetComponent<Text>().text = finishText;
                    }
                }
                catch
                {

                }
            }
        }
    }
}
