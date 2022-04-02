using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float x, y, z;
    public float speed;

    float time;
    Transform tr;

    private void Start()
    {
        tr = transform;
    }

    void Update()
    {
        time = Time.deltaTime;

        tr.Rotate(x * speed * time,
                  y * speed * time,
                  z * speed * time,
                  Space.Self);
    }
}
