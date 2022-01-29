using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LauncherBehavior : MonoBehaviour
{
    [SerializeField] float launcherDistance = 0.5f;
    [SerializeField] GameObject parent;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(mouseNormal() * launcherDistance);
        Vector2 parentPosition = new Vector2(parent.transform.position.x, parent.transform.position.y);
        transform.position = parentPosition + (mouseNormal()*launcherDistance);
    }

    private Vector2 mouseNormal()
    {
        Vector3 mousePosition = Mouse.current.position.ReadValue();
        mousePosition.z = Camera.main.nearClipPlane;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //Vector2 worldPosition2D = new Vector2(worldPosition.x, worldPosition.y);
        Vector2 launchVector = new Vector2(worldPosition.x - parent.transform.position.x, worldPosition.y - parent.transform.position.y).normalized;
        return launchVector;
    }
}
