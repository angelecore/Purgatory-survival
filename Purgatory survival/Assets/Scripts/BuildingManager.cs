using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BuildingManager : MonoBehaviour
{
    Camera camera;
    RaycastHit hit;
    private float buildDistance = 20f;
    public LayerMask buildingMask;
    public LayerMask deletionMask;

    public Building buildObject;
    public GameManager gameManager;
    public Building target;
    public BuildingModel tempmodel;
    void Start()
    {
        camera = Camera.main;
        // gameManager = GetComponent<GameManager>();
        ChooseBuilding(tempmodel);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.getBuildingMode())
            BuildLogic();
        if (gameManager.getDeletionMode())
            DeletionLogic();
    }

    public void ChooseBuilding(BuildingModel building)
    {
        if(buildObject != null)
        {
            Destroy(buildObject.gameObject);
            buildObject = null;
        }
        var go = new GameObject
        {
            layer = 8,
            name = "preview"
        };
        buildObject= go.AddComponent<Building>();
        buildObject.Init(building);

    }

    private void BuildLogic()
    {
        if (!gameManager.getBuildingMode() || !RayHit(buildingMask))
            return;
        buildObject.transform.position = snap(hit.point);
        if (Input.GetMouseButtonDown(0) && !buildObject.GetOverlapingflag())
        {
            buildObject.place();
            var modelcopy = buildObject.Model();
            buildObject= null;
            ChooseBuilding(modelcopy);

        }
    }
    private Vector3 snap(Vector3 possition)
    {
        var x = Mathf.Round(hit.point.x);
        var y = Mathf.Round(hit.point.y);
        var z = Mathf.Round(hit.point.z);
        return new Vector3(x, y, z);
    }
    private void DeletionLogic()
    {
        if (!gameManager.getDeletionMode() || !RayHit(deletionMask))
            return;
        target = hit.collider.gameObject.GetComponentInParent<Building>();

        if (target == null)
            return;

        if (Input.GetMouseButtonDown(0))
            target.destoy();
    }

    private bool RayHit(LayerMask mask)
    {
        var ray = camera.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out hit, buildDistance, mask);

    }


}
