using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject lives_field;
    [SerializeField] GameObject wave_field;
    [SerializeField] GameObject enemies_field;
    [SerializeField] GameObject pause_button;
    [SerializeField] Sprite button_pause_sprite;
    [SerializeField] Sprite button_play_sprite;
    [SerializeField] GameObject money;
    
    public void PlayButtonToPause()
    {
        pause_button.GetComponent<Image>().sprite = button_play_sprite;
    }
    public void PlayButtonToPlay()
    {
        pause_button.GetComponent<Image>().sprite = button_pause_sprite;
    }

    public GameObject PauseButton
    {
        get
        {
            return pause_button;
        }
    }


    public static UIController instance;
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        enemies_field.GetComponent<Text>().text = GameController.instanse.EnemyCount.ToString() + " Enemies";
        wave_field.GetComponent<Text>().text = "Wave #" + GameController.instanse.Wave.ToString();
        lives_field.GetComponent<Text>().text = "Lives: " + GameController.instanse.Lives.ToString();
        money.GetComponent<Text>().text = GameController.instanse.Coins.ToString();
    }
}
