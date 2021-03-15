using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelector : MonoBehaviour
{
    public GameObject[] changeCharacter; //Arreglo de previsualización de personajes con sus características
    public GameObject[] characters; //Prefabs de los personajes que se crearán

    private int index = 0;
    
    void Start()
    {
        //Todos los objetos de desactivan de pantalla
        foreach(GameObject obj in changeCharacter)
        {
            obj.SetActive(false);
        }
        
        
        Select(index);
    }

    public void GoLeft()
    {
        changeCharacter[index].SetActive(false);
        index--;
        if(index < 0)
        {
            index = changeCharacter.Length - 1;
        }
        Select(index);
    }

    public void GoRight()
    {
        changeCharacter[index].SetActive(false);
        index++;
        if (index >= changeCharacter.Length)
        {
            index = 0;
        }
        Select(index);
        
    }

    //El objecto que se selecciona aparece en pantalla
    public void Select(int i)
    {
        foreach (GameObject obj in changeCharacter)
        {
            obj.SetActive(false); 
        }
        
        changeCharacter[i].gameObject.SetActive(true);
        PlayerStorage.playerPrefab = characters[i]; //Instancia el prefab que será creado para la escena principal
    }
}
