using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private InputField inputArena;

    [Space(10)]
    [Header("Main Menu Element")]
    [SerializeField] private Button enter;

    [Space(10)]
    [Header("Network Manager")]
    [SerializeField] private NetworkManager networkManager;

    // Start is called before the first frame update
    void Start()
    {
        enter.gameObject.SetActive(false);
//        enter.onClick.AddListener(StartGame);
        inputArena.onValueChanged.AddListener(delegate { SetGameId(); });
    }

    // Function that doesn't recieve a parameter nor does it return any. 
    // This function serve to make the Enter World Button active or unactive if the world is not set.
    // An empty world will be desactivated. 
    private void SetGameId()
    {
        if(inputArena.text != "")
        {
            enter.gameObject.SetActive(true);
        }
        else
        {
            enter.gameObject.SetActive(false);
        }
    }

    private void StartGame(string worldId)
    {
        //Desactivate Current UI to attemp to connect to the server.
        inputArena.gameObject.SetActive(false);
        enter.gameObject.SetActive(false);

        networkManager.StartClient();
        
    }
}

public static class MatchExtensions
{
    public static Guid ToGuid(string id)
    {

        MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
        byte[] inputBytes = Encoding.Default.GetBytes(id);

        byte[] hashBytes = provider.ComputeHash(inputBytes);

        return new Guid(hashBytes);
    }
}
