using System.Collections;
using System.Collections.Generic;
using Main;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    [SerializeField]
    private Button _button;

    [SerializeField] private MainView _mainView;
    
    // Start is called before the first frame update
    void Start()
    {
        _button.OnClickAsObservable()
            .Subscribe(_=>
            {
                _mainView.StartScenario();   
            }).AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
