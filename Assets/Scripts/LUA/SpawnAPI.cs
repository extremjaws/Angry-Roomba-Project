using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[LuaApi(luaName = "Objects", description = "Spawn objects and get objects in the world")]
public class SpawnAPI : LuaAPIBase
{
    public SpawnAPI() : base("Objects") {  }
    protected override void InitialiseAPITable()
    {
        m_ApiTable["SpawnObject"] = (System.Func<int, int, int, int, bool>)(Lua_SpawnObject);
        m_ApiTable["SpawnObjectExt"] = (System.Func<int, int, int, int, int, int, int, bool>)(Lua_SpawnObjectExt);
        m_ApiTable["FindPlayer"] = (System.Func<float[]>)(Lua_FindPlayer);
        m_ApiTable["FindRoombas"] = (System.Func<float[][]>)(Lua_FindRoombas);
        m_ApiTable["SetPlayerPos"] = (System.Func<int,int,int,bool>)(Lua_SetPlayerPos);
    }
    [LuaApiFunction(name = "SpawnObject", description = "Spawns a object at a given x y z", codeExample = "SpawnObject(0, 25, 12, 5) -- Spawns a hammer at x 25, y 12, and z 5")]
    private bool Lua_SpawnObject(int id, int x, int y, int z)
    {
        GameObject[] spawnable = MonoBehaviour.FindObjectOfType<console>().spawnable;
        if (id < spawnable.Length && id >= 0)
        {
            MonoBehaviour.Instantiate(spawnable[id], new Vector3(x, y, z), Quaternion.identity);
            return true;
        }
        return false;
    }
    [LuaApiFunction(name = "SpawnObjectExt", description = "Spawns a object at a given x y z with a rotation", codeExample = "SpawnObject(2, 25, 12, 5, 0, 90, 0) -- Spawns a I hallway piece rotated on the y direction by 90 degrees")]
    private bool Lua_SpawnObjectExt(int id, int x, int y, int z, int rx, int ry, int rz)
    {
        GameObject[] spawnable = MonoBehaviour.FindObjectOfType<console>().spawnable;
        if (id < spawnable.Length && id >= 0)
        {
            MonoBehaviour.Instantiate(spawnable[id], new Vector3(x, y, z), Quaternion.Euler(rx,ry,rz));
            return true;
        }
        return false;
    }
    [LuaApiFunction(name = "FindPlayer", description = "Finds the player and returns the x y z in a table [x, y, z]", codeExample = "SpawnObject(0, FindPlayer()[1], FindPlayer()[2], FindPlayer()[3]) -- give the player a hammer")]
    private float[] Lua_FindPlayer()
    {
        return new float[] { MonoBehaviour.FindObjectOfType<PlayerMovement>().transform.position.x, MonoBehaviour.FindObjectOfType<PlayerMovement>().transform.position.y, MonoBehaviour.FindObjectOfType<PlayerMovement>().transform.position.z };
    }
    [LuaApiFunction(name = "FindRoombas", description = "Finds all the existing roombas and returns the x y z in tables in a table {{x, y, z}}")]
    private float[][] Lua_FindRoombas()
    {
        List<float[]> roombapos = new List<float[]>();
        controller[] roombas = MonoBehaviour.FindObjectsOfType<controller>();
        foreach (controller roomba in roombas)
        {
            roombapos.Add(new float[] { roomba.transform.position.x, roomba.transform.position.y, roomba.transform.position.z });
        }
        return roombapos.ToArray();
    }
    [LuaApiFunction(name = "FindPlayer", description = "Finds the player and returns the x y z in a table [x, y, z]", codeExample = "SpawnObject(0, FindPlayer()[1], FindPlayer()[2], FindPlayer()[3]) -- give the player a hammer")]
    private bool Lua_SetPlayerPos(int x, int y, int z)
    {
        MonoBehaviour.FindObjectOfType<PlayerMovement>().transform.position = new Vector3(x, y, z);
        return true;
    }
}
