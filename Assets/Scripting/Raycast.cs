using UnityEngine;

public class Raycast : MonoBehaviour
{
    public LayerMask ground;
    public bool Position;
    public Vector3 GroundPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RaycastHit hit;

        
        Vector3 startPos =
            transform.position + Vector3.up * 50f;

        
        if (Physics.Raycast(
            startPos,
            Vector3.down,
            out hit,
            100f,
            ground))
        {
            Position = true;

            GroundPosition = hit.point;

            Debug.Log("Ground Found: " + GroundPosition);
        }
        else
        {
            Position = false;

            Debug.Log("No Ground Found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
