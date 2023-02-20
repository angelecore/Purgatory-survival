using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Building : MonoBehaviour
{

    private BuildingModel model;
    private BoxCollider boxcollider;
    private GameObject graphic;

    private bool overlaping = false;
    public void Init(BuildingModel data)
    {
        model = data;
        boxcollider = GetComponent<BoxCollider>();
        boxcollider.size = model.size;
        boxcollider.center = new Vector3(0,((model.size.y) +.2f) * 0.5f, 0);
        boxcollider.isTrigger= true;

        var rb = gameObject.AddComponent<Rigidbody>();
        rb.isKinematic = true;

        graphic = Instantiate(data.prefab, transform);

    }

    public BuildingModel Model()
    {
        return model;
    }
    public void place()
    {
        gameObject.layer = 6;
        gameObject.name = model.name;
    }

    public void destoy()
    {
        Destroy(gameObject);
    }

    public bool GetOverlapingflag()
    {
        return overlaping;
    }

    private void OnTriggerStay(Collider other)
    {
        overlaping= true;
    }

    private void OnTriggerExit(Collider other)
    {
        overlaping= false;
    }
}
