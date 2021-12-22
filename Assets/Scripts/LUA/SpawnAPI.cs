using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[LuaApi(luaName = "Objects", description = "Spawn objects and get objects in the world")]
public class SpawnAPI : LuaAPIBase
{
    public SpawnAPI() : base("Objects") {  }
    protected override void InitialiseAPITable()
    {
        m_ApiTable["SpawnObject"] = (System.Func<int, float, float, float, bool>)(Lua_SpawnObject);
        m_ApiTable["SpawnObjectExt"] = (System.Func<int, float, float, float, float, float, float, bool>)(Lua_SpawnObjectExt);
        m_ApiTable["FindPlayer"] = (System.Func<float[]>)(Lua_FindPlayer);
        m_ApiTable["FindRoombas"] = (System.Func<float[][]>)(Lua_FindRoombas);
        m_ApiTable["FindObjects"] = (System.Func<float[][]>)(Lua_FindObjects);
        m_ApiTable["ObjectNames"] = (System.Func<string[]>)(Lua_ObjectNames);
        m_ApiTable["SetPlayerPos"] = (System.Func<float, float, float, bool>)(Lua_SetPlayerPos);
        m_ApiTable["DeleteObject"] = (System.Func<int, bool>)(Lua_DeleteObject);
        m_ApiTable["SetObjectPos"] = (System.Func<int, float, float, float, bool>)(Lua_SetObjectPos);
    }
    [LuaApiFunction(name = "SpawnObject", description = "Spawns a object at a given x y z", codeExample = "SpawnObject(0, 25, 12, 5) -- Spawns a hammer at x 25, y 12, and z 5")]
    private bool Lua_SpawnObject(int id, float x, float y, float z)
    {
        GameObject[] spawnable = Object.FindObjectOfType<console>().spawnable;
        if (id < spawnable.Length && id >= 0)
        {
            Object.Instantiate(spawnable[id], new Vector3(x, y, z), Quaternion.identity);
            return true;
        }
        return false;
    }
    [LuaApiFunction(name = "SpawnObjectExt", description = "Spawns a object at a given x y z with a rotation", codeExample = "SpawnObject(2, 25, 12, 5, 0, 90, 0) -- Spawns a I hallway piece rotated on the y direction by 90 degrees")]
    private bool Lua_SpawnObjectExt(int id, float x, float y, float z, float rx, float ry, float rz)
    {
        GameObject[] spawnable = Object.FindObjectOfType<console>().spawnable;
        if (id < spawnable.Length && id >= 0)
        {
            Object.Instantiate(spawnable[id], new Vector3(x, y, z), Quaternion.Euler(rx,ry,rz));
            return true;
        }
        return false;
    }
    [LuaApiFunction(name = "FindPlayer", description = "Finds the player and returns the x y z in a table [x, y, z]", codeExample = "SpawnObject(0, FindPlayer()[1], FindPlayer()[2], FindPlayer()[3]) -- give the player a hammer")]
    private float[] Lua_FindPlayer()
    {
        return new float[] { Object.FindObjectOfType<PlayerMovement>().transform.position.x, Object.FindObjectOfType<PlayerMovement>().transform.position.y, Object.FindObjectOfType<PlayerMovement>().transform.position.z };
    }
    [LuaApiFunction(name = "FindRoombas", description = "Finds all the existing roombas and returns the x y z in tables in a table {{x, y, z}}")]
    private float[][] Lua_FindRoombas()
    {
        List<float[]> roombapos = new List<float[]>();
        controller[] roombas = Object.FindObjectsOfType<controller>();
        foreach (controller roomba in roombas)
        {
            roombapos.Add(new float[] { roomba.transform.position.x, roomba.transform.position.y, roomba.transform.position.z });
        }
        return roombapos.ToArray();
    }
    [LuaApiFunction(name = "FindPlayer", description = "Finds the player and returns the x y z in a table [x, y, z]", codeExample = "SpawnObject(0, FindPlayer()[1], FindPlayer()[2], FindPlayer()[3]) -- give the player a hammer")]
    private bool Lua_SetPlayerPos(float x, float y, float z)
    {
        Object.FindObjectOfType<PlayerMovement>().transform.position = new Vector3(x, y, z);
        return true;
    }
    [LuaApiFunction(name = "FindObjects", description = "Finds all the existing gameobjects and returns the x y z in tables in a table {{x, y, z}}")]
    private float[][] Lua_FindObjects()
    {
        List<float[]> objectpos = new List<float[]>();
        GameObject[] objects = Object.FindObjectsOfType<GameObject>();
        foreach (GameObject _object in objects)
        {
            objectpos.Add(new float[] { _object.transform.position.x, _object.transform.position.y, _object.transform.position.z });
        }
        return objectpos.ToArray();
    }
    [LuaApiFunction(name = "ObjectNames", description = "Returns a table of all object names")]
    private string[] Lua_ObjectNames()
    {
        List<string> objectpos = new List<string>();
        GameObject[] objects = Object.FindObjectsOfType<GameObject>();
        foreach (GameObject _object in objects)
        {
            objectpos.Add(_object.name);
        }
        return objectpos.ToArray();
    }
    [LuaApiFunction(name = "DeleteObject", description = "Deletes the object with the specified index")]
    private bool Lua_DeleteObject(int index)
    {
        GameObject[] objects = Object.FindObjectsOfType<GameObject>();
        Object.Destroy(objects[index]);
        return true;
    }
    [LuaApiFunction(name = "SetObjectPos")]
    private bool Lua_SetObjectPos(int index, float x, float y, float z)
    {
        GameObject[] objects = Object.FindObjectsOfType<GameObject>();
        objects[index].transform.position = new Vector3(x, y, z);
        return true;
    }
}
