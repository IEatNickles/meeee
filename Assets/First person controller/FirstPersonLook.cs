using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{
    [SerializeField]
    Transform character;
    Vector2 currentMouseLook;
    Vector2 appliedMouseDelta;
    public float sensitivity = 1;
    public float smoothing = 2;

    RaycastHit hit;
    public float throwSpeed = 5f;
    GameObject grabbedObject;
    public Transform grabbedPosition;
    public float objectSpeed = 10f;


    void Reset()
    {
        character = GetComponentInParent<FirstPersonMovement>().transform;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get smooth mouse look.
        Vector2 smoothMouseDelta = Vector2.Scale(new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")), Vector2.one * sensitivity * smoothing);
        appliedMouseDelta = Vector2.Lerp(appliedMouseDelta, smoothMouseDelta, 1 / smoothing);
        currentMouseLook += appliedMouseDelta;
        currentMouseLook.y = Mathf.Clamp(currentMouseLook.y, -90, 90);

        // Rotate camera and controller.
        transform.localRotation = Quaternion.AngleAxis(-currentMouseLook.y, Vector3.right);
        character.localRotation = Quaternion.AngleAxis(currentMouseLook.x, Vector3.up);

        if (Input.GetMouseButtonDown(1) && Physics.Raycast(transform.position, transform.forward, out hit, throwSpeed) && hit.transform.GetComponent<Rigidbody>())
        {
            grabbedObject = hit.transform.gameObject;
        }
        else if(Input.GetMouseButtonUp(1))
        {
            grabbedObject = null;
        }
        if (grabbedObject)
        {
            grabbedObject.GetComponent<Rigidbody>().velocity = objectSpeed * (grabbedPosition.position - grabbedObject.transform.position);
        }
    }
}
