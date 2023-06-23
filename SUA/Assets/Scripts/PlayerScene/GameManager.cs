using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI추가
using System;



public class GameManager : MonoBehaviour
{
    public enum GameState //게임 상태값 설정
    {
        Start,
        Playing,
        GameOver
    }

    public event Action<GameState> OnGameStateChanged;

    public GameState currentState = GameState.Start;

    public GameState CurrentState
    {
        get { return currentState; }
        private set
        {
            currentState = value;
            OnGameStateChanged?.Invoke(currentState); //이벤트가 null이 아닌 경우에만 이 이벤트를 호출
        }
    }

    public void StartGame()
    {
        //게임 시작 로직을 여기에 작성
        CurrentState = GameState.Playing;
    }

    public void GameOver()
    {
        //게임 오버 로직을 여기에 작성
        CurrentState = GameState.GameOver;
    }



    public GameManager() {}
    public static GameManager Instance {get; private set;} // 싱글톤화
    public PlayerHp playerHp; // 플레이어의 Hp
    public Image playerHpUIImage; //플레이어의 Hp UI 이미지
    public Button BtnSample;

    
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
