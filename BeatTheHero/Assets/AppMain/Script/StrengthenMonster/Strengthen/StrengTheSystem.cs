using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengTheSystem : MonoBehaviour
{

    [SerializeField] SaveAndRoad road;
    // Start is called before the first frame update
    void Start()
    {
        road.roadMonsterDate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
