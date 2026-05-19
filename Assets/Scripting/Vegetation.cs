using UnityEngine;

public class Vegetation : MonoBehaviour
{
    public PhysicsOverlap physicsOverlap;

    public LayerMask groundlayer;

    public GameObject[] treePrefabs;

    public int TreeCount = 15;

    public Vector3 AreaSize = new Vector3(10, 50, 10);

    public float WaterHeight = -5f;

    public int spawned;

    public int attempts;

    void Start()
    {
        GenerateTrees();
    
    }

   public void GenerateTrees()
    {
        while (spawned < TreeCount &&
               attempts < 500)
        {
            attempts++;

         
            Vector3 randomPos =
                     new Vector3(
                    Random.Range(-AreaSize.x / 2,AreaSize.x / 2),0,
                    Random.Range( -AreaSize.z / 2,AreaSize.z / 2)
                );

            randomPos += transform.position;

           
            Vector3 rayStart = randomPos + Vector3.up * 50f;

            RaycastHit hit;

         
            if (Physics.Raycast( rayStart,Vector3.down, out hit,500f,groundlayer))
            {
                if (hit.collider.gameObject.layer != LayerMask.NameToLayer("ground"))
                   continue;
                Vector3 groundPos =  hit.point;


                if (groundPos.y <= WaterHeight)
                    continue;
                {
                    
                    physicsOverlap.position = groundPos;
                    physicsOverlap.enabled = false;
                    physicsOverlap.enabled = true;

                    if (physicsOverlap.Itspawn)
                    {
                        SpawnTree(groundPos);

                        spawned++;
                    }
                }
            }
        }
    }

   public void SpawnTree(Vector3 pos)
    {
        GameObject prefab = treePrefabs[Random.Range( 0, treePrefabs.Length)];

        Quaternion rot = Quaternion.Euler(0,Random.Range(0, 360), 0);

        GameObject tree =Instantiate(prefab,pos, rot, transform);

        float scale =Random.Range(0.8f, 1.3f);

        tree.transform.localScale =Vector3.one * scale;

        tree.tag = "Tree";
    }
}
