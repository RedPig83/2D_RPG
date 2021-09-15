using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject prefabToSpawn;

    public float fRepeatInterval;

    // Start is called before the first frame update
    public void Start()
    {
        if(fRepeatInterval > 0)
        {
            InvokeRepeating("SpawnObject", 0.0f, fRepeatInterval);
        }
    }

    public GameObject SpawnObject()
    {
        if (prefabToSpawn != null)
        {
            return Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
        }

        return null;
    }

}
