using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GroundChecker : MonoBehaviourPunCallbacks, IPunObservable
{
    #region IPunObservable implementation


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // We own this player: send the others our data
            stream.SendNext(heganao);
        }
        else
        {
            // Network player, receive data
            if (!heganao)
            this.hanganao = (bool)stream.ReceiveNext();
        }
    }


    #endregion

    CharacterMovement character_movement;
    private bool heganao;
    private bool hanganao;



    public GameObject win_canvas;

    public GameObject lose_canvas;




    // Start is called before the first frame update
    void Start()
    {
        heganao = false;
        hanganao = false;
        character_movement = gameObject.GetComponentInParent<CharacterMovement>();

        win_canvas = GameObject.Find("Canvas").transform.GetChild(0).gameObject;

        lose_canvas = GameObject.Find("Canvas").transform.GetChild(1).gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (win_canvas == null)
            win_canvas = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
       

        if (lose_canvas == null)
            lose_canvas = GameObject.Find("Canvas").transform.GetChild(1).gameObject;


        if (hanganao && !heganao)
        {
            lose_canvas.SetActive(true);
            print("he perdio");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            character_movement.is_grounded = true;
            character_movement.speed_y = 0;
        }

        if (other.tag == "WinPlatform" && !hanganao)
        {
            print("he ganao");
            heganao = true;
            win_canvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            character_movement.is_grounded = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            character_movement.is_grounded = true;
        }
    }
}
