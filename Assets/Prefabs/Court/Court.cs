using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Court : MonoBehaviour
{

    public GameObject marker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetMarkerPos()
    {
        return marker.transform.position;
    }

    public Vector3 GetRandomPoint()
    {
        Mesh planeMesh = gameObject.GetComponent<MeshFilter>().mesh;
        Bounds bounds = planeMesh.bounds;

        float minX = gameObject.transform.position.x - gameObject.transform.localScale.x * bounds.size.x * 0.5f;
        float minZ = gameObject.transform.position.z - gameObject.transform.localScale.z * bounds.size.z * 0.5f;

        Vector3 randomPoint = new Vector3(Random.Range (minX + 0.5f, -minX - 0.5f), gameObject.transform.position.y, Random.Range (minZ - 1f, -minZ + 1f));
        Vector3 markerPoint = new Vector3(randomPoint.x, randomPoint.y - 0.7f, randomPoint.z);
        marker.transform.position = transform.TransformPoint(markerPoint);
        return transform.TransformPoint(randomPoint);
    }
}