// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Management : MonoBehaviour
{
    /// <summary> method <c>NewGame</c> Enables starting values, begins game anew. </summary>
    public void NewGame()
    {
        StaticManagement.newGameBegun = true;
    }

    /// <summary> method <c>LoadGame</c> Reads the users save data from file. </summary>
    public void LoadGame()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
