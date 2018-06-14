using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControler : MonoBehaviour {

    public static LevelControler current;
    public Vector3 initRabbitPos;

    private int coins = 0;
    private int mushrooms = 0;
    private int fruits = 0;
    private int bombs = 0;
    private int crystals = 0;
   
  

    // Use this for initialization

    void Awake()
    {
        current = this;
    }

    public void setStartPosition(Vector3 position)
    {
        initRabbitPos = position;
    }
        
    public void RabbitDeath(Controler rabbit)
    {
        rabbit.transform.position = initRabbitPos;
    }
    public void AddBombs(int bombs)
    {
        this.bombs += bombs;
    }
    public void AddCoins(int bombs)
  {
        this.bombs += bombs;
        Debug.Log("Bomb added");
    }
    public void AddMushrooms(int bombs)
    {
        this.bombs += bombs;
        Debug.Log("Bomb added");
    }
    public void AddFruits(int bombs)
    {
        this.bombs += bombs;
        Debug.Log("Bomb added");
    }
    public void AddCrystals(int bombs)
    {
        this.bombs += bombs;
        Debug.Log("Bomb added");
    }

}
