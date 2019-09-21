using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour {

    Vector3 dollyDir;
    public Vector3 dollyDirAdjusted;
    public float minDistance = 1.0f;
    public float maxDistance = 4.0f;
    public float smooth = 10.0f;
    public float distance;
    // Use this for initialization
    void Start () {
        dollyDir = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 desiredCameraPOS = transform.parent.TransformPoint(dollyDir * maxDistance);
        RaycastHit hit;

        if (Physics.Linecast(transform.parent.position, desiredCameraPOS, out hit))
            distance = Mathf.Clamp((hit.distance * 0.87f), minDistance, maxDistance);
        else
            distance = maxDistance;

        transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDir * distance, Time.deltaTime * smooth);
	}
}
