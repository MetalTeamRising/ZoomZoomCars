using UnityEngine;
using System.Collections;

public class selector : MonoBehaviour
{
    [System.NonSerialized]
    public GameObject[] m_gameObjects;

    [System.NonSerialized]
    public int index = 0;
    // Use this for initialization


    void Start()
    {
        m_gameObjects = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            m_gameObjects[i] = transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the object around its local X axis at 1 degree per second
        transform.Rotate(Vector3.up * Time.deltaTime * 30);
    }
    public void Switch()
    {
        if (index < m_gameObjects.Length - 1)
        {
            index++;
            m_gameObjects[index - 1].SetActive(false);
            m_gameObjects[index].SetActive(true);
        }
        else
        {
            index = 0;
            m_gameObjects[m_gameObjects.Length - 1].SetActive(false);
            m_gameObjects[index].SetActive(true);
        }
    }

    public void SwitchB()
    {
        if (index > 0)
        {
            index--;
            m_gameObjects[index + 1].SetActive(false);
            m_gameObjects[index].SetActive(true);
        }
        else
        {
            index = m_gameObjects.Length - 1;
            m_gameObjects[0].SetActive(false);
            m_gameObjects[index].SetActive(true);
        }
    }
}
