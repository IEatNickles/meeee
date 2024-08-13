using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slide : MonoBehaviour
{
    public Rigidbody rig;
    CapsuleCollider colider;

    float originalHeight;
    public float reducedHeight;

    public float slideSpeed = 10f;

    void Start()
    {
        colider = GetComponent<CapsuleCollider>();
        rig = GetComponent<Rigidbody>();
        originalHeight = colider.height;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
            Sliding();
        else if (Input.GetKeyUp(KeyCode.LeftShift))
            GoUp();

        if (Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKey(KeyCode.W))
            Sliding();
        else if (Input.GetKeyUp(KeyCode.LeftControl))
            GoUp();
    }

    private void Sliding()
    {
        colider.height = reducedHeight;
        rig.AddForce(transform.forward * slideSpeed, ForceMode.VelocityChange);
    }

    private void GoUp()
    {
        colider.height = originalHeight;
    }
}
