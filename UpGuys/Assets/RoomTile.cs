using Photon.Realtime;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomTile : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    [SerializeField]
    private Text text;

    private GameObject UImanager;

    public RoomInfo roomInfo { get; private set; }

    public void SetRoomInfo(RoomInfo roomInfo, GameObject UI)
    {
        this.roomInfo = roomInfo;
        text.text = roomInfo.Name;
        UImanager = UI;
    }


    public void OnClick_join()
    {
        print("Joining Room");
        PhotonNetwork.JoinRoom(roomInfo.Name);
       
    }

    public override void OnJoinedRoom()
    {
        print("Joined Room");
        UImanager.GetComponent<UIintroManager>().ActiveCanvas(UImanager.GetComponent<UIintroManager>().Lobby_c);
        UImanager.GetComponent<UIintroManager>().JustAwaked();
    }
}
