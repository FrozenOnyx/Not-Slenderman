using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;

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

    public string preState = "";

    public bool roaming = false;
    public bool wondering = false;
    public bool isRotatingLeft = false;
    public bool isRotatingRight = false;
    public bool isMoving = false;

    public NavMeshAgent agent;

    public Rigidbody rb;

    public SkullArea skullCount;
    public InCameraVeiw cameraVeiw;

    public UvLightDamage uvLight;

    public AudioSource screem;
    // Start is called before the first frame update
    void Start()
    {
        agent.enabled = false;
        agent.updatePosition = true;
        states.Add("Roaming", new Roaming(gameObject, this));
        states.Add("Stalking", new Stalking(gameObject, this));
        states.Add("Attacking", new Attacking(gameObject, this));
        states.Add("Hurt", new Hurt(gameObject, this));
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
       // Debug.Log(transform.eulerAngles);
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
        manager.preState = manager.stateName;
    }
    public override void ExitState() 
    {
        manager.roaming = false;
    }
    public override void Update() 
    {
        Kill();
        StartRoming();
        if(manager.skullCount.skullCounter != 0)
        {
            manager.ChangeState("Stalking");
        }
        if (manager.uvLight.isInsideUv == true)
        {
            manager.ChangeState("Hurt");
        }
    }

    private void Kill()
    {
        if (manager.distance < 15)
        {
            Vector3 target = manager.player.transform.position;
            target.y = wendigo.transform.position.y;
            wendigo.transform.LookAt(target);
            manager.rb.AddForce(wendigo.transform.forward.normalized * manager.speed * 10f, ForceMode.Force);
           // Debug.Log("Chasing");
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
            manager.rb.AddForce(wendigo.transform.forward.normalized * manager.speed, ForceMode.Force);
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
        manager.agent.enabled = true;
        manager.agent.speed = 15f;
        manager.preState = manager.stateName;
        manager.screem.Play();
    }
    public override void ExitState() 
    { 
        manager.agent.enabled = false;
    }
    public override void Update() 
    {
        SneakTowardsPlayer();
        if(manager.skullCount.skullCounter >= 2)
        {
            manager.ChangeState("Attacking");
        }
        if (manager.uvLight.isInsideUv == true)
        {
            manager.ChangeState("Hurt");
        }

    }

    private void SneakTowardsPlayer()
    { 
        if (manager.cameraVeiw.inCamera == false || manager.distance > 40 || manager.distance < 10)
        {
            manager.agent.SetDestination(manager.player.transform.position);
        }
        else if(manager.cameraVeiw.inCamera == true)
        {
            manager.agent.ResetPath();
            wendigo.transform.LookAt(manager.player.transform.position);
            manager.rb.AddForce(wendigo.transform.forward.normalized * - manager.speed * 10f, ForceMode.Force);
        }
    }
}
public class Attacking : BehaviourStates
{
    public Attacking(GameObject gameObject, WendigoBehaviour wendigoBehaviour)
    {
        wendigo = gameObject;
        manager = wendigoBehaviour;
        manager.preState = manager.stateName;
    }
    public override void EnterState()
    {
        manager.agent.enabled = true;
        manager.agent.speed = 35f;
        manager.screem.pitch = 2;
        manager.screem.Play();
    }
    public override void ExitState()
    {
        manager.agent.enabled = false;
    }
    public override void Update()
    {
        RunAtPlayer();
        if (manager.uvLight.isInsideUv == true)
        {
            manager.ChangeState("Hurt");
        }
    }

    private void RunAtPlayer()
    {
        manager.agent.SetDestination(manager.player.transform.position);
    }

}
public class Hurt : BehaviourStates
{
    Vector3 dir;
    public Hurt(GameObject gameObject, WendigoBehaviour wendigoBehaviour)
    {
        wendigo = gameObject;
        manager = wendigoBehaviour;
    }
    public override void EnterState()
    {
        Vector3 target = manager.player.transform.position;
        target.y = wendigo.transform.position.y;
        wendigo.transform.forward = wendigo.transform.position - target ;
        dir = wendigo.transform.forward.normalized;

    }
    public override void ExitState()
    {

    }
    public override void Update()
    {
        wendigo.transform.forward = dir;
        RunAway();
        ChangeStateToPrevois();
    }

    private void RunAway()
    {
        manager.rb.AddForce(wendigo.transform.forward.normalized * manager.speed * 4f , ForceMode.Force);
    }

    private void ChangeStateToPrevois()
    {
        if(manager.distance >= 60)
        {
            manager.ChangeState(manager.preState);
        }
    }


}
