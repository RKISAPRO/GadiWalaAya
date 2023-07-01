using UnityEngine;

public class BagRotate : MonoBehaviour
{
    public float rotatespeed;
    public Vector3 rotatedirec;

    private void FixedUpdate()
    {
        transform.Rotate(rotatedirec, rotatespeed);
    }
}