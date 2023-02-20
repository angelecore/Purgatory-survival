using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Building/Model")]
public class BuildingModel : ScriptableObject
{
    public string title;
    public Sprite sprite;
    public int gridsnap;
    public GameObject prefab;
    public Vector3 size;

}
