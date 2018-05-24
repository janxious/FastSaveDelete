using System;
using System.Reflection;
using BattleTech.Save.SaveGameStructure;
using BattleTech.UI;
using Harmony;
using UnityEngine;

namespace FastSaveDelete
{
    public class FastSaveDelete
    {
        public static void Init(string directory, string settingsJSON)
        {
            var harmony = HarmonyInstance.Create("com.joelmeador.FastSaveDelete");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }

    [HarmonyPatch(typeof(SGLoadSavedGameScreen), "DeleteSave")]
    public static class SGLoadSavedGameScreenDeleteSavePatch
    {
        static bool Prefix(
            ref SlotModel slot,
            SGLoadSavedGameScreen __instance)
        {
            SlotModel mostRecentSave = __instance.saveStructure.MostRecentSave;
            // normal behavior for the most recent save.
            if (slot == mostRecentSave) return true;

            ActuallyDeleteSave(__instance, slot);
            return false;
        }

        private static void ActuallyDeleteSave(SGLoadSavedGameScreen screen, SlotModel slot)
        {
            try
            {
                screen.saveStructure.Delete(slot);
            }
            catch (Exception ex)
            {
                Debug.LogError($"Exception caught: {ex.Message}");
            }

            ReflectionHelper.InvokePrivateMethode(screen, "BringToFront", new object[] { }, new Type[] { });
        }
    }

    public static class ReflectionHelper
    {
        public static MethodInfo GetPrivateMethodInfo(object instance, string methodname, Type[] types)
        {
            Type type = instance.GetType();
            MethodInfo methodInfo = type.GetMethod(methodname, BindingFlags.NonPublic | BindingFlags.Instance, null,
                types, null);
            return methodInfo;
        }

        public static object InvokePrivateMethode(object instance, string methodname, object[] parameters, Type[] types)
        {
            MethodInfo methodInfo = GetPrivateMethodInfo(instance, methodname, types);
            return methodInfo.Invoke(instance, parameters);
        }
    }
}