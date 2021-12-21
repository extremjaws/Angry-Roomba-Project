using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[LuaApi(luaName = "Objects", description = "Spawn objects and get objects in the world")]
public class SpawnAPI : LuaAPIBase
{
    public SpawnAPI() : base("Objects") {  }
    protected override void InitialiseAPITable()
    {
        m_ApiTable["SpawnObject"] = (System.Func<int,int,int,int,bool>)(Lua_SpawnObject);
    }
    [LuaApiFunction(name = "SpawnObject", description = "Spawns a object at a given x y z", codeExample = "SpawnObject(0, 25, 12, 5) -- Spawns a hammer at x 25, y 12, and z 5")]
    private bool Lua_SpawnObject(int id, int x, int y, int z)
    {
        GameObject[] spawnable = MonoBehaviour.FindObjectOfType<console>().spawnable;
        if(id < spawnable.Length && id >= 0)
        {
            MonoBehaviour.Instantiate(spawnable[id], new Vector3(x, y, z), Quaternion.identity);
            return true;
        }
        return false;
    }
}
