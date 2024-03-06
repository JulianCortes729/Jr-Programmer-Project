using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif
// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker ColorPicker;

    public void NewColorSelected(Color color)
    {
        // add code here to handle when a color is selected
        MainManager.Instance.TeamColor = color;
    }
    
    private void Start()
    {
        ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;

        //Esta línea preseleccionará el color guardado en el MainManager (si hay alguno) cuando se ejecute la pantalla del menú
        ColorPicker.SelectColor(MainManager.Instance.TeamColor);
    }

    //metodo para el boton start
    public void StartNew(){
        SceneManager.LoadScene(1);
    }

    //metodo para el boton exit
    public void Exit(){
        //Esta línea guardará el último color seleccionado por el usuario cuando se cierre la aplicación. 
        MainManager.Instance.SaveColor(); 

        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit(); // original code to quit Unity player
        #endif
    }

    public void SaveColorClicked(){
        MainManager.Instance.SaveColor();
    }

    public void LoadColorClicked(){
        MainManager.Instance.LoadColor();
        ColorPicker.SelectColor(MainManager.Instance.TeamColor);
    }
}
