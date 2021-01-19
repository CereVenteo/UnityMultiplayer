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
    private RoomListing room;

    private List<RoomListing> roomsactive = new List<RoomListing>();

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo info in roomList)
        {
            //Aqui es si se esta saliendo;
            if (info.RemovedFromList)
            {
                int index = -1;
                foreach (RoomListing Room in roomsactive)
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
                RoomListing listing = Instantiate(room, content);
                if (listing != null)
                {
                    listing.SetRoomInfo(info);
                    roomsactive.Add(listing);
                }
            }
        }
    }

}
