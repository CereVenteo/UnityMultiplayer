using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomTitle : MonoBehaviour
{
    [SerializeField]
    public Text title;
    void Update()
    {
        title.text = PhotonNetwork.CurrentRoom.Name;
    }
}
