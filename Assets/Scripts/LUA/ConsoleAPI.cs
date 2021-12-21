using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[LuaApi(luaName = "Console", description = "Access the console for printing debug and running commands")]
public class ConsoleAPI : LuaAPIBase
{
    public ConsoleAPI() : base("Console") { }
    protected override void InitialiseAPITable()
    {
        m_ApiTable["RunCommand"] = (System.Func<string, bool>)(Lua_RunCommand);
    }
    [LuaApiFunction(name = "RunCommand", description = "Run console command", codeExample = "Console.RunCommand(\"cheats\") -- enable cheats")]
    private bool Lua_RunCommand(string command)
    {
        MonoBehaviour.FindObjectOfType<console>().textEntry.GetComponent<TMP_InputField>().text = command;
        MonoBehaviour.FindObjectOfType<console>().enterCommand();
        return true;
    }
}
