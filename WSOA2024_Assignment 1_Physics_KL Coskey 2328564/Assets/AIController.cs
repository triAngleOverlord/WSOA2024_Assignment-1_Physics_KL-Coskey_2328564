using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public Vector3 puckPosition;
    public Rigidbody2D AIbody;
    public GameObject AIPlayer;

    [SerializeField] private FlashObjColor _flash;

    //public Vector3 awayFromPuck;
    public Vector3 newAIPos;
    public Vector3 posBehindPuck;
    public Vector3 posInfrontPuck;
    public Vector3 posBetween;
    public Vector3 posGoal;

    public float _speed;



    public bool AIactive;

    private void Awake()
    {
        AIPlayer = this.gameObject;
        AIbody = AIPlayer.transform.GetComponent<Rigidbody2D>();
        posGoal = new Vector3( 11,0,0 );    
    }


    // Update is called once per frame
    void Update()
    {
        if (AIactive == true)
        {
            puckPosition = GameObject.FindGameObjectWithTag("Puck").transform.localPosition;
            //awayFromPuck = transform.localPosition - puckPosition;
            newAIPos = transform.GetComponent<Rigidbody2D>().position;
            posBehindPuck = new Vector3(puckPosition.x + 1, puckPosition.y, puckPosition.z);
            posInfrontPuck = new Vector3(puckPosition.x - 2, puckPosition.y, puckPosition.z);
            //posBetween = puckPosition - posGoal;
        }

    }

    void FixedUpdate()
    {
        if (AIactive == true)
        {
                if (puckPosition.x > -0.5 && AIbody.transform.localPosition.x> puckPosition.x)
                {
                //AIbody.transform.localPosition = Vector3.MoveTowards(transform.localPosition, posBehindPuck, _speed * 3 * Time.deltaTime);
                //AIbody.AddForce(posInfrontPuck*_speed, ForceMode2D.Force);
                
                AIbody.MovePosition(Vector3.MoveTowards(transform.localPosition, posBehindPuck, _speed * 3 * Time.deltaTime));
                
                }

                else
                {
                    newAIPos.y = Mathf.MoveTowards(newAIPos.y, puckPosition.y, _speed * Time.deltaTime);
                    newAIPos.x = Mathf.MoveTowards(newAIPos.x, 9, _speed*2 * Time.deltaTime);
                    transform.localPosition = newAIPos;
                }
            
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Puck"))
        {
            if (GameManager.instance.t_state == GameManager.Turns.t_Player)
            {
                GameManager.instance.UpdateTurnState(GameManager.Turns.penaltyCPU);
                _flash.objFlash(Color.grey);
            }

            else if (GameManager.instance.t_state == GameManager.Turns.penaltyCPU)
            {
                Debug.Log("Computer is trying to hit the puck again!");
            }
            else
            {
                GameManager.instance.UpdateTurnState(GameManager.Turns.t_Player);
            }
        }
       
    }

   
}
