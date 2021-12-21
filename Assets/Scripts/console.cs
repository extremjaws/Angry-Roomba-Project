using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class console : MonoBehaviour
{
    public GameObject textEntry;
    public GameObject consoleObject;
    public GameObject consoleOutput;
    public LayerMask layerMask;
    public GameObject[] spawnable;
    public Dictionary<string, string> commandsFunctions =
        new Dictionary<string, string>();
    string[] args;
    public bool cheats = false;
    private void Start()
    {
        commandsFunctions.Add("noclip", "doNoclip");
        commandsFunctions.Add("map", "doChangeMap");
        commandsFunctions.Add("cheats", "toggleCheats");
        commandsFunctions.Add("god", "toggleGodMode");
        commandsFunctions.Add("spawn", "doSpawn");
    }
    private void Update()
    {
        if (Input.GetKeyDown("`"))
        {
            consoleObject.SetActive(!consoleObject.activeSelf);
            if (Cursor.lockState == CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            textEntry.GetComponentInChildren<TMP_InputField>().ActivateInputField();
        }
    }
    public void enterCommand()
    {
        args = textEntry.GetComponentInChildren<TMP_InputField>().text.Split(' ');
        if (commandsFunctions.ContainsKey(args[0]))
        {
            Invoke(commandsFunctions[args[0]],0);
            textEntry.GetComponentInChildren<TMP_InputField>().ActivateInputField();
        }
        else
        {
            consoleOutput.GetComponent<TMP_Text>().text += "\n";
            consoleOutput.GetComponent<TMP_Text>().text += "Command not recognized";
            textEntry.GetComponentInChildren<TMP_InputField>().ActivateInputField();
        }
    }
    private void doChangeMap()
    {
        if (args.Length >= 1) 
        { 
            FindObjectOfType<loadingAnimPlayer>().loadnext(args[1]);
        }
        else
        {
            consoleOutput.GetComponent<TMP_Text>().text += "\n";
            consoleOutput.GetComponent<TMP_Text>().text += "You must specify a map to load!";
        }
    }
    private void doNoclip()
    {
        if (cheats)
        {
            FindObjectOfType<PlayerMovement>().noclip = !FindObjectOfType<PlayerMovement>().noclip;
            if (FindObjectOfType<PlayerMovement>().noclip)
            {
                FindObjectOfType<PlayerMovement>().gameObject.layer = 6;
                consoleOutput.GetComponent<TMP_Text>().text += "\n";
                consoleOutput.GetComponent<TMP_Text>().text += "Noclip enabled";
            }
            else
            {
                FindObjectOfType<PlayerMovement>().gameObject.layer = 3;
                consoleOutput.GetComponent<TMP_Text>().text += "\n";
                consoleOutput.GetComponent<TMP_Text>().text += "Noclip disabled";
            }
        }
        else
        {
            consoleOutput.GetComponent<TMP_Text>().text += "\n";
            consoleOutput.GetComponent<TMP_Text>().text += "You must enable cheats first! (command: cheats)";
        }
    }
    private void toggleCheats()
    {
        cheats = !cheats;
        consoleOutput.GetComponent<TMP_Text>().text += "\n";
        consoleOutput.GetComponent<TMP_Text>().text += "Cheats is now set to " + cheats.ToString();
    }
    private void toggleGodMode()
    {
        if (cheats)
        {
            FindObjectOfType<die>().god = !FindObjectOfType<die>().god;
            if (FindObjectOfType<die>().god)
            {
                consoleOutput.GetComponent<TMP_Text>().text += "\n";
                consoleOutput.GetComponent<TMP_Text>().text += "God mode enabled";
            }
            else
            {
                consoleOutput.GetComponent<TMP_Text>().text += "\n";
                consoleOutput.GetComponent<TMP_Text>().text += "God mode disabled";
            }
        }
        else
        {
            consoleOutput.GetComponent<TMP_Text>().text += "\n";
            consoleOutput.GetComponent<TMP_Text>().text += "You must enable cheats first! (command: cheats)";
        }
    }
    private void doSpawn()
    {
        if (cheats)
        {
            if(args.Length == 2)
            {
                int arg1 = 0;
                if(int.TryParse(args[1], out arg1))
                {
                    if(arg1 < spawnable.Length && arg1 >= 0)
                    {
                        RaycastHit hit;
                        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformVector(Vector3.forward), out hit, 1000, layerMask))
                        {
                            Instantiate(spawnable[arg1], hit.point, Quaternion.identity);
                        }
                    }
                    else
                    {
                        consoleObject.GetComponent<TMP_Text>().text += "\n";
                        consoleObject.GetComponent<TMP_Text>().text += "Expected \"spawnable id\" in range of 0 to " + spawnable.Length.ToString();
                    }
                }
            }
            else
            {
                consoleObject.GetComponent<TMP_Text>().text += "\n";
                consoleObject.GetComponent<TMP_Text>().text += "Expected 1 argument \"spawnable id\"";
            }
        }
        else
        {
            consoleOutput.GetComponent<TMP_Text>().text += "\n";
            consoleOutput.GetComponent<TMP_Text>().text += "You must enable cheats first! (command: cheats)";
        }
    }
}
