using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class console : MonoBehaviour
{
    public GameObject textEntry;
    public GameObject consoleObject;
    public GameObject consoleOutput;
    public Dictionary<string, string> commandsFunctions =
        new Dictionary<string, string>();
    string[] args;
    private void Start()
    {
        commandsFunctions.Add("noclip", "doNoclip");
        commandsFunctions.Add("map", "doChangeMap");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tilde))
        {
            consoleObject.SetActive(!consoleObject.activeSelf);
        }
    }
    public void enterCommand()
    {
        if (commandsFunctions.ContainsKey(textEntry.GetComponentInChildren<TMP_InputField>().text))
        {
            args = textEntry.GetComponentInChildren<TMP_InputField>().text.Split(' ');
            print(args);
            Invoke(commandsFunctions[textEntry.GetComponentInChildren<TMP_InputField>().text],0);
        }
    }
    private void doChangeMap()
    {
        if (args.Length > 1) 
        { 
            FindObjectOfType<loadingAnimPlayer>().loadnext(args[1]);
        }
        else
        {
            consoleOutput.GetComponent<TMP_Text>().text += "\n";
            consoleOutput.GetComponent<TMP_Text>().text += "You must specify a map to load!";
        }
    }
}
