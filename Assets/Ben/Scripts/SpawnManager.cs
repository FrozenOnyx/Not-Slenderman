using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Spawn1;
    public GameObject Spawn2;
    public GameObject Spawn3;
    public GameObject Spawn4;
    public GameObject Spawn5;
    public GameObject Spawn6;
    public GameObject Spawn7;
    public GameObject Spawn8;
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
        spawnList.Add(Spawn4);
        spawnList.Add(Spawn5);
        spawnList.Add(Spawn6);
        spawnList.Add(Spawn7);
        spawnList.Add(Spawn8);
        spawnFirstSkull();
       
    }
    private void spawnFirstSkull()
    {
        bone = 0;
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
