using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomListing : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Text text;

    public RoomInfo roomInfo { get; private set; }

    public void SetRoomInfo(RoomInfo roomInfo)
    {
        this.roomInfo = roomInfo;
        text.text = roomInfo.Name;
    }
}
