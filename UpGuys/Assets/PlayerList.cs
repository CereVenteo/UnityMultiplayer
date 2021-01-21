using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerList : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform content;
    [SerializeField]
    private PlayerTile playerT;

    private List<PlayerTile> playersactive = new List<PlayerTile>();

    public void justIenter()
    {
        GetCurrentPlayers();
    }

    private void GetCurrentPlayers()
    {
        foreach (KeyValuePair<int, Player> pinfo in PhotonNetwork.CurrentRoom.Players)
        {
            if (pinfo.Value != null)
                CreateNewPlayer(pinfo.Value);
        }
    }


    private void CreateNewPlayer(Player player)
    {
        PlayerTile listing = Instantiate(playerT, content);
        if (listing != null)
        {
            listing.SetPlayerInfo(player);
            playersactive.Add(listing);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {

        CreateNewPlayer(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        int index = -1;
        foreach (PlayerTile ply in playersactive)
        {
            if (ply.MyPlayer.NickName == otherPlayer.NickName)
            {
                index++;
                break;
            }
            else
            {
                index++;
            }
        }

        if (index != -1)
        {
            Destroy(playersactive[index].gameObject);
            playersactive.RemoveAt(index);
        }
    }
}
