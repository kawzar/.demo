using UnityEngine;

public class CameraMouseLookController : MonoBehaviour
{
    private Vector2 mouseLook;
    private Vector2 smooth;

    [SerializeField]
    private float sensitivity = 5.0f;

    [SerializeField]
    private float smoothing = 2.0f;

    [SerializeField]
    private GameObject character;

    [SerializeField] private float maxVerticalAngle = 45;

    void Update()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        md = Vector2.Scale(md, new Vector2(sensitivity, sensitivity));

//        smooth.x = Mathf.Lerp(smooth.x, md.x, 1f / smoothing);
//        smooth.y = Mathf.Lerp(smooth.y, md.y, 1f / smoothing);
//        mouseLook += smooth;

        mouseLook += md;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -maxVerticalAngle, maxVerticalAngle);
        
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
    }
}
