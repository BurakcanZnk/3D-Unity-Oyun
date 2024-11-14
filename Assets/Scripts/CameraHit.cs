using UnityEngine;
using UnityEngine.UI;

public class CameraHit : MonoBehaviour
{
    public Image crosshair;

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            crosshair.color = Color.green;

            if (hit.transform.CompareTag("Door"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                    hit.transform.GetComponent<DoorController>().CheckDoor();
            }
        }
    }
}

