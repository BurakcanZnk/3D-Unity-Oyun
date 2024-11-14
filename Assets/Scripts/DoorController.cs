using UnityEngine;

public class DoorController : MonoBehaviour
{

    public float openAngle;
    public bool isLocked = false;

    bool isOpen = false;
    Quaternion startRot;

    private void Start()
    {
        startRot = transform.rotation;
    }

    public void CheckDoor()
    {
        if (!isLocked)
            isOpen = !isOpen;
    }

    private void Update()
    {
        Quaternion currentRot = transform.rotation;
        Quaternion newRot = Quaternion.Euler(transform.eulerAngles.x, openAngle, transform.eulerAngles.x);
        if (isOpen)
            transform.rotation = Quaternion.Lerp(currentRot, newRot, 0.2f);
        else
            transform.rotation = Quaternion.Lerp(currentRot, startRot, 0.2f);

    }
}
