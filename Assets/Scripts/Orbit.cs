using UnityEngine;

//Attach this script to a GameObject to rotate around the target position.
public class Orbit : MonoBehaviour
{
    //Assign a GameObject in the Inspector to rotate around
    public GameObject target;
    public int directionAround;

    public float degreesPerSecond = 50f;

    void Update()
    {
        switch(directionAround)
        {
            case 1:
                transform.RotateAround(target.transform.position, Vector3.down, Time.deltaTime * degreesPerSecond);
                break;
            case 2:
                transform.RotateAround(target.transform.position, Vector3.up, Time.deltaTime * degreesPerSecond);
                break;
            case 3:
                transform.RotateAround(target.transform.position, Vector3.left, Time.deltaTime * degreesPerSecond);
                break;
            case 4:
                transform.RotateAround(target.transform.position, Vector3.right, Time.deltaTime * degreesPerSecond);
                break;
            default: break;
        }
        
    }
}