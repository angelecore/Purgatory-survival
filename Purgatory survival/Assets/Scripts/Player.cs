using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerStats stats;
    private PlayerStats basestats;
    bool sprinting = false;
    void Start()
    {
        stats = new PlayerStats();
        basestats = new PlayerStats();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            sprinting = true;
            setSprintSpeed(stats.speed*2);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            sprinting = false;
            setSprintSpeed(basestats.speed);
        }


    }

    private void setSprintSpeed(float modifier)
    {
        stats.speed = modifier;
    }
    public PlayerStats GetStats()
    {
        return stats;
    }
}
