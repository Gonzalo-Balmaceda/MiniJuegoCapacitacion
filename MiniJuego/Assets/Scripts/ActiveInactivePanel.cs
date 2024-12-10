using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveInactivePanel : MonoBehaviour
{
    [SerializeField] private GameObject boostSpeedActivePanel;
    [SerializeField] private GameObject boostSpeedInactivePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator TiempoDeMuestra() 
    {
        
        yield return new WaitForSeconds(3F);

    }
}
