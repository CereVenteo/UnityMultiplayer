using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomList : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform content;
    [SerializeField]
    private RoomTile room;

    [SerializeField]
    public GameObject UImanager;

    private List<RoomTile> roomsactive = new List<RoomTile>();

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo info in roomList)
        {
            //Aqui es si se esta saliendo;
            if (info.RemovedFromList)
            {
                int index = -1;
                foreach (RoomTile Room in roomsactive)
                {
                    if (Room.roomInfo.Name == info.Name)
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
                    Destroy(roomsactive[index].gameObject);
                    roomsactive.RemoveAt(index);
                }
            }
            else
            {
                // Aqui es si se esta creando
                RoomTile listing = Instantiate(room, content);
                if (listing != null)
                {
                    listing.SetRoomInfo(info,UImanager);
                    roomsactive.Add(listing);
                }
            }
        }
    }

}
