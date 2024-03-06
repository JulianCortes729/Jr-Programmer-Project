using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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

        LoadColor(); 
    }


    [Serializable]
    class SaveData{
        public Color TeamColor;
    }
   
   public void SaveColor(){

        /*creamos una nueva instancia de los datos guardados y rellenamos 
        su miembro de la clase de color de equipo con la variable TeamColor 
        guardada en MainManager*/
        SaveData data = new SaveData();
        data.TeamColor = TeamColor;

        //transformamos esa instancia de JSON 
        string json = JsonUtility.ToJson(data);

        //para escribir una secuencia de caracteres a un archivo 
        //primer parametro: directorio del archivo
        //segundo parametro: es el texto que quieres escribir en ese archivo
        File.WriteAllText(Application.persistentDataPath+"/savefile.json", json);
   }

    public void LoadColor(){

        //conseguimos la ubicacion del archivo
        string path = Application.persistentDataPath+"/savefile.json";

        //para verificar si existe un archivo .json. 
        if(File.Exists(path)){
            
            //leemos el contenido del archivo
            string json = File.ReadAllText(path);

            //tranformamos nuevamente el json en una instancia de SaveData
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            //definimos el TeamColor al color guardado en ese SaveData
            TeamColor = data.TeamColor;
        }
    }

}
