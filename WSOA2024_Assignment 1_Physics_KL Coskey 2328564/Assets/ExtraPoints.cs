using Scoring;
using System.Collections;
using UnityEngine;

public class ExtraPoints : MonoBehaviour
{
    public ScoreKeeper Keeper;
    
    private float newX;
    private float Xdenom;
    private float newY;
    private float Ydenom;
    [SerializeField] private FlashObjColor _flash;
    

    private void Awake()
    {
        Keeper = new ScoreKeeper();
        
        StartCoroutine(changeRegionPos());
        transform.GetComponent<SpriteRenderer>().color = Color.cyan;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        ///no extra points awarded if they got a penalty touching more than once
        if (other.gameObject.CompareTag("Puck"))
        {
            if (GameManager.instance.t_state== GameManager.Turns.t_Player)
            {
                ///the computer touched it last making it turn to player
                Keeper.p_computerScored(1);
                _flash.objFlash(Color.yellow);
                
            }
            else if (GameManager.instance.t_state == GameManager.Turns.t_Computer)
            {
                ///the player touched it last making it turn to computer
                Keeper.p_playerScored(1);
                _flash.objFlash(Color.green);
                
            }
            else
            {
                transform.GetComponent<SpriteRenderer>().color = Color.cyan;
            }
        }
    }

    IEnumerator changeRegionPos()
    {
        Xdenom = Random.Range(-75, 75);
        Ydenom = Random.Range(-75, 75);

        newX = Random.Range(-9, 9);
        newY = Random.Range(-3, -3);

        transform.localPosition = new Vector3(newX * (Xdenom/100), newY * (Ydenom/100), 0);
        yield return new WaitForSeconds(7);

        StartCoroutine(changeRegionPos());
    }

    
}
