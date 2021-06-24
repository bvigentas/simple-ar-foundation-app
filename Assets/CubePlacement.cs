using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class CubePlacement : MonoBehaviour
{
    private static List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();

    ARRaycastManager raycastManager;

    [SerializeField]
    GameObject cube;

    void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            var touchPosition = Input.GetTouch(0).position;

            if (raycastManager.Raycast(touchPosition, raycastHits, TrackableType.PlaneWithinPolygon))
            {
                var hit = raycastHits[0].pose;

                Instantiate(cube, hit.position, hit.rotation);
            }
        }
    }
}
