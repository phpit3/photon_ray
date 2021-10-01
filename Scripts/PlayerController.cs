using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    public float speed;

    public int teamPlayer;

    public int teamIndex;

    private PhotonView view;

    void OnMouseDown()
    {
        GameManager.Instance.SetCharacterIndex(2, (int)TeamPlayer.ONE);
        //Debug.Log("OnMouseDown");
        //Destroy(gameObject);
    }

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (view.IsMine)
        {
            //Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            //Vector2 moveAmount = moveInput.normalized * speed * Time.deltaTime;
            //transform.position += (Vector3)moveAmount;
        }
    }
}
