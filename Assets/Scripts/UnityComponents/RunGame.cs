using System;
using System.Collections;
using System.Collections.Generic;
using Client;
using UnityEngine;
using UnityEngine.EventSystems;
using Object = UnityEngine.Object;

public class RunGame : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private GameObject _start;
    [SerializeField] private GameObject _win;
    [SerializeField] private GameObject _loose;
    [SerializeField] private GameObject _ecsStart;
    private GameObject _gameManager;

    private void Awake()
    {
        _start.SetActive(true);
        _win.SetActive(false);
        _loose.SetActive(false);
    }

    public void Win()
    {
        Destroy(_gameManager.GetComponent<EcsStartup>());
        Destroy(_gameManager);
        _win.SetActive(true);
    }

    public void Loose()
    {
        Destroy(_gameManager);
        _loose.SetActive(true);
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if (_gameManager != null) return;
        {
            _gameManager = Instantiate(_ecsStart);
            _start.SetActive(false);
            _win.SetActive(false);
            _loose.SetActive(false);
        }
    }
}
