
using UnityEngine;

public class BillboardAudience : MonoBehaviour
{
    public bool useStaicBillboard;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void LateUpdate()
    {
        if (!useStaicBillboard)
        {
            transform.LookAt(mainCamera.transform);
        } 
        else
        {
            transform.rotation = mainCamera.transform.rotation;
        }

        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }
}
