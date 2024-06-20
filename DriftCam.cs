using UnityEngine;

public class DriftCam : MonoBehaviour
{
    public Transform target;
    public float distance = 3.5f; 
    public float height = 2.5f; 
    public float smoothSpeed = 9f; 
    public float smoothMove = 7f; 
    public float rotationDamping = 14f; 

    private Vector3 offset;

    void Start()
    {
        
        offset = new Vector3(0f, height, -distance);
    }

    void FixedUpdate()
    {
        Vector3 targetPosition = (target.position + target.TransformDirection(offset));
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position, target.up);

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothMove * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationDamping * Time.deltaTime);
    }
}
