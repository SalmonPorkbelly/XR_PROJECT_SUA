using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    public GameManager() {}
    public static GameManager Instance {get; private set;} // 싱글톤화
    public PlayerHp playerHp; // 플레이어의 Hp
    public Image playerHpUIImage; //플레이어의 Hp UI 이미지
    public Button BtnSample;

    private void Start() {
        this.BtnSample.onClick.AddListener(()=> //Linstener로 버튼 등록
        {
            Debug.Log("Button Check");
        });
    }
    
    private void Awake()
    {
        if(Instance)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            transform.parent = null;
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        Init();
    }

    private void Init()
    {
        playerHp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHp>();
        playerHpUIImage = GameObject.FindGameObjectWithTag("UIHealthBar").GetComponent<Image>();
    }

    private void Update()
    {
        playerHpUIImage.fillAmount = (float)playerHp.Hp / 100.0f;
    }
}
