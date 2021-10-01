using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class TurnPlay : MonoBehaviour
{
    int turnPlay = 0;
    PhotonView view;

    public Text turnPlayDisplay;

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }

    public void AddTurnPlay()
    {
        view.RPC("AddTurnPlayRPC", RpcTarget.All);
    }

    [PunRPC]
    void AddTurnPlayRPC()
    {
        turnPlay++;
        turnPlayDisplay.text = "Turn " + turnPlay.ToString();
    }
}
