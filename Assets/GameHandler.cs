using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField]
    public GameObject MommyPref;
    // Start is called before the first frame update
    void Awake()
    {
        print("somos distintos con su rollo y con su instinto");
       PhotonNetwork.Instantiate(this.MommyPref.name, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
    }
}

