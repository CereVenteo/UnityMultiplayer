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

    private float Timer_entered = 100;
    private bool newp = false;

    public void justIenter()
    {
        GetCurrentPlayers();
    }

    private void GetCurrentPlayers()
    {
        int index = 0;
        foreach (PlayerTile ply in playersactive)
        {
            Destroy(playersactive[index].gameObject);
            index++;
        }
        playersactive.Clear();


        foreach (KeyValuePair<int, Player> pinfo in PhotonNetwork.CurrentRoom.Players)
        {
            if (pinfo.Value != null)
            {
                CreateNewPlayer(pinfo.Value);  
            }
        }
        
    }

    private void Update()
    {
        Timer_entered += Time.deltaTime;
        if (Timer_entered >= 2 && newp == true)
        {
            GetCurrentPlayers();
            newp = false;
        }
    }


    private void CreateNewPlayer(Player player)
    {
        PlayerTile listing = Instantiate(playerT, content);
        if (listing != null)
        {
            if (player.NickName == "")
            {
                string mummy = "Mummy";
                player.NickName = mummy + Random.Range(0, 9999).ToString();
            }
            listing.SetPlayerInfo(player);
            playersactive.Add(listing);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        GetCurrentPlayers();
        Timer_entered = 0.0f;
        newp = true;
        
        //CreateNewPlayer(newPlayer);
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
