using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTile : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Text text;

    public Player MyPlayer;

    public void SetPlayerInfo(Player player)
    {
        MyPlayer = player;
        text.text = player.NickName;
    }
}
