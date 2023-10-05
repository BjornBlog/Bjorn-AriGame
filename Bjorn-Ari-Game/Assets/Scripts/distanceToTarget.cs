using UnityEngine;

[ExecuteInEditMode]
public class distanceToTarget : MonoBehaviour
{
    public GameObject obj;

    public float distanceBetweenObjects;


    private void Update()
    {
        distanceBetweenObjects = Vector3.Distance(transform.position, obj.transform.position);
        Debug.DrawLine(transform.position, obj.transform.position, Color.green);
    }

    // private void OnDrawGizmos()
    // {
    //     GUI.color = Color.black;
    //     Handles.Label(transform.position - (transform.position - 
    //     obj.transform.position)/2, distanceBetweenObjects.ToString());
    // }
}
