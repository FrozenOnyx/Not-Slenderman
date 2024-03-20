using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BehaviourStates
{
    public GameObject wendigo;
    public WendigoBehaviour manager;
    public virtual void EnterState() { }
    public virtual void ExitState() { }
    public virtual void Update() { }
}

public class WendigoBehaviour : MonoBehaviour
{
    Dictionary<string, BehaviourStates> states = new Dictionary<string, BehaviourStates>();

    BehaviourStates currentState = null;

    public string stateName = "";

    public GameObject player;
    public float distance;

    public float speed = 3f;
    public float rotSpeed = 100f;


    public bool romming = false;
    public bool wondering = false;
    public bool isRotatingLeft = false;
    public bool isRotatingRight = false;
    public bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        states.Add("Roming", new Romming(gameObject, this));
        ChangeState("Roming");
    }
    public void ChangeState(string BehaviourStates)
    {
        stateName = BehaviourStates;
        BehaviourStates previousState = currentState;
        currentState = states[BehaviourStates];
        if (previousState != currentState)
        {
            previousState?.ExitState();
            currentState?.EnterState();
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (currentState != null)
        {
            currentState.Update();
        }
        distance = Vector3.Distance(gameObject.transform.position, player.transform.position);
       // Debug.Log(distance);

        if(romming && !wondering)
        {
            StartCoroutine(Wondering());
        }
    }
    IEnumerator Wondering()
    {
        int rotTime = Random.Range(1, 3);
        int rotWait = Random.Range(1, 4);
        int rotateLeftOrRight = Random.Range(1, 2);
        int walkWait = Random.Range(1, 5);
        int walkTime = Random.Range(1, 6);

        wondering = true;
        yield return new WaitForSeconds(walkWait);
        isMoving = true;
        yield return new WaitForSeconds(walkTime);
        isMoving = false;
        yield return new WaitForSeconds(rotWait);
        if (rotateLeftOrRight == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingRight = false;
        }
        else if (rotateLeftOrRight == 2)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingLeft = false;
        }
        wondering = false;
    }
}
public class Romming : BehaviourStates
{
    public Romming(GameObject gameObject, WendigoBehaviour wendigoBehaviour)
    {
        wendigo = gameObject; 
        manager = wendigoBehaviour;
    }
  
    
    public override void EnterState() 
    {
        manager.romming = true;
    }
    public override void ExitState() 
    {
        manager.romming = false;
    }
    public override void Update() 
    {
        StayOutOfRange();
        StartRoming();
    }

    private void StayOutOfRange()
    {
        if (manager.distance < 40)
        {
            wendigo.transform.LookAt(manager.player.transform.position);
            wendigo.transform.Rotate(0, 180, 0);
            wendigo.transform.Translate(Vector3.forward);
            wendigo.transform.rotation = Quaternion.identity;
        }
    }

    private void StartRoming()
    {
        if(manager.distance > 40)
        {
            if(manager.isRotatingRight)
            {
                wendigo.transform.Rotate(wendigo.transform.up * Time.deltaTime * manager.rotSpeed);
            }
            else if(manager.isRotatingLeft)
            {
                wendigo.transform.Rotate(wendigo.transform.up * Time.deltaTime * -manager.rotSpeed);
            }
            if (manager.isMoving)
            {
                wendigo.transform.position += wendigo.transform.forward * manager.speed * Time.deltaTime;
            }
        }
    }
}
