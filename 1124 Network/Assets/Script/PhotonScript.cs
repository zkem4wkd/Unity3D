using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonScript : MonoBehaviourPunCallbacks
{
    public string version = "1.0";
    public string nickName = "name";
    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        OnLogin();
    }
    void OnLogin()
    {
        PhotonNetwork.GameVersion = version;
        PhotonNetwork.NickName = nickName;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected");
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed");
        this.CreateRoom();
    }
    void CreateRoom()
    {
        PhotonNetwork.CreateRoom(null,new RoomOptions { MaxPlayers = 4 });
    }
    public override void OnJoinedRoom()
    {
        
    }
}
