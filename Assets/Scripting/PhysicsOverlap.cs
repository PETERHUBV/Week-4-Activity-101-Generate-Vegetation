using UnityEngine;

public class PhysicsOverlap : MonoBehaviour
{
    public float TreeDistance = 6f;
    public bool Itspawn;
    public Vector3 position;
    public Collider[] Nearbytrees;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    

        Nearbytrees = Physics.OverlapSphere(position, TreeDistance);
        Itspawn = true;
        foreach (Collider col in Nearbytrees)
        {
            if (col.transform == transform)
            {
                continue;
            }

         
            if (col.CompareTag("Tree"))
            {
                Itspawn = false;

                break;
            }
        }
    }
}