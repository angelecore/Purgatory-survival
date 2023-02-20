using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float speed { get; set; }
    public float health { get; set; }
    public float damage { get; set; }
    public float farmingmodifier { get; set; }
    public float luck { get; set; }
    public float reloadmodifier { get; set; }
    public float jumphight { get; set; }

    public PlayerStats()
    {
        speed= 10f;
        health= 100f;
        damage= 2.5f;
        farmingmodifier = 0f;
        reloadmodifier = 0f;
        luck= 0f;
        jumphight = 5f;
    }
}
