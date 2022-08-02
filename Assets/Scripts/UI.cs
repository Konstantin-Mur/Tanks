using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    [SerializeField] private Text _hpText;
    [SerializeField] private Text _levelText;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _rounds;
    [SerializeField] private Text _tankSpeed;
    // [SerializeField] private GameObject _mainMenu;
    // [SerializeField] private GameObject _optionMenu;

    public void UpdateTankSpeed(int speed)
    {
        _tankSpeed.text = $"Speed {speed}";
    }
    public void UpdateScoreAndlevel()
    {
        _levelText.text = $"Level {Stats.Level}";
        _scoreText.text = $"Score {Stats.Score}";
    }
    public void UpdateHp(int hp)
    {
        if (hp <=30)
        {
            _hpText.text = $"HP {hp}";
        }
        else
        {
            hp = 30;
            _hpText.text = $"MAX HP {hp}";
        }
    }

    public void UpdateRpunds(int rounds)
    {
        if (rounds < 60)
        {
            _rounds.text = $"Rounds {rounds}";
        }
        else
        {
            _rounds.text = $"MAX Rounds {60}";
        }
    }

    //public void NewGame()
    //{
    //    Application.LoadLevel(0);
    //}
    //public void Exit()
    //{
    //    Application.Quit();
    //}

    //public void Option()
    //{
    //    _mainMenu.SetActive(false);
    //    _optionMenu.SetActive(true);
    //}

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        if (_optionMenu.activeSelf == true)
    //        {
    //            _mainMenu.SetActive(true);
    //            _optionMenu.SetActive(false);
    //            return;
    //        }
    //        if (_mainMenu.activeSelf == true)
    //        {
    //            _mainMenu.SetActive(false);
    //            _optionMenu.SetActive(true);
    //            return;
    //        }
    //    };
     
    //}
}
