using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;

public class ModManager : MonoBehaviour
{
    struct LuaMod
    {
        public LuaVM vm;
        public string directory;
    }
    List<LuaMod> luaMods;
    void Start()
    {
        luaMods = new List<LuaMod>();
        foreach (string modDir in Directory.GetDirectories(".\\Mods"))
        {
            if (modDir.Split('\\')[modDir.Split('\\').Length - 1].StartsWith(".")) continue;
            LuaMod mod;
            mod.vm = new LuaVM();
            mod.directory = modDir+"\\";
            luaMods.Add(mod);
            mod.vm.ExecuteScript(mod.directory+"init.lua");
        }
    }

    private void Update()
    {
        foreach(LuaMod mod in luaMods)
        {
            DynValue updateFunction = mod.vm.GetGlobal("Update");
            if(updateFunction != DynValue.Nil)
            {
                mod.vm.Call(updateFunction);
            }
        }
    }
}
