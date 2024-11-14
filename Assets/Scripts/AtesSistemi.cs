using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class at : MonoBehaviour
{
    Camera kamera;
    public LayerMask enemyKatman;

    void Start()
    {
        kamera = Camera.main;
    }


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            AtesEtme();
        }

    }
    void AtesEtme()
    {
        Ray ray = kamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, enemyKatman))
        {
            hit.collider.gameObject.GetComponent<Enemy>().HasarAl();
        }
    }
}