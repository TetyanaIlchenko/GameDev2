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


    public LifePanel lifePanel;
    public CoinPanel coinPanel;
    public FruitPanel fruitPanel;


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
        coinPanel.UpdateCoins(this.coins);
    }
    public void AddMushrooms(int mushrooms)
    {
        this.mushrooms += mushrooms;
        Debug.Log("Bomb added");
    }
    public void AddFruits(int fruits)
    {
        this.fruits += fruits;
        Debug.Log("Bomb added");
        fruitPanel.UpdatePanel(this.fruits);
    }
    public void AddCrystals(int crystals)
    {
        this.crystals += crystals;
        Debug.Log("Bomb added");
    }

    public void OnRabitDeath(Controler rabit)
    {
        rabit.transform.position = initRabbitPos;
        if (lifePanel != null)
        {
       //   rabit.MinusLife();
        //  lifePanel.MinusLife(rabit.Lifes);
        //    if (rabit.Lifes == 0)
        //    {
         //       OnPlayerLose();
         //   }
        }
    }

}
