using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManeger : MonoBehaviour
{
    public static GameManeger instance;
    public GameObject jogadorPrefab;
    public Transform playerstart;

    public Personagem jogador;
    

    [SerializeField] private string dialogo;
    [SerializeField] private string tutorial;
    [SerializeField] private string palacio;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.GameObject());
        }
        else
        {
            Destroy(this.GameObject());
        }
    }

    public void AdicionarJogador()
    {
        if(playerstart==null) playerstart = GameObject.FindWithTag("Lugar").transform;
        GameObject player = Instantiate(jogadorPrefab, playerstart.transform.position, Quaternion.Euler(0, 0, 0));
        jogador = player.GetComponentInChildren<Personagem>();
        player.GetComponentInChildren<CinemachineConfiner2D>().m_BoundingShape2D =
            GameObject.FindWithTag("confiner").GetComponent<PolygonCollider2D>();


    }
    public void LoadScene()
    {
        
        SceneManager.LoadSceneAsync(tutorial);
    }

    public void SetCheckpoint(Transform ponto)
    {
        playerstart = ponto;
    }
}

