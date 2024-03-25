using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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

    public float speed = 7f;
    public float rotSpeed = 100f;


    public bool roaming = false;
    public bool wondering = false;
    public bool isRotatingLeft = false;
    public bool isRotatingRight = false;
    public bool isMoving = false;

    public Rigidbody rb;

    public SkullArea skullCount;
    public InCameraVeiw cameraVeiw;
    // Start is called before the first frame update
    void Start()
    {
        states.Add("Roaming", new Roaming(gameObject, this));
        states.Add("Stalking", new Stalking(gameObject, this));
        states.Add("Attacking", new Attacking(gameObject, this));
        ChangeState("Roaming");

        rb = GetComponent<Rigidbody>();
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

        if(roaming && !wondering)
        {
            StartCoroutine(Wondering());
        }
        SpeedControl();
    }
    private void SpeedControl()
    {
        Vector3 wendigoVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (wendigoVel.magnitude > speed)
        {
            Vector3 limitedVel = wendigoVel.normalized * speed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
    #region RoamingMonoCode
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
    #endregion 
}
public class Roaming : BehaviourStates
{
    public Roaming(GameObject gameObject, WendigoBehaviour wendigoBehaviour)
    {
        wendigo = gameObject; 
        manager = wendigoBehaviour;
    }
  
    
    public override void EnterState() 
    {
        manager.roaming = true;
    }
    public override void ExitState() 
    {
        manager.roaming = false;
    }
    public override void Update() 
    {
        StayOutOfRange();
        StartRoming();
        if(manager.skullCount.skullCounter != 0)
        {
            manager.ChangeState("Stalking");
        }
    }

    private void StayOutOfRange()
    {
        if (manager.distance < 15)
        {
            wendigo.transform.LookAt(manager.player.transform.position);
            manager.rb.AddForce(wendigo.transform.forward.normalized * manager.speed , ForceMode.Force);
        }
    }

    private void StartRoming()
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
public class Stalking : BehaviourStates
{
    public Stalking(GameObject gameObject, WendigoBehaviour wendigoBehaviour)
    {
        wendigo = gameObject;
        manager = wendigoBehaviour;
    }
    public override void EnterState() 
    {

    }
    public override void ExitState() 
    { 

    }
    public override void Update() 
    {
        SneakTowardsPlayer();
        MoveIfStuck();
        if(manager.skullCount.skullCounter >= 2)
        {
            manager.ChangeState("Attacking");
        }

    }

    private void SneakTowardsPlayer()
    { 
        if (manager.cameraVeiw.inCamera == false || manager.distance > 40 || manager.distance < 10)
        {
            wendigo.transform.LookAt(manager.player.transform.position);
            manager.rb.AddForce(wendigo.transform.forward.normalized * manager.speed /2, ForceMode.Force) ;
        }
        else if(manager.cameraVeiw.inCamera == true)
        {
            wendigo.transform.LookAt(manager.player.transform.position);
            manager.rb.AddForce(wendigo.transform.forward.normalized * - manager.speed *2 , ForceMode.Force);
        }
    }
    private void MoveIfStuck()
    {
        Vector3 wendigoVel = new Vector3(manager.rb.velocity.x, 0f, manager.rb.velocity.z);

        if (wendigoVel.magnitude < 0.05)
        {
            manager.rb.AddForce(wendigo.transform.right.normalized * manager.speed *10f, ForceMode.Force);
        }
    }
}
public class Attacking : BehaviourStates
{
    public Attacking(GameObject gameObject, WendigoBehaviour wendigoBehaviour)
    {
        wendigo = gameObject;
        manager = wendigoBehaviour;
    }
    public override void EnterState()
    {

    }
    public override void ExitState()
    {

    }
    public override void Update()
    {
        RunAtPlayer();
        MoveIfStuck();

    }

    private void RunAtPlayer()
    { 
        wendigo.transform.LookAt(manager.player.transform.position);  
        manager.rb.AddForce(wendigo.transform.forward.normalized * manager.speed , ForceMode.Force);
    }
    private void MoveIfStuck()
    {
        Vector3 wendigoVel = new Vector3(manager.rb.velocity.x, 0f, manager.rb.velocity.z);

        if (wendigoVel.magnitude < 0.05)
        {
            manager.rb.AddForce(wendigo.transform.right.normalized * manager.speed * 10f, ForceMode.Force);
        }
    }
}
