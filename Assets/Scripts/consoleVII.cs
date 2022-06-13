using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using UnityEngine;

public class consoleVII : MonoBehaviour
{
    public static consoleVII instance;
    public static bool open = false;
    public static string log = "";
    public static string input = "";
    public static bool cheats = false;
    Vector2 scrollpos;

    public void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            // Only one should exist
            Destroy(this);
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown("`"))
        {
            open = !open;
            input = "";
            Cursor.lockState = (open ? CursorLockMode.None : CursorLockMode.Locked);
            Cursor.visible = open;
        }
    }

    public void OnGUI()
    {
        if (open)
        {
            scrollpos = GUI.BeginScrollView(new Rect(0, 0, Screen.width, 400), scrollpos, new Rect(0, 0, Screen.width, log.Split('\n').Length * 15));
            GUI.TextArea(new Rect(0, 0, Screen.width, Mathf.Max(400, log.Split('\n').Length * 15)), log);
            GUI.EndScrollView();
            GUI.SetNextControlName("CommandInput");
            input = GUI.TextArea(new Rect(0, 400, Screen.width, 20), input); // A bit hacky but it should work
            GUI.FocusControl("CommandInput");
            if (input.EndsWith("\n") && input.Trim() != "")
            {
                input = input.Trim();
                this.print("\n>" + input);
                RunCommand(input);
                input = "";
            }
            if(input.EndsWith("`"))
            {
                open = !open;
                input = "";
                Cursor.lockState = (open ? CursorLockMode.None : CursorLockMode.Locked);
                Cursor.visible = open;
            }
        }
    }

    void print(string text, string end = "\n")
    {
        log += text;
        log += end;
    }

    void RunCommand(string arg)
    {
        string[] args = arg.Split(' ');
        IEnumerable<MethodInfo> commands = Assembly.GetCallingAssembly().GetTypes().SelectMany(t => t.GetMethods())
            .Where(m => m.GetCustomAttributes(typeof(cmd), false).Length > 0);
        foreach (MethodInfo command in commands)
        {
            cmd cmd_info = (cmd)command.GetCustomAttribute(typeof(cmd));
            if (cmd_info.name == args[0])
            {
                if (!cmd_info.cheat || cheats)
                {

                    command.Invoke(null, new object[] { args });
                    return;
                }
                else
                {
                    this.print("This command requires cheats to work");
                    return;
                }
            }
        }
        this.print("Command not found");
    }

    [cmd("help", description = "displays all commands")]
    public static void Help(string[] args)
    {
        IEnumerable<MethodInfo> commands = Assembly.GetCallingAssembly().GetTypes().SelectMany(t => t.GetMethods())
            .Where(m => m.GetCustomAttributes(typeof(cmd), false).Length > 0);
        foreach (MethodInfo command in commands)
        {
            cmd cmd_info = (cmd)command.GetCustomAttribute(typeof(cmd));
            consoleVII.instance.print(cmd_info.name + " - " + cmd_info.description + (cmd_info.cheat ? " - Cheat" : ""));
        }
    }

    [cmd("noclip", cheat = true, description = "fly through everything. except for the roomba. we are not responsible for any deaths")]
    public static void Noclip(string[] args)
    {
        FindObjectOfType<PlayerMovement>().noclip = !FindObjectOfType<PlayerMovement>().noclip;
        if (FindObjectOfType<PlayerMovement>().noclip)
        {
            FindObjectOfType<PlayerMovement>().gameObject.layer = 6;
            consoleVII.instance.print("You feel ethereal");
        }
        else
        {
            FindObjectOfType<PlayerMovement>().gameObject.layer = 3;
            consoleVII.instance.print("You no longer feel ethereal");
        }
    }

    [cmd("cheats", description = "enables cheats. but you wouldn't, right?")]
    public static void Cheats(string[] args)
    {
        consoleVII.cheats = !consoleVII.cheats;
        if (consoleVII.cheats)
        {
            consoleVII.instance.print("Cheats enabled");
        }
        else
        {
            consoleVII.instance.print("Cheats disabled");
        }
    }
    
    [cmd("god", cheat = true, description = "makes all your murderous roomba woes go aways with one simple command!")]
    public static void God(string[] args)
    {
        FindObjectOfType<die>().god = !FindObjectOfType<die>().god;
        consoleVII.instance.print(FindObjectOfType<die>().god ? "Immortality granted" : "Immortality revoked");
    }
    
    [cmd("unlimited-sprint", cheat = true, description = "no more waiting for sprint to regen")]
    public static void UnlimitedSprint(string[] args)
    {
        FindObjectOfType<PlayerMovement>().usprint = !FindObjectOfType<PlayerMovement>().usprint;
        consoleVII.instance.print(FindObjectOfType<PlayerMovement>().usprint ? "Infinite sprint enabled" : "Infinite sprint disabled");
    }

    [cmd("timescale", cheat = true, description = "changes the time scale")]
    public static void Timescale(string[] args)
    {
        if (args.Length != 2)
            consoleVII.instance.print("Usage: timescale <number>");
        float timescale = float.Parse(args[1]);
        Time.timeScale = timescale;
    }

    [cmd("clear", description = "clears the console")]
    public static void Clear(string[] args)
    {
        consoleVII.log = "";
    }

    [cmd("delete-lights", cheat = true, description = "WARNING: CANNOT BE REVERSED!")]
    public static void Fullbright(string[] args)
    {
        foreach (Light l in FindObjectsOfType<Light>())
        {
            Destroy(l);
        }
        RenderSettings.ambientLight = new Color(1, 1, 1);
        RenderSettings.reflectionIntensity = 0;
        RenderSettings.fog = false;
        consoleVII.instance.print("Lights deleted");
    }
}

[System.AttributeUsage(System.AttributeTargets.Method)]
public class cmd : System.Attribute
{
    public string name;
    public string description = "Not yet described";
    public bool cheat = false;
    public cmd(string name)
    {
        this.name = name;
    }
}
