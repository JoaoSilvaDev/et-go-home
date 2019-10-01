using UnityEngine;

public class Tracker : MonoBehaviour
{

    [SerializeField] private GameObject prefab;

    private GameObject _instance;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (!_instance)
            {
                _instance = Instantiate(prefab, transform.position, transform.rotation);
            }
            else
            {
                _instance.transform.position = transform.position;
                _instance.transform.rotation = transform.rotation;
            }
        }
    }

}
