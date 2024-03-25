using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Spawn1;
    public GameObject Spawn2;
    public GameObject Spawn3;
    List<GameObject> spawnList = new List<GameObject>();
    public GameObject Skull;
    int bone = 0;
    public SkullArea skullArea;

    // Start is called before the first frame update
    void Start()
    {
        spawnList.Add(Spawn1);
        spawnList.Add(Spawn2);
        spawnList.Add(Spawn3);
        spawnFirstSkull();
       
    }
    private void spawnFirstSkull()
    {
        bone = Random.Range(0, spawnList.Count);
        Instantiate(Skull, spawnList[bone].transform.position, Quaternion.identity);

        spawnList.Remove(spawnList[bone]);
    }

    public void Update()
    {
        spawnRestSkulls();
    }
    private void spawnRestSkulls()
    {
        if (skullArea.skullCounter >= 1 && spawnList.Count != 0)
        {
            bone = Random.Range(0, spawnList.Count);
            Instantiate(Skull, spawnList[bone].transform.position, Quaternion.identity);
            spawnList.Remove(spawnList[bone]);
        }
    }
}
