using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TestConnect : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        print("Connecting To Server");
        PhotonNetwork.GameVersion = "0.0.1";
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    public override void OnConnectedToMaster()
    {
        print("Connected To Server");
        PhotonNetwork.JoinLobby();
    }
    
}
