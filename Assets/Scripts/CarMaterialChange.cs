using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMaterialChange : MonoBehaviour
{
    [SerializeField]
    GameObject carModel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        carModel.GetComponent<TurnTranslucentThenBack>().TurnTranslucent();
    }
    private void OnDisable()
    {
        carModel.GetComponent<TurnTranslucentThenBack>().TurnBack();
    }
}
