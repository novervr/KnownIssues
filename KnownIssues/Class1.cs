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


        // When the script is started do this \\
        public void Awake()
        {
            Debug.Log("Mod has been sucessfully read by BepInEx!");
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
                        colorr.color = Color.cyan;
                        // Find all text elements in Level/lower level/UI for Code of Conduct and the color for \\
                        GameObject.Find("Level/lower level/StaticUnlit/screen").GetComponent<Renderer>().material = colorr;
                        GameObject.Find("Level/lower level/UI/CodeOfConduct").GetComponent<Text>().text = "[<color=yellow>KNOWN ISSUES MOD</color>]";
                        GameObject.Find("Level/lower level/UI/CodeOfConduct/COC Text").GetComponent<Text>().text = "THE CURRENT ISSUE FOR THIS MOD IS GETTING INFO FROM A GITHUB PAGE. PLEASE WAIT FOR V1.0.1 UNTIL THIS IS FIXED. THANKS";
                    }


                }
                catch
                {

                }
            }
        }
    }
}
