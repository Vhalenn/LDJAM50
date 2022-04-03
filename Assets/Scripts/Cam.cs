using UnityEngine;
using Cinemachine;

public class Cam : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera vCam;
    [SerializeField] CinemachineTransposer transposer;
    [SerializeField] Transform target;

    [Header("Variables")]
    [SerializeField] float rotationSpeed;
    [SerializeField][Range(0,1)] float decelerationSpeed = 0.5f;

    [Header("Altitude")]
    [SerializeField] float yMoveSpeed;
    [SerializeField] Vector2 minMaxY;
    [SerializeField] AnimationCurve farDistance;


    [Header("Debug")]
    [SerializeField] Vector2 delta;
    [SerializeField] float baseRotY;
    [SerializeField] Vector2 startP, actualP;
    [SerializeField] Vector2 scrollDelta;


    private void Awake()
    {
        transposer = vCam.GetCinemachineComponent<CinemachineTransposer>();
    }

    void Update()
    {
        RotationY();

        scrollDelta = Input.mouseScrollDelta;
        if (Mathf.Abs(scrollDelta.y) > 0.01f)
        {
            Vector3 pos = target.position;
            pos.y += scrollDelta.y * yMoveSpeed;
            SetCameraHeight(pos.y, true);
        }
    }

    void RotationY()
    {
        if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
        {
            startP = Input.mousePosition;
        }
        else if (Input.GetMouseButton(1) || Input.GetMouseButton(2))
        {
            actualP = Input.mousePosition;
            delta.x = Mathf.Lerp(delta.x, actualP.x - startP.x, 0.25f);
            startP = Input.mousePosition;
        }
        else if (Mathf.Abs(delta.x) > 0.1f)
        {
            delta.x = Mathf.Lerp(delta.x, 0, decelerationSpeed);
        }

        if (Mathf.Abs(delta.x) > 0.1f)
        {
            Vector3 rot = target.rotation.eulerAngles;
            rot.y += delta.x * rotationSpeed * Time.deltaTime;
            target.rotation = Quaternion.Euler(rot);
        }
    }


    public void SetCameraHeight(float height, bool clamp)
    {
        Vector3 pos = target.transform.position;
        pos.y = height;

        if(clamp)
        {
            pos.y = Mathf.Clamp(pos.y, minMaxY.x, minMaxY.y);
        }
        else
        {
            if (height >= minMaxY.y) minMaxY.y = height + Constant.floorHeight;
        }

        transposer.m_FollowOffset = new Vector3(0, 0, farDistance.Evaluate(height) );
        target.transform.position = pos;

    }
}
