using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[LuaApi(luaName = "Scenes", description = "Load scenes and create scenes")]
public class SceneAPI : LuaAPIBase
{
    public SceneAPI() : base("Scenes") { }

    protected override void InitialiseAPITable()
    {
        m_ApiTable["ChangeScene"] = (System.Func<string, bool>)(Lua_ChangeScene);
        m_ApiTable["GetCurrentScene"] = (System.Func<string>)(Lua_GetCurrentScene);
    }
    [LuaApiFunction(name = "ChangeScene", description = "Change scenes", codeExample = "Scenes.ChangeScene(\"MenuScene\")")]
    private bool Lua_ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
        return true;
    }
    [LuaApiFunction(name = "GetCurrentScene", description = "Returns current scene", codeExample = "Scenes.GetCurrentScene() == \"CustomLevel\"")]
    private string Lua_GetCurrentScene()
    {
        return SceneManager.GetActiveScene().name;
    }
}
