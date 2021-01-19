using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateNewRoom : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text roomname;

    [SerializeField]
    public GameObject UI_Manager;

    public void OnClick_CreateRoom()
    {
        if (!PhotonNetwork.IsConnected)
            return;

        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 10;

        PhotonNetwork.JoinOrCreateRoom(roomname.text, options, TypedLobby.Default);

        UI_Manager.GetComponent<UIintroManager>().ActiveCanvas(UI_Manager.GetComponent<UIintroManager>().Lobby_c);

    }

    public override void OnCreatedRoom()
    {
        print("Room " + roomname + " created succesfully.");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        print("Room " + roomname + " creation failed by" + message);
    }

}
