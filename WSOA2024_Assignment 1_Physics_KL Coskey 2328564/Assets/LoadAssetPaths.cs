using UnityEngine;

public class LoadAssetPaths
{
    public GameObject puck;
    public GameObject scoreBoard;
    public GameObject countdown;
    public GameObject player;
    public GameObject AIplayer;
    
    public void Start()
    {
        puck =Resources.Load<GameObject>("Puck");
        scoreBoard = Resources.Load<GameObject>("ScoreBoard");
        countdown = Resources.Load<GameObject>("Countdown");
        player = Resources.Load<GameObject>("Player");
        AIplayer = Resources.Load<GameObject>("AI Player");
        

    }
}
