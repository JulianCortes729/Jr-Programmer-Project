using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    //los valores almacenados en este miembro de clase se compartirán con todas las instancias de esa clase.
    public static MainManager Instance;
    public Color TeamColor;

    //Awake, al cual se llama tan pronto como se crea el objeto:
    private void Awake(){

        //si después cargas la Escena menú nuevamente, ya habrá un MainManager 
        //en existencia de forma que la Instancia no será nula. En tal caso, 
        //la condición se cumple: el MainManager adicional se destruye y el Script sale ahí.
        if(Instance != null){
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

}
