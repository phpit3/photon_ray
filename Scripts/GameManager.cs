using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public enum TeamPlayer
{
    ONE = 1,
    TWO = 2,
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { set; get; }

    public GameObject playerTemp;

    private PhotonView view;

    TurnPlay turnPlay;

    private GameObject player01;
    private int characterPlayer01Index = 0;
    private GameObject[] childPlayer01 = new GameObject[5];
    private GameObject player02;
    private int characterPlayer02Index = 0;
    private GameObject[] childPlayer02 = new GameObject[5];

    [Header("Prefabs && Materials")]
    [SerializeField] private GameObject[] prefabs;

    private void Awake()
    {
        Instance = this;
    }

    //[System.Obsolete]
    private void Start()
    {
        view = GetComponent<PhotonView>();
        turnPlay = FindObjectOfType<TurnPlay>();

        //Debug.Log(prefabs[0].transform.GetChild(0).transform.position.x);
        //Debug.Log(prefabs[0].transform.GetChild(0).transform.position.y);

        if (PhotonNetwork.IsMasterClient)
        {
            turnPlay.AddTurnPlay();
        }

        player01 = PhotonNetwork.Instantiate(prefabs[0].name, prefabs[0].transform.position, Quaternion.identity);
        player02 = PhotonNetwork.Instantiate(prefabs[1].name, prefabs[1].transform.position, Quaternion.identity);

        if (view.IsMine)
        {
            //SpawnSoldier(0);
            //SpawnSoldier(1);
            //SpawnSoldier(2);
            //SpawnSoldier(3);
            //SpawnSoldier(4);
        }
        else
        {
            //SpawnSoldier(0);
        }

    }

    private void Update()
    {
        
    }

    public void SpawnSoldier(int index)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (characterPlayer01Index > 4)
            {
                characterPlayer01Index = 0;
            }

            if (childPlayer01[characterPlayer01Index])
            {
                Destroy(childPlayer01[characterPlayer01Index].gameObject);
            }

            Vector2 randomPosition = new Vector2(
                player01.transform.GetChild(characterPlayer01Index).transform.position.x,
                player01.transform.GetChild(characterPlayer01Index).transform.position.y
            );

            childPlayer01[characterPlayer01Index] = PhotonNetwork.Instantiate(
                "Character_" + index,
                randomPosition,
                Quaternion.identity);

            childPlayer01[characterPlayer01Index].name = player01.transform.GetChild(characterPlayer01Index).name + "_p1";
            //childPlayer01[characterPlayer01Index].transform.localScale = childPlayer01[characterPlayer01Index].transform.localScale * new Vector2(-1, 1);

            characterPlayer01Index++;
        }
        else
        {

        }
    }

    //public void SpawnSoldier(int index)

    public void SetCharacterIndex(int index, int team)
    {
        Debug.Log(index + " - team: " + team);
        if (team == (int)TeamPlayer.ONE)
        {
            characterPlayer01Index = index;
        } else
        {
            characterPlayer02Index = index;
        }
    }

}
