using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool buildingModeEnabled = false;
    bool deleteModeEnabled = false;
    private Player player;
    void Start()
    {
        player= GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            buildingModeEnabled = !buildingModeEnabled;
            deleteModeEnabled = false;
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            deleteModeEnabled = !deleteModeEnabled;
            buildingModeEnabled = false;
        }
    }
    public bool getBuildingMode()
    {
        return buildingModeEnabled;
    }
    public bool getDeletionMode()
    {
        return deleteModeEnabled;
    }
}
