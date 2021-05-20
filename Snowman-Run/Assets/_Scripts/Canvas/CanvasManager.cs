﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{

    [SerializeField]
    private GameObject _menuUI, _inGameUI, _wimIU, _lostUI;
    [SerializeField]
    private Image  _levelBar;
    private Transform _finishPos;
    [SerializeField]
    private Text _textLevelWin, _textLevelCurent, _textLevelTarget;
    private MoveRowe _moveRowe;

    private float _distens;
    private float _distensTraveled
    { get { return _finishPos.position.z - _moveRowe.transform.position.z; } }

    private void Awake()
    {
        _moveRowe = FindObjectOfType<MoveRowe>();
        _finishPos = FindObjectOfType<FinishScript>().transform;
    }
    private void Start()
    {
        _distens = _finishPos.position.z - _moveRowe.transform.position.z - 0.5f;

        _textLevelWin.text ="Level "+ PlayerPrefs.GetInt("Level").ToString();
        _textLevelCurent.text = PlayerPrefs.GetInt("Level").ToString();
        _textLevelTarget.text = (PlayerPrefs.GetInt("Level") +1).ToString();
    }
    private void FixedUpdate()
    {
        AmoutDistensTraveled();
    }
    private void AmoutDistensTraveled()
    {
        float amoutDistens = 1 - _distensTraveled / _distens;
        _levelBar.fillAmount = Mathf.Lerp(_levelBar.fillAmount, amoutDistens, 0.7f);
    }

    public void GameStageWindow(Stage stageGame)
    {
        switch (stageGame)
        {
            case Stage.StartGame:

                _menuUI.SetActive(true);
                _inGameUI.SetActive(false);
                break;

            case Stage.StartLevel:

                _menuUI.SetActive(false);
                _inGameUI.SetActive(true);
                break;

            case Stage.WinGame:

                _inGameUI.SetActive(false);
                _wimIU.SetActive(true);
                break;

            case Stage.LostGame:

                _inGameUI.SetActive(false);
                _lostUI.SetActive(true);
                break;
        }
    }

}
